using System;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    public class BMEcatXmlSerializerOptions
    {
        public Type[]? IncludeUdxTypes { get; set; }

        public Action<XmlAttributeOverrides>? ConfigureXmlAttributeOverrides { get; set; }
        public Uri[]? XsdUris { get; set; }
    }
}
