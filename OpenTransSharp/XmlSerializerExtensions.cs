﻿using System.IO;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public static class XmlSerializerExtensions
    {
        public static string Serialize(this XmlSerializer serializer, object obj)
        {
            using var ms = new MemoryStream();

            using var streamWriter = System.Xml.XmlWriter.Create(ms, new System.Xml.XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true
            });
            serializer.Serialize(streamWriter, obj);
            ms.Position = 0;
            using var streamReader = new StreamReader(ms);
            return streamReader.ReadToEnd();
        }

        public static object Deserialize(this XmlSerializer serializer, string value)
        {
            using var reader = new StringReader(value);
            return serializer.Deserialize(reader);
        }

        public static T Deserialize<T>(this XmlSerializer serializer, string value)
        {
            return (T)serializer.Deserialize(value);
        }
    }
}
