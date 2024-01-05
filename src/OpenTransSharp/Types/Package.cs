namespace OpenTransSharp;

/// <summary>
/// (Packaging information)<br/>
/// <br/>
/// Informations about the packaging of a good.<br/>
/// It is possible to describe more than one packaging.<br/>
/// The element can be used in a nested way together with the element SUB_PACKAGE to describe e.g.outer and inner packings.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class Package
{
    /// <summary>
    /// <inheritdoc cref="Package"/>
    /// </summary>
    public Package() { }

    /// <summary>
    /// (optional) Package number <br/>
    /// <br/>
    /// Unique package number.<br/>
    /// <br/>
    /// Max length: 50
    /// </summary>
    [OpenTransXmlElement("PACKAGE_ID")]
    public List<string>? Ids { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IdsSpecified => Ids?.Count > 0;

    /// <summary>
    /// (optional) Package description <br/>
    /// <br/>
    /// Textual description of the package.
    /// </summary>
    [OpenTransXmlElement("PACKAGE_DESCR")]
    public List<global::BMEcatSharp.MultiLingualString>? Descriptions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionsSpecified => Descriptions?.Count > 0;

    /// <summary>
    /// (optional) Packing unit code<br/>
    /// <br/>
    /// Code for the packing unit; has to be selected from the list of predefined values.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PACKING_UNIT_CODE")]
    public BMEcatSharp.PackageUnit? PackingUnitCode { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PackingUnitCodeSpecified => PackingUnitCode.HasValue;

    /// <summary>
    /// (optional) Packing unit description <br/>
    /// <br/>
    /// Description of the packing unit, i.e. explaination, additional information, hints etc.
    /// </summary>
    [BMEXmlElement("PACKING_UNIT_DESCR")]
    public List<global::BMEcatSharp.MultiLingualString>? PackingUnitDescriptions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PackingUnitDescriptionsSpecified => PackingUnitDescriptions?.Count > 0;

    /// <summary>
    /// (optional) Number of units per package<br/>
    /// <br/>
    /// Number of order units (ORDER_UNIT) related to a package.
    /// </summary>
    [OpenTransXmlElement("PACKAGE_ORDER_UNIT_QUANTITY")]
    public decimal? OrderUnitQuantity { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OrderUnitQuantitySpecified => OrderUnitQuantity.HasValue;

    /// <summary>
    /// (optional) Number of packages<br/>
    /// <br/>
    /// Number of packages of a particular package type (PACKING_UNIT_CODE).
    /// </summary>
    [OpenTransXmlElement("PACKAGE_QUANTITY")]
    public decimal? Quantity { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool QuantitySpecified => Quantity.HasValue;

    /// <summary>
    /// (optional) Package dimensions<br/>
    /// <br/>
    /// Information on the package dimension from the view of business logistics.<br/>
    /// </summary>
    [OpenTransXmlElement("PACKAGE_DIMENSIONS")]
    public PackageDimensions? Dimensions { get; set; }

    /// <summary>
    /// (optional) Reference to means of transportation<br/>
    /// <br/>
    /// Reference to a unique identifier to means of transportation.<br/>
    /// The element refers to an ID (MEANS_OF_TRANSPORT_ID) in the same document.<br/>
    /// </summary>
    [OpenTransXmlElement("MEANS_OF_TRANSPORT_IDREF")]
    public List<MeansOfTransportIdRef>? MeansOfTransportIdRefs { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool MeansOfTransportIdRefsSpecified => MeansOfTransportIdRefs?.Count > 0;

    /// <summary>
    /// (optional) Sub packages<br/>
    /// <br/>
    /// List of sub-packages of the package.<br/>
    /// Via this element nested package-relations can be modeled.
    /// </summary>
    [OpenTransXmlArray("SUB_PACKAGES")]
    [OpenTransXmlArrayItem("PACKAGE")]
    public List<Package> SubPackages { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SubPackagesSpecified => SubPackages?.Count > 0;
}
