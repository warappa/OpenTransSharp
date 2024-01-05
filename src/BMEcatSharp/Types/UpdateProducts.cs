namespace BMEcatSharp;

/// <summary>
/// (Transaction area 'product update')<br/>
/// <br/>
/// This transaction updates product data.<br/>
/// The transferred products are either added to/deleted from the target system or the complete product data record is replaced by a new one.<br/>
/// A product identification (see attribute "PRODUCT --&gt; mode in context T_UPDATE_PRICES" in PRODUCT in context T_UPDATE_PRICES (in context T_UPDATE_PRODUCTS)) indicates whether the product should be added, deleted or modified.<br/>
/// <br/>
/// The product is always replaced completely, it is not possible to change individual data fields of a product.<br/>
/// <br/>
/// In this transaction, only the transfer of product data, but not of classification systemsis possible.<br/>
/// <br/>
/// The transferred CATALOG_ID of the relevant supplier (SUPPLIER_NAME) and the CATALOG_VERSION to which it belongs must already be present in the target system.<br/>
/// The attribute "T_UPDATE_PRODUCTS --&gt; prev_version" must be set to 0 with the first transaction type after T_NEW_CATALOG (T_UPDATE_PRODUCTS, T_UPDATE_PRICES).<br/>
/// Eventually, it is increased by 1 with each transaction of this sort.<br/>
/// See also Example (Combination of different transactions)".<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class UpdateProducts
{
    /// <summary>
    /// <inheritdoc cref="UpdateProducts"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public UpdateProducts() { }

    /// <summary>
    /// <inheritdoc cref="UpdateProducts"/>
    /// </summary>
    /// <param name="previousVersion"></param>
    /// <param name="products"></param>
    public UpdateProducts(int previousVersion, IEnumerable<UpdateProductsProduct> products)
    {
        if (products is null)
        {
            throw new ArgumentNullException(nameof(products));
        }

        PreviousVersion = previousVersion;
        Products = products.ToList();
    }

    /// <summary>
    /// (required) No of previous updates<br/>
    /// <br/>
    /// This attribute contains the number of previous updates or the number of the transferred updates (not the last version number).<br/>
    /// Counting begins at <b>0</b> after each T_NEW_CATALOG within the same version.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlAttribute("prev_version")]
    public int PreviousVersion { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PreviousVersionSpecified => PreviousVersion != 0;

    /// <summary>
    /// (optional) Dictionary of formulas<br/>
    /// <br/>
    /// List of formulas that are specified in the document header.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlArray("FORMULAS")]
    [BMEXmlArrayItem("FORMULA")]
    public List<Formula> Formulas { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool FormulasSpecified => Formulas?.Count > 0;

    /// <summary>
    /// (required) Product<br/>
    /// <br/>
    /// Information about a product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT")]
    public List<UpdateProductsProduct> Products { get; set; } = [];

    /// <summary>
    /// (optional - deprecated - use with Product) Mapping to catalog group<br/>
    /// <br/>
    /// Mapping of the product to a group of a catalog group system Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.<br/>
    /// The mapping of products to group is realized only with the element REFERENCE_FEATURE_GROUP_ID then.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.")]
    [BMEXmlElement("PRODUCT_TO_CATALOGGROUP_MAP")]
    public List<UpdateProductsProductToCataloggroupMap>? ProductToCataloggroupMap { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
    public bool ProductToCataloggroupMapSpecified => ProductToCataloggroupMap?.Count > 0;
#pragma warning restore CS0618 // Type or member is obsolete

    /// <summary>
    /// (optional - deprecated - choice Product/Article) Article<br/>
    /// <br/>
    /// Information about a product.<br/>
    /// This element has been replaced by the PRODUCT in context T_NEW_CATALOG element.<br/>
    /// It still may be used in this BMEcat version, though it will become obsolete in the next version.<br/>
    /// The element ARTICLE in context T_NEW_CATALOG will be replaced by the element PRODUCT in context T_NEW_CATALOG in future versions and will be omitted then.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("This element has been replaced by the PRODUCT in context T_NEW_CATALOG element.")]
    [BMEXmlElement("ARTICLE")]
    public List<UpdateProductsArticle>? Articles { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
    public bool ArticlesSpecified => Articles?.Count > 0;
#pragma warning restore CS0618 // Type or member is obsolete

    /// <summary>
    /// (optional - deprecated - use with (deprecated) <see cref="Articles"/>) Assigning products to catalog groups<br/>
    /// <br/>
    /// This element is used to assign a product to a group of a catalog group system.<br/>
    /// This element has been replaced by the new PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG element.<br/>
    /// The element can still be used in the current BMEcat version, but it will be not available in the next version.<br/>
    /// Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element ARTICLE_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.The mapping of products to group is realized only with the element REFERENCE_FEATURE_GROUP_ID then.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element ARTICLE_TO_CATALOGGROUP_MAPin context T_NEW_CATALOG will be omitted then.")]
    [BMEXmlElement("Article_TO_CATALOGGROUP_MAP")]
    public List<UpdateProductsArticleToCataloggroupMap>? ArticleToCataloggroupMap { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
    public bool ArticleToCataloggroupMapSpecified => ArticleToCataloggroupMap?.Count > 0;
#pragma warning restore CS0618 // Type or member is obsolete
}
