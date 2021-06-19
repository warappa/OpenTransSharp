using BMEcatSharp.Internal;
using BMEcatSharp.Validation;
using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BMEcatSharp.Validation
{
    public static class ValidationExtensions
    {
        private static object lockObject = new object();

        private static XmlSchemaSet? cachedSchemaSet;

        public static void EnsureValid(this BMEcatDocument model, XmlSerializer serializer)
        {
            var validationResult = model.Validate(serializer);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public static bool IsValid(this BMEcatDocument model, XmlSerializer serializer)
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

        public static ValidationResult Validate(this BMEcatDocument model, XmlSerializer serializer)
        {
            var validationErrors = new List<ValidationError>();

            var schemaSet = GetXmlSchemaSet(serializer);

            try
            {
                using var ms = new MemoryStream();
                serializer.Serialize(ms, model);
                ms.Position = 0;

                using var reader = new StreamReader(ms);
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
            finally
            {
            }
        }

        private static XmlSchemaSet GetXmlSchemaSet(XmlSerializer serializer)
        {
            if (cachedSchemaSet is not null)
            {
                return cachedSchemaSet;
            }

            lock (lockObject)
            {
                if (cachedSchemaSet is not null)
                {
                    return cachedSchemaSet;
                }

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

                // fix udx support in original bmecat (if not redefined by custom xsds)
                XmlUtils.GetXsd("bmecat_2005_any_udx_extension.xsd", schemaSet);

                schemaSet.Compile();

                cachedSchemaSet = schemaSet;

                return cachedSchemaSet;
            }
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
}
