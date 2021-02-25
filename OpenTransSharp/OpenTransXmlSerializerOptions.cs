using System;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class OpenTransXmlSerializerOptions
    {
        public Type[]? IncludeUdxTypes { get; set; }

        public Action<XmlAttributeOverrides>? ConfigureOverrides = null;
    }
}
