namespace OpenTransSharp.Xml;

public class OpenTransXmlArrayAttribute : XmlArrayAttribute
{
    public OpenTransXmlArrayAttribute()
    {
        Init();
    }

    public OpenTransXmlArrayAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.opentrans.org/XMLSchema/2.1";
    }
}
