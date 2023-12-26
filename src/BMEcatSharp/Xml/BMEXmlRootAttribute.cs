using System.Xml.Serialization;

namespace BMEcatSharp.Xml;

public class BMEXmlRootAttribute : XmlRootAttribute
{
    public BMEXmlRootAttribute()
    {
        Init();
    }

    public BMEXmlRootAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.bmecat.org/bmecat/2005";
    }
}
