namespace OpenTransSharp.Xml;

public class OpenTransXmlRootAttribute : XmlRootAttribute
{
    public OpenTransXmlRootAttribute()
    {
        Init();
    }

    public OpenTransXmlRootAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.opentrans.org/XMLSchema/2.1";
    }
}
