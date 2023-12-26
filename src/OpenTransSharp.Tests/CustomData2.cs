using System.Xml.Serialization;

namespace OpenTransSharp.Tests;

[XmlRoot("UDX.ORGANIZATION.CUSTOM_DATA_2")]
public class CustomData2
{
    [XmlText]
    public string Name { get; set; }
}
