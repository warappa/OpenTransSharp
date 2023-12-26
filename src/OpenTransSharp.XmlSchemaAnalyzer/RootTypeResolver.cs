namespace OpenTransSharp.XmlSchemaAnalyzer;

public class RootTypeResolver
{
    public IEnumerable<string> GetRootTypes(XDocument doc)
    {
        var navi = doc.Root!.CreateNavigator();
        var xmlNamespaceManager = new XmlNamespaceManager(navi.NameTable);
        var dict = navi.GetNamespacesInScope(XmlNamespaceScope.All);
        foreach (var pair in dict)
        {
            xmlNamespaceManager.AddNamespace(pair.Key, pair.Value);
        }

        var simpleTypes = doc.XPathSelectElements("//xsd:simpleType", xmlNamespaceManager)
            .Attributes("name")
            .Select(x => x.Value);

        var complexTypes = doc.XPathSelectElements("//xsd:complexType", xmlNamespaceManager)
            .Attributes("name")
            .Select(x => x.Value);

        var elementTypes = doc.XPathSelectElements("//xsd:element", xmlNamespaceManager)
            .Attributes("name")
            .Select(x => x.Value);

        return simpleTypes.Concat(complexTypes).Concat(elementTypes);
    }
}
