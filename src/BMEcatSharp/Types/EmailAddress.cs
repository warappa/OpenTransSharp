namespace BMEcatSharp;

[BMEXmlRoot("EMAIL")]
[EditorBrowsable(EditorBrowsableState.Never)]
public class EmailAddress : EmailComponent
{
    [XmlText]
    public string Value { get; set; }
}
