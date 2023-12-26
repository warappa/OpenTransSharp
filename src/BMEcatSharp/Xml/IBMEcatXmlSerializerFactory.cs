﻿namespace BMEcatSharp.Xml;

public interface IBMEcatXmlSerializerFactory
{
    XmlSerializer Create(Type type);
    XmlSerializer Create<T>();
}
