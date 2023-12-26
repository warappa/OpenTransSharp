using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Xml;

public class OpenTransXmlArrayItemAttribute : XmlArrayItemAttribute
{
    public OpenTransXmlArrayItemAttribute()
    {
        Init();
    }

    public OpenTransXmlArrayItemAttribute(string elementName) : base(elementName)
    {
        Init();
    }

    public OpenTransXmlArrayItemAttribute(Type type) : base(type)
    {
        Init();
    }

    public OpenTransXmlArrayItemAttribute(string elementName, Type type) : base(elementName, type)
    {
        Init();
    }

    private void Init()
    {
        Namespace = "http://www.opentrans.org/XMLSchema/2.1";
    }
}
