using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Xml;

public class OpenTransXmlElementAttribute : XmlElementAttribute
{
    public OpenTransXmlElementAttribute()
    {
        Init();
    }

    public OpenTransXmlElementAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    public OpenTransXmlElementAttribute(Type type) : base(type)
    {
        Init();
    }

    public OpenTransXmlElementAttribute(string elementName, Type type) : base(elementName, type)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.opentrans.org/XMLSchema/2.1";
    }
}
