using System;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public interface IOpenTransXmlSerializerFactory
    {
        XmlSerializer Create(Type type);
        XmlSerializer Create<T>();
    }
}
