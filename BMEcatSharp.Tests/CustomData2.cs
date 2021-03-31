using System.Xml.Serialization;

namespace BMEcatSharp.Tests
{
    [XmlRoot("UDX.CUSTOM_DATA_2")]
    public class CustomData2
    {
        [XmlText]
        public string Name { get; set; }
    }
}