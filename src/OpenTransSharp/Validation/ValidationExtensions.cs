﻿namespace OpenTransSharp.Validation;

public static class ValidationExtensions
{
    public static void EnsureValid(this IOpenTransRoot model, XmlSerializer serializer)
    {
        var validationResult = model.Validate(serializer);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

    public static void EnsureValidOpenTransDocument(this string model, XmlSerializer serializer)
    {
        var validationResult = model.ValidateOpenTransDocument(serializer);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

    public static bool IsValid(this IOpenTransRoot model, XmlSerializer serializer)
    {
        try
        {
            var result = model.Validate(serializer);

            return result.IsValid;
        }
        catch (Exception exc)
        {
            Debug.WriteLine(exc.Message);
            return false;
        }
    }

    public static ValidationResult Validate(this IOpenTransRoot model, XmlSerializer serializer)
    {
        var validationErrors = new List<ValidationError>();

        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        var schemaSet = GetXmlSchemaSet(serializer);

        try
        {
            using var ms = new MemoryStream();
            serializer.Serialize(ms, model);
            ms.Position = 0;

            using var reader = new StreamReader(ms);
            return ValidateWithReader(validationErrors, schemaSet, reader);
        }
        finally
        {
        }
    }

    public static ValidationResult ValidateOpenTransDocument(this string model, XmlSerializer serializer)
    {
        var validationErrors = new List<ValidationError>();

        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        var schemaSet = GetXmlSchemaSet(serializer);

        try
        {
            using var reader = new StringReader(model);

            return ValidateWithReader(validationErrors, schemaSet, reader);
        }
        finally
        {
        }
    }

    private static ValidationResult ValidateWithReader(List<ValidationError> validationErrors, XmlSchemaSet schemaSet, TextReader reader)
    {
        var document = XDocument.Load(reader);
        var isValid = true;

        document.Validate(schemaSet, (s, e) =>
        {
            isValid = false;

            var name = "";
            if (s is XElement xe)
            {
                name = xe.GetAbsoluteXPath();
            }
            else if (s is XAttribute xa)
            {
                name = xa.GetAbsoluteXPath();
            }

            validationErrors.Add(new ValidationError(name, e.Message));
        });

        if (!isValid)
        {
            Debug.WriteLine(string.Join(Environment.NewLine, validationErrors));
            return new ValidationResult
            {
                Errors = validationErrors
                    .GroupBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Select(x => x.Message).ToArray())
            };
        }

        return new ValidationResult();
    }

    private static XmlSchemaSet GetXmlSchemaSet(XmlSerializer serializer)
    {
        XmlUtils.Initialize([typeof(BMEcatXmlSerializer).Assembly, typeof(OpenTransAgreement).Assembly]);

        var schemaSet = new XmlSchemaSet
        {
            XmlResolver = XmlUtils.XmlResolver
        };

        // avoid "has already been declared" error - https://stackoverflow.com/questions/10871182/the-global-attribute-http-www-w3-org-xml-1998-namespacelang-has-already-bee
        schemaSet.ValidationEventHandler += SchemaSet_ValidationEventHandler;

        if (serializer is BMEcatXmlSerializer ser)
        {
            if (ser.XsdUris is not null)
            {
                foreach (var uri in ser.XsdUris)
                {
                    XmlUtils.GetXsd(uri.AbsoluteUri, schemaSet);
                }
            }
        }

        XmlUtils.GetXsd("opentrans_2_1.xsd", schemaSet);

        schemaSet.Compile();

        return schemaSet;
    }

    private static void SchemaSet_ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (!e.Exception.Message.Contains("has already been declared"))
        {
            throw e.Exception;
        }

        // ignore
    }
}
