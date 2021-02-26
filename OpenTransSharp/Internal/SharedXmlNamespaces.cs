using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp.Internal
{
    internal class SharedXmlNamespaces
    {
        internal static XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces(new[]
        {
            new XmlQualifiedName("", "http://www.opentrans.org/XMLSchema/2.1"),
            new XmlQualifiedName("bmecat", "http://www.bmecat.org/bmecat/2005"),
            new XmlQualifiedName("xmime","http://www.w3.org/2005/05/xmlmime"),
            new XmlQualifiedName("xsig", "http://www.w3.org/2000/09/xmldsig#"),
            new XmlQualifiedName("xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            new XmlQualifiedName("xsd", "http://www.w3.org/2001/XMLSchema")
        });

        internal static XmlSerializerNamespaces XmlnsBMEcat = new XmlSerializerNamespaces(new[]
        {
            new XmlQualifiedName("", "http://www.bmecat.org/bmecat/2005"),
            new XmlQualifiedName("xmime","http://www.w3.org/2005/05/xmlmime"),
            new XmlQualifiedName("xsig", "http://www.w3.org/2000/09/xmldsig#"),
            new XmlQualifiedName("xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            new XmlQualifiedName("xsd", "http://www.w3.org/2001/XMLSchema")
        });
    }
}
