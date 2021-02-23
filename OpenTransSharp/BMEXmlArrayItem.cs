using System;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class BMEXmlArrayItem : XmlArrayItemAttribute
    {
        public BMEXmlArrayItem()
        {
            Init();
        }

        public BMEXmlArrayItem(string elementName) : base(elementName)
        {
            Init();
        }

        public BMEXmlArrayItem(Type type) : base(type)
        {
            Init();
        }

        public BMEXmlArrayItem(string elementName, Type type) : base(elementName, type)
        {
            Init();
        }

        private void Init()
        {
            Namespace = "http://www.bmecat.org/bmecat/2005";
        }
    }
}
