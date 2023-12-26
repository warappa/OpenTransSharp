using System.Xml.Serialization;

namespace BMEcatSharp.Xml;

public class BMEXmlArrayAttribute : XmlArrayAttribute
{
    public BMEXmlArrayAttribute()
    {
        Init();
    }

    public BMEXmlArrayAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.bmecat.org/bmecat/2005";
    }
}
