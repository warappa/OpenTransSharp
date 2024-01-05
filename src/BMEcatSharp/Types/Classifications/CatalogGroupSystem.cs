namespace BMEcatSharp;

/// <summary>
/// (Catalog group system - deprecated)<br/>
/// <br/>
/// The purpose of a catalog group system is to structure a set of products hierarchically (e.g., division into chapters in printed catalogs, hierarchical browsing in on-line catalogs).<br/>
/// A catalog group system can be constructed from the CATALOG_STRUCTURE elements using the CATALOG_GROUP_SYSTEM element.<br/>
/// Product can then be attached to a catalog group (CATALOG_STRUCTURE) using the PRODUCT_TO_CATALOGGROUP_MAP element (in the context T_NEW_CATALOG) or PRODUCT_TO_CATALOGGROUP_MAP (in the context T_UPDATE_PRODUCTS).<br/>
/// A catalog group system is built starting at the root and working up to its leaves.<br/>
/// The structure is created one layer at a time by defining the required subgroup (subsection) for each catalog group.<br/>
/// In BMEcat however, it is not the relevant subgroups which are specified for each catalog group but rather the other way around: the parent group (element PARENT_ID) belonging to each catalog subgroup is specified instead.<br/>
/// The complete hierarchical catalog group system can be built up in this way.<br/>
/// The order of CATALOG_STRUCTURE elements is irrelevant.<br/>
/// Furthermore, not every branch of the catalog group system needs necessarily hang as low as all the others, i.e. the tree structure does not have to be balanced.<br/>
/// <br/>
/// This element will not be used in the future.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
//[Obsolete("This element will not be used in the future.")]
public class CatalogGroupSystem
{
    /// <summary>
    /// <inheritdoc cref="CatalogGroupSystem"/>
    /// </summary>
    public CatalogGroupSystem() { }

    /// <summary>
    /// (optional - deprecated) Catalog group system ID<br/>
    /// <br/>
    /// Identification of the catalog group system.<br/>
    /// The supplier must allocate a unique identification to his catalog group system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("GROUP_SYSTEM_ID")]
    public string? Id { get; set; }

    /// <summary>
    /// (optional - deprecated) Catalog group system name<br/>
    /// <br/>
    /// Name of the catalog group system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("GROUP_SYSTEM_NAME")]
    public List<MultiLingualString>? Name { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool NameSpecified => Name?.Count > 0;

    /// <summary>
    /// (required - deprecated) Catalog structure element<br/>
    /// <br/>
    /// Information on a catalog group.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CATALOG_STRUCTURE")]
    public List<CatalogStructure>? CatalogStructures { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CatalogStructuresSpecified => CatalogStructures?.Count > 0;

    /// <summary>
    /// (optional - deprecated) Group system description<br/>
    /// <br/>
    /// Description of the catalog group system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("GROUP_SYSTEM_DESCRIPTION")]
    public List<MultiLingualString>? Description { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionSpecified => Description?.Count > 0;
}
