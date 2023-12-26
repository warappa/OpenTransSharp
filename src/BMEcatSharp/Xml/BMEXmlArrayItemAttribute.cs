namespace BMEcatSharp.Xml;

public class BMEXmlArrayItemAttribute : XmlArrayItemAttribute
{
    public BMEXmlArrayItemAttribute()
    {
        Init();
    }

    public BMEXmlArrayItemAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    public BMEXmlArrayItemAttribute(Type type) : base(type)
    {
        Init();
    }

    public BMEXmlArrayItemAttribute(string elementName, Type type) : base(elementName, type)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.bmecat.org/bmecat/2005";
    }
}
