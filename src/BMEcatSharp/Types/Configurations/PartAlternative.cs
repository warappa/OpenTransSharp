namespace BMEcatSharp;

/// <summary>
/// (Variant componetnts)<br/>
/// <br/>
/// This element contains information about the componente, e.g. reference to the product and implications to the order code and configuration price.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class PartAlternative
{
    /// <summary>
    /// <inheritdoc cref="PartAlternative"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PartAlternative()
    {
        SupplierPIdRef = null!;
    }

    public PartAlternative(string supplierPIdRef)
    {
        if (string.IsNullOrWhiteSpace(supplierPIdRef))
        {
            throw new ArgumentException($"'{nameof(supplierPIdRef)}' cannot be null or whitespace.", nameof(supplierPIdRef));
        }

        SupplierPIdRef = supplierPIdRef;
    }

    /// <summary>
    /// (required) Reference to a product number<br/>
    /// <br/>
    /// This element provides a reference to a product number of the supplier.<br/>
    /// It contains the unique identifier (SUPPLIER_PID) that is defined in the document.<br/>
    /// In this context the element is used to reference the product number of the content.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SUPPLIER_PIDREF")]
    public string SupplierPIdRef { get; set; }

    /// <summary>
    /// (optional) Reference to supplier<br/>
    /// <br/>
    /// Reference to the supplier.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SUPPLIER_IDREF")]
    public SupplierIdRef? SupplierIdRef { get; set; }

    /// <summary>
    /// (optional) Product order<br/>
    /// <br/>
    /// Order in which the product has to be presented in the target system.<br/>
    /// In list presentation of articles, the articles appear in ascending order (first article corresponds to lowest number).<br/>
    /// When all products of a catalog group are to be presented, sorting should comply with PRODUCT_TO_CATALOGGROUP_MAP_ORDER.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT_ORDER")]
    public int? ProductOrder { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ProductOrderSpecified => ProductOrder.HasValue;

    /// <summary>
    /// (optional) Default flag<br/>
    /// <br/>
    /// Sets the default value of a list of values.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlIgnore]
    public bool? DefaultFlag { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [BMEXmlElement("DEFAULT_FLAG")]
    public string? DefaultFlagForSerializer { get => DefaultFlag is null ? null : DefaultFlag == true ? "true" : "false"; set => DefaultFlag = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DefaultFlagForSerializerSpecified => DefaultFlag == true;

    /// <summary>
    /// (optional) Order number extension<br/>
    /// <br/>
    /// In order to generate the order number of configurated products, this element can be used for coding the result of each configuration step; the unique code is added to the base order number.By adding these codes for each configuration step a unique order number is created.<br/>
    /// <br/>
    /// If the configuration requires more than one configuration step, it should be guaranted that the extensions can be separated. A solution is to standardize the length of each added code; for instance, adding 3 characters, e.g., "003"="black".<br/>
    /// <br/>
    /// Another solution is to separate the codes by a hyphen (e.g., "-red").<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CONFIG_CODE")]
    public string? ConfigurationCode { get; set; }

    /// <summary>
    /// (optional) Price details<br/>
    /// <br/>
    /// Price information for the product.<br/>
    /// A detailed description of the element is contained in a separate document which can be downloaded from the BMEcat website www.bmecat.org.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT_PRICE_DETAILS")]
    public ProductPriceDetails? ProductPriceDetails { get; set; }
}
