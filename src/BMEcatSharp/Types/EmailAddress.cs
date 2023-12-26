using BMEcatSharp.Xml;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

[BMEXmlRoot("EMAIL")]
[EditorBrowsable(EditorBrowsableState.Never)]
public class EmailAddress : EmailComponent
{
    [XmlText]
    public string Value { get; set; }
}
