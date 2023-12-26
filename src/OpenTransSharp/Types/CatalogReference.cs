namespace OpenTransSharp;

/// <summary>
/// (Reference to an (electronic) product catalog)<br/>
/// <br/>
/// In the CATALOG_REFERENCE element reference is made to an (electronic) product catalog which serves as a quotation for the order.<br/>
/// This element can also be used as a reference to a price list.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class CatalogReference
{
    /// <summary>
    /// <inheritdoc cref="CatalogReference"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public CatalogReference()
    {
        Id = null!;
        Version = null!;
    }

    /// <summary>
    /// <inheritdoc cref="CatalogReference"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="version"></param>
    public CatalogReference(string id, Version version)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        Id = id;
        Version = version ?? throw new ArgumentNullException(nameof(version));
    }

    /// <summary>
    /// (required) Catalog ID<br/>
    /// <br/>
    /// Unique catalog identification.<br/>
    /// This ID is usually assigned by the supplier when the catalog is generated and remains unchanged throughout the entire lifecycle of the catalog.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CATALOG_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (required) Catalog version<br/>
    /// <br/>
    /// Version number of the catalog.<br/>
    /// May only be reset on the target system in conjunction with a T_NEW_CATALOG transaction and not in the case of updates, see also example (Interaction of various transactions).<br/>
    /// <br/>
    /// Format: "MajorVersion"."MinorVersion" (maximum xxx.yyy)<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlIgnore]
    public Version Version { get; set; }
    [BMEXmlElement("CATALOG_VERSION")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string VersionForSerializer
    {
        get => Version.ToString();
        set => Version = new Version(value);
    }

    /// <summary>
    /// (optional) Catalog name<br/>
    /// <br/>
    /// Any name that describes the catalog.<br/>
    /// <br/>
    /// Example: Fall/Winter 2005/2006<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CATALOG_NAME")]
    public global::BMEcatSharp.MultiLingualString? Name { get; set; }
}
