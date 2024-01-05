namespace BMEcatSharp;

public class BMEcatXmlSerializerOptions
{
    public Type[]? IncludeUdxTypes { get; set; }

    public Action<XmlAttributeOverrides>? ConfigureXmlAttributeOverrides { get; set; }
    public Uri[]? XsdUris { get; set; }
    public List<string> SupportedEncodings { get; set; } = ["utf-8"];
    public List<string> SupportedMediaTypes { get; set; } = ["application/xml"];
}
