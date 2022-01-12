using BMEcatSharp.Internal;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

[assembly: InternalsVisibleTo("BMEcatSharp.Microsoft.AspNetCore")]
[assembly: InternalsVisibleTo("OpenTransSharp.Microsoft.AspNetCore")]

namespace BMEcatSharp
{
    public static class XmlSerializerExtensions
    {
        public static string Serialize(this XmlSerializer serializer, object obj)
        {
            using var ms = new MemoryStream();

            using var streamWriter = XmlWriter.Create(ms, new XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true
            });
            try
            {
                serializer.Serialize(streamWriter, obj);
            }
            catch (InvalidOperationException exc) when (exc.InnerException?.Message.Contains("XmlInclude") == true)
            {
                throw new InvalidOperationException("A type was not found. Did you include it in BMEcatXmlSerializerOptions.IncludeUdxTypes?", exc);
            }
            ms.Position = 0;
            using var streamReader = new StreamReader(ms);
            return streamReader.ReadToEnd();
        }

        public static object Deserialize(this XmlSerializer serializer, string value)
        {
            using var stringReader = new StringReader(value);
            using var reader = XmlReader.Create(stringReader, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore,
                CloseInput = false,
                XmlResolver = XmlUtils.XmlResolver,
            }, EmbeddedXmlUrlResolver.BaseUri);

            return serializer.Deserialize(reader);
        }

        public static T Deserialize<T>(this XmlSerializer serializer, string value)
        {
            return (T)Deserialize(serializer, value);
        }

        public static T Deserialize<T>(this XmlSerializer serializer, Stream stream)
        {
            using var reader = XmlReader.Create(stream, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore,
                CloseInput = false,
                XmlResolver = XmlUtils.XmlResolver,
            }, EmbeddedXmlUrlResolver.BaseUri);

            return (T)serializer.Deserialize(reader);
        }
    }
}
