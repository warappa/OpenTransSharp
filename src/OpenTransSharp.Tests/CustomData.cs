namespace OpenTransSharp.Tests;

[XmlRoot("UDX.ORGANIZATION.CUSTOM_DATA")]
public class CustomData
{
    [XmlElement("UDX.ORGANIZATION.CUSTOM_DATA.NAME")]
    public List<string> Names { get; set; } = new List<string>();
}
