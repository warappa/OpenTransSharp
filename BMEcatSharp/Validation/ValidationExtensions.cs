using BMEcatSharp.Internal;
using BMEcatSharp.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BMEcatSharp.Validation
{
    public static class ValidationExtensions
    {
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
            var validationErrors = new List<string>();

            var schemaSet = new XmlSchemaSet
            {
                XmlResolver = XmlUtils.XmlResolver
            };

            try
            {
                // avoid "has already been declared" error - https://stackoverflow.com/questions/10871182/the-global-attribute-http-www-w3-org-xml-1998-namespacelang-has-already-bee
                schemaSet.ValidationEventHandler += SchemaSet_ValidationEventHandler;

                XmlUtils.GetEmbeddedXsd("file://fake/bmecat_2005.xsd", schemaSet);
                // fix udx support in original bmecat
                XmlUtils.GetEmbeddedXsd("file://fake/bmecat_2005_any_udx_extension.xsd", schemaSet);

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

                    validationErrors.Add($"{name}: {e.Message}");
                });

                if (!isValid)
                {
                    Debug.WriteLine(string.Join(Environment.NewLine, validationErrors));
                    return new ValidationResult
                    {
                        Errors = validationErrors.ToArray()
                    };
                }

                return new ValidationResult();
            }
            finally
            {
                schemaSet.ValidationEventHandler -= SchemaSet_ValidationEventHandler;
            }
        }

        private static void SchemaSet_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (!e.Exception.Message.Contains("has already been declared"))
            {
                throw e.Exception;
            }

            Debug.WriteLine("Error: " + e.Exception.Message);
        }
    }
}
