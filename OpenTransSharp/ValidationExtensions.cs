using OpenTransSharp.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this IValidatable model, XmlSerializer serializer)
        {
            try
            {
                Validate(model, serializer);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void Validate(IValidatable model, XmlSerializer serializer)
        {
            var validationErrors = new List<string>();
            var schemaSet = new XmlSchemaSet
            {
                XmlResolver = XmlUtils.XmlResolver
            };

            using var opentrans = XmlUtils.GetEmbeddedXsd("http://www.opentrans.org/XMLSchema/2.1/opentrans_2_1.xsd", schemaSet);
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
                var messages = string.Join(Environment.NewLine, validationErrors);
                Debug.WriteLine(messages);
                throw new InvalidDataException($"Invalid OpenTrans/BMEcat document:{Environment.NewLine}{messages}");
            }
        }
    }
}
