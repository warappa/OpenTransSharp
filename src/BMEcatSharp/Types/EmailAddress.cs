using BMEcatSharp.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    [BMEXmlRoot("EMAIL")]
    public class EmailAddress : EmailComponent
    {
        [XmlText]
        public string Value { get; set; }
    }
}
