namespace BMEcatSharp.Xml;

public class BMEXmlElementAttribute : XmlElementAttribute
{
    public BMEXmlElementAttribute()
    {
        Init();
    }

    public BMEXmlElementAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    public BMEXmlElementAttribute(Type type) : base(type)
    {
        Init();
    }

    public BMEXmlElementAttribute(string elementName, Type type) : base(elementName, type)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.bmecat.org/bmecat/2005";
    }
}
