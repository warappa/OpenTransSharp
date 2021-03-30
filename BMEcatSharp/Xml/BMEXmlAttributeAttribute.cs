using System;
using System.Xml.Serialization;

namespace BMEcatSharp.Xml
{
    public class BMEXmlAttributeAttribute : XmlAttributeAttribute
    {
        public BMEXmlAttributeAttribute()
        {
            Init();
        }

        public BMEXmlAttributeAttribute(string attributeName) : base(attributeName)
        {
            Init();
        }

        public BMEXmlAttributeAttribute(Type type) : base(type)
        {
            Init();
        }

        public BMEXmlAttributeAttribute(string attributeName, Type type) : base(attributeName, type)
        {
            Init();
        }

        private void Init()
        {
            Namespace = "http://www.bmecat.org/bmecat/2005";
        }
    }
}
