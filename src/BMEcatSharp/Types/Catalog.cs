namespace BMEcatSharp;

/// <summary>
/// (Catalog information)<br/>
/// <br/>
/// This element services for transferring information on the identification and description of the catalog.<br/>
/// The following elements can be used in the document header for setting default values, which may be replaced by product-specific values on the product level:<br/>
/// <list type="bullet">
/// <item>LANGUAGE (values for the "lang" attribute of language-dependent elements)</item>
/// <item>TERRITORY (multiple)</item>
/// <item>AREA_REFS</item>
/// <item>CURRENCY</item>
/// <item>MIME_ROOT</item>
/// <item>PRICE_FLAG (multiple)</item>
/// <item>PRICE_TYPE</item>
/// <item>PRICE_FACTOR</item>
/// <item>VALID_START_DATE</item>
/// <item>VALID_END_DATE</item>
/// <item>PRODUCT_TYPE</item>
/// <item>PRODUCT_CATEGORY</item>
/// <item>COUNTRY_OF_ORIGIN</item>
/// <item>TIME_SPAN (multiple)</item>
/// <item>LEADTIME</item>
/// <item>TRANSPORT</item>
/// <item>SUPPLIER_IDREF</item>
/// </list><br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class Catalog
{
    /// <summary>
    /// <inheritdoc cref="Catalog"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Catalog()
    {
        Id = null!;
        Version = null!;
    }

    /// <summary>
    /// <inheritdoc cref="Catalog"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="version"></param>
    /// <param name="language"></param>
    public Catalog(string id, Version version, Language language)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or empty.", nameof(id));
        }

        Id = id;
        Version = version ?? throw new ArgumentNullException(nameof(version));
        Languages.Add(language ?? throw new ArgumentNullException(nameof(language)));
    }

    /// <summary>
    /// (required) Languages<br/>
    /// <br/>
    /// Specification of used languages, especially the default language of all language-dependent information.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("LANGUAGE")]
    public List<Language> Languages { get; set; } = new List<Language>();

    /// <summary>
    /// (required) Catalog ID<br/>
    /// <br/>
    /// Unique catalog identification. This ID is usually assigned by the supplier when the catalog is generated and remains unchanged throughout the entire lifecycle of the catalog.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CATALOG_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (required) Catalog version <br/>
    /// <br/>
    /// Version number of the catalog.<br/>
    /// <br/>
    /// May only be reset on the target system in conjunction with a T_NEW_CATALOG transaction and not in the case of updates, see also example(Interaction of various transactions).<br/>
    /// <br/>
    /// Format: "MajorVersion"."MinorVersion" (maximum xxx.yyy)<br/>
    /// <br/>
    /// Example:<br/>
    /// 001.120<br/>
    /// 7.3<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlIgnore]
    public Version Version { get; set; }

    [BMEXmlElement("CATALOG_VERSION")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string? VersionForSerializer
    {
        get => Version?.ToString();
        set
        {
            Version = new Version(value);
        }
    }

    /// <summary>
    /// (optional) Catalog Name<br/>
    /// <br/>
    /// Any name that describes the catalog.<br/>
    /// Example: Fall/Winter 2005/2006<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CATALOG_NAME")]
    public List<MultiLingualString>? Name { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool NameSpecified => Name?.Count > 0;

    /// <summary>
    /// (optional - choice GenerationDate/(deprecated)Date) Generation date<br/>
    /// <br/>
    /// Date of the generation of the catalog document.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("GENERATION_DATE")]
    public DateTime? GenerationDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GenerationDateSpecified => GenerationDate.HasValue;

    /// <summary>
    /// (optional - deprecated - choice GenerationDate/(deprecated)Date) Date<br/>
    /// <br/>
    /// The element is used to precisely define a time.<br/>
    /// It is made up of the three elements date, time and time zone.<br/>
    /// The element DATETIME in the context of CATALOG with the attribute 'generation_date' will be replaced by the element GENERATION_DATE in future versions and will be omitted then.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("The element DATETIME in the context of CATALOG with the attribute 'generation_date' will be replaced by the element GENERATION_DATE in future versions and will be omitted then.")]
    [BMEXmlElement("DATE")]
    public BMEcatDatetime? Date { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
    public bool DateSpecified => Date is object;
#pragma warning restore CS0618 // Type or member is obsolete

    /// <summary>
    /// (optional) Territory<br/>
    /// <br/>
    /// Territory (i.e. country, state, region) coded according to ISO 3166.<br/>
    /// <br/>
    /// The element specifies in which territories (regions, states, countries, continents) the prices are vaild which means that the products from the catalog are available.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TERRITORY")]
    public List<CountryCode>? Territories { get; set; } = new List<CountryCode>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TerritoriesSpecified => Territories?.Count > 0;

    /// <summary>
    /// (optional) Area references<br/>
    /// <br/>
    /// List of references to areas.<br/>
    /// <br/>
    /// Areas, where the prices are valid which means that the products from the catalog are available.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlArray("AREA_REFS")]
    [BMEXmlArrayItem("AREA_IDREF")]
    public List<string>? AreaRefs { get; set; } = new List<string>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreaRefsSpecified => AreaRefs?.Count > 0;

    /// <summary>
    /// (optional) Currency<br/>
    /// <br/>
    /// Provides the currency that is default for all price information in the catalog. If the price of a product has a different currency, or this element is not used, the the currency has to be specified in the PRICE_CURRENCY element for the respective product.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Therefore, the currency must be specified in the catalog header or for each product separately.It is recommended to define a default currency.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CURRENCY")]
    public string? Currency { get; set; }

    /// <summary>
    /// (optional) MIME root directory<br/>
    /// <br/>
    /// A relative directory can be entered here (and/or a URI), i.e. one to which the relative paths in MIME_SOURCE refer.<br/>
    /// <br/>
    /// Max length: 250<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_ROOT")]
    public List<MultiLingualString>? MimeRoot { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool MimeRootSpecified => MimeRoot?.Count > 0;

    /// <summary>
    /// (optional) Price flag<br/>
    /// <br/>
    /// Base of a price (e.g. with/without freight).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRICE_FLAG")]
    public List<PriceFlag>? PriceFlags { get; set; } = new List<PriceFlag>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PriceFlagsSpecified => PriceFlags?.Count > 0;

    /// <summary>
    /// (optional) Price factor<br/>
    /// <br/>
    /// The (discount) factor always multiplied by the price specified in this element in order to determine the end price.<br/>
    /// The value of this element overwrites the default price factor, if such a default has been defined in the context of CATALOG.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRICE_FACTOR")]
    public decimal? PriceFactor { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PriceFactorSpecified => PriceFactor.HasValue;

    /// <summary>
    /// (optional) Valid start date<br/>
    /// <br/>
    /// Date for the beginning of the period of validity.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("VALID_START_DATE")]
    public DateTime? ValidStartDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ValidStartDateSpecified => ValidStartDate.HasValue;

    /// <summary>
    /// (optional) Valid end date<br/>
    /// <br/>
    /// Date for the end of the period of validity.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("VALID_END_DATE")]
    public DateTime? ValidEndDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ValidEndDateSpecified => ValidEndDate.HasValue;

    /// <summary>
    /// (optional) Product type<br/>
    /// <br/>
    /// Characterizes the product with regard to its general type, i.e. being tangible or service.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT_TYPE")]
    public ProductType? ProductType { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ProductTypeSpecified => ProductType != null;

    /// <summary>
    /// (optional) Country of origin.<br/>
    /// <br/>
    /// Contains the country of origin of the product. By using a subdivision code it is possible to reference a region.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("COUNTRY_OF_ORIGIN")]
    public CountryCode? CountryOfOrigin { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CountryOfOriginSpecified => CountryOfOrigin.HasValue;

    /// <summary>
    /// (optional) Delivery time.<br/>
    /// <br/>
    /// Information on the delivery time<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("DELIVERY_TIMES")]
    public List<DeliveryTimes>? DeliveryTimes { get; set; } = new List<DeliveryTimes>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DeliveryTimesSpecified => DeliveryTimes?.Count > 0;

    /// <summary>
    /// (optional) Transport<br/>
    /// <br/>
    /// Information about the terms of transport.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TRANSPORT")]
    public Transport? Transport { get; set; }

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
}
