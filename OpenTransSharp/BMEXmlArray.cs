using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class BMEXmlArray : XmlArrayAttribute
    {
        public BMEXmlArray()
        {
            Init();
        }

        public BMEXmlArray(string elementName) : base(elementName)
        {
            Init();
        }

        private void Init()
        {
            Namespace = "http://www.bmecat.org/bmecat/2005";
        }
    }
}
