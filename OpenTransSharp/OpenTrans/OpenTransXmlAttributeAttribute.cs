using System;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class OpenTransXmlAttributeAttribute : XmlAttributeAttribute
    {
        public OpenTransXmlAttributeAttribute()
        {
            Init();
        }

        public OpenTransXmlAttributeAttribute(string attributeName) : base(attributeName)
        {
            Init();
        }

        public OpenTransXmlAttributeAttribute(Type type) : base(type)
        {
            Init();
        }

        public OpenTransXmlAttributeAttribute(string attributeName, Type type) : base(attributeName, type)
        {
            Init();
        }

        private void Init()
        {
            Namespace = "http://www.opentrans.org/XMLSchema/2.1";
        }
    }
}
