using System;
using System.Xml.Serialization;

namespace BMEcatSharp.Xml;

public class BMEcatXmlSerializer : XmlSerializer
{
    public BMEcatXmlSerializer(Type type) : base(type)
    {
    }

    public BMEcatXmlSerializer(XmlTypeMapping xmlTypeMapping) : base(xmlTypeMapping)
    {
    }

    public BMEcatXmlSerializer(Type type, string defaultNamespace) : base(type, defaultNamespace)
    {
    }

    public BMEcatXmlSerializer(Type type, Type[] extraTypes) : base(type, extraTypes)
    {
    }

    public BMEcatXmlSerializer(Type type, XmlAttributeOverrides overrides) : base(type, overrides)
    {
    }

    public BMEcatXmlSerializer(Type type, XmlRootAttribute root) : base(type, root)
    {
    }

    public BMEcatXmlSerializer(Type type, XmlAttributeOverrides overrides, Type[] extraTypes, XmlRootAttribute root, string defaultNamespace) : base(type, overrides, extraTypes, root, defaultNamespace)
    {
    }

    public BMEcatXmlSerializer(Type type, XmlAttributeOverrides overrides, Type[] extraTypes, XmlRootAttribute root, string defaultNamespace, string location) : base(type, overrides, extraTypes, root, defaultNamespace, location)
    {
    }

    protected BMEcatXmlSerializer()
    {
    }

    public Uri[]? XsdUris { get; set; }
}
