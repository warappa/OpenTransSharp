using System.Xml.Serialization;

namespace BMEcatSharp.Samples.AspNetCore;

[XmlRoot("UDX.ORGANIZATION.CUSTOM_DATA_2")]
public class CustomData2
{
    [XmlText]
    public string? Name { get; set; }
}
