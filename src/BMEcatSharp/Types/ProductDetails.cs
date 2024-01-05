namespace BMEcatSharp;

/// <summary>
/// (Product details)<br/>
/// <br/>
/// This element contains information for identifying and describing the product.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class ProductDetails
{
    /// <summary>
    /// <inheritdoc cref="ProductDetails"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProductDetails() { }

    /// <summary>
    /// <inheritdoc cref="ProductDetails"/>
    /// </summary>
    /// <param name="descriptionShort"></param>
    public ProductDetails(IEnumerable<MultiLingualString> descriptionShort)
    {
        if (descriptionShort is null)
        {
            throw new ArgumentNullException(nameof(descriptionShort));
        }

        DescriptionShort = descriptionShort.ToList();
    }

    /// <summary>
    /// (required) Short description<br/>
    /// <br/>
    /// This element contains the short description of the product.<br/>
    /// In general, the description should be short and, whithin the first 40 characters, unique and meaningful, because many software systems can only interpret these 40 characters(i.e.SAP-OCI, SAP R/3).<br/>
    /// <br/>
    /// Detailed descriptions are beneficial to product search, especially if many products are quite similar and differ only in specific details.<br/>
    /// In these cases, product search returns a list of products from which the right product can easily be determined.<br/>
    /// <br/>
    /// Abbreviations of essential product characteristics should be avoided (e.g., bw for black and white). However, abbreviations of organisations and standards can be used (e.g., ISO, VDE).
    /// </summary>
    [BMEXmlElement("DESCRIPTION_SHORT")]
    public List<MultiLingualString> DescriptionShort { get; set; } = [];

    /// <summary>
    /// (optional) Long description<br/>
    /// <br/>
    /// This element contains the long description of the product.<br/>
    /// <br/>
    /// Format: The following HTML tags are supported: &lt;b&gt; for bold, &lt;i&gt; for italic, &lt;p&gt; for paragraphs, &lt;br&gt; for line break and&lt;ul&gt;/&lt;li&gt; for lists.<br/>
    /// <br/>
    /// In order to transfer these, the characters '&lt;' and '&gt;' must be enclosed in quotation marks, or the BMEcat DTD will not be accepted by the XML parser (see also chapter Character encoding in XML).<br/>
    /// Example: '&lt;' = &amp;lt; or '&gt;' = &amp;gt;
    /// </summary>
    [BMEXmlElement("DESCRIPTION_LONG")]
    public List<MultiLingualString>? DescriptionLong { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionLongSpecified => DescriptionLong?.Count > 0;

    /// <summary>
    /// (optional - choice InternationPids/(obsolete)Ean) International product number<br/>
    /// <br/>
    /// Indicates an international product number (e.g., EAN).<br/>
    /// The underlying standard respectively organisation is given in the 'type' attribute.
    /// </summary>
    [BMEXmlElement("INTERNATIONAL_PID")]
    public List<InternationalPid>? InternationalPids { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool InternationalPidsSpecified => InternationalPids?.Count > 0;

    /// <summary>
    /// (optional - choice InternationPids/(obsolete)Ean) EAN<br/>
    /// <br/>
    /// This element contains the European Article Number (http://www.ean-int.org).<br/>
    /// The element EAN will be replaced by the element INTERNATIONAL_PID with the attribute type = ean in future versions and will be omitted then.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("The element EAN will be replaced by the element INTERNATIONAL_PID with the attribute type = ean in future versions and will be omitted then.")]
    [BMEXmlElement("EAN")]
    public string? Ean { get; set; }

    /// <summary>
    /// (optional) Alternative product number<br/>
    /// <br/>
    /// This element contains the alternative (internal) product number of the supplier.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SUPPLIER_ALT_PID")]
    public string? SupplierAlternativePid { get; set; }

    /// <summary>
    /// (optional) Product ID of the buying company<br/>
    /// <br/>
    /// Product number used by the buying firm. The "type" attribute specifies the type of ID.<br/>
    /// If the element is used multiple, the values of the attribute "type" must differ.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("BUYER_PID")]
    public List<BuyerPid>? BuyerPids { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool BuyerPidsSpecified => BuyerPids?.Count > 0;

    /// <summary>
    /// (optional) Product ID of the manufacturer<br/>
    /// <br/>
    /// Product ID of the manufacturer.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MANUFACTURER_PID")]
    public string? ManufacturerPid { get; set; }

    /// <summary>
    /// (optional) Reference to the manufacturer<br/>
    /// <br/>
    /// This element provides a reference to the manufacturer.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document(element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MANUFACTURER_IDREF")]
    public ManufacturerIdRef? ManufacturerIdRef { get; set; }

    /// <summary>
    /// (optional) Name of manufacturer<br/>
    /// <br/>
    /// This element contains the name of the manufacturer of the product.<br/>
    /// The element MANUFACTURER_NAME will be replaced by the element MANUFACTURER_IDREF together with the element PARTY in future versions and will be omitted then.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("The element MANUFACTURER_NAME will be replaced by the element MANUFACTURER_IDREF together with the element PARTY in future versions and will be omitted then.")]
    [BMEXmlElement("MANUFACTURER_NAME")]
    public string? ManufacturerName { get; set; }

    /// <summary>
    /// (optional) Manufacturer type description<br/>
    /// <br/>
    /// The manufacturer’s type description is a name for the product which may, in certain circumstances, be more widely-known than the correct product name.<br/>
    /// When a manufacturer’s type description is specified, the name of the manufacturer must also be specified (MANUFACTURER_NAME).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MANUFACTURER_TYPE_DESCR")]
    public List<MultiLingualString>? ManufacturerTypeDescription { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ManufacturerTypeDescriptionSpecified => ManufacturerTypeDescription?.Count > 0;

    /// <summary>
    /// (optional) ERP material group of the buying company<br/>
    /// <br/>
    /// Specifies the material group or material class of the article in the ERP system of the buying company.<br/>
    /// Value range: Depends on buying firm’s ERP(BUYER)<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ERP_GROUP_BUYER")]
    public string? ErpGroupBuyer { get; set; }

    /// <summary>
    /// (optional) ERP material group of the supplier<br/>
    /// <br/>
    /// Specifices the material group or material class of the article in the supplier’s ERP system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ERP_GROUP_SUPPLIER")]
    public string? ErpGroupSupplier { get; set; }

    /// <summary>
    /// (optional) Scheduled delivery time<br/>
    /// <br/>
    /// This element containts the time in working days needed by the supplier to deliver the product.<br/>
    /// The element DELIVERY_TIME will be replaced by the element LEADTIME in future versions and will be omitted then.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("The element DELIVERY_TIME will be replaced by the element LEADTIME in future versions and will be omitted then.")]
    [BMEXmlElement("DELIVERY_TIME")]
    public decimal? DeliveryTime { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
    public bool DeliveryTimeSpecified => DeliveryTime.HasValue;
#pragma warning restore CS0618 // Type or member is obsolete

    /// <summary>
    /// (optional) Special treatment class<br/>
    /// <br/>
    /// Additional product classification used for hazardous goods or substances, primary pharmaceutical products, radioactive measuring equipment, etc.<br/>
    /// The "type" attribute specifies the dangerous goods classification scheme.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SPECIAL_TREATMENT_CLASS")]
    public List<SpecialTreatmentClass>? SpecialTreatmentClasses { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SpecialTreatmentClassesSpecified => SpecialTreatmentClasses?.Count > 0;

    /// <summary>
    /// (optional) Keyword<br/>
    /// <br/>
    /// Keyword that supports product search in target systems.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("KEYWORD")]
    public List<MultiLingualString>? Keywords { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool KeywordsSpecified => Keywords?.Count > 0;

    /// <summary>
    /// (optional) Remark<br/>
    /// <br/>
    /// Remark related to a business document.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("REMARK")]
    public List<MultiLingualString>? Remarks { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RemarksSpecified => Remarks?.Count > 0;

    /// <summary>
    /// (optional) Segment<br/>
    /// <br/>
    /// Catalog segment ('generic product group') to which the product belongs.<br/>
    /// Example: Plumbing supplies, Electrical supplies.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SEGMENT")]
    public List<MultiLingualString>? Segment { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SegmentSpecified => Segment?.Count > 0;

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
    public int? Order { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OrderSpecified => Order.HasValue;

    /// <summary>
    /// (optional) Special product status<br/>
    /// <br/>
    /// Theis element classifies a product in terms of its special characteristics.<br/>
    /// The status type is specified by the 'type' attribute.<br/>
    /// The value of the element reflects the text description of the special characteristics.<br/>
    /// If a product cannot be mapped to any of the predefined status types, "others" must be used.<br/>
    /// User-defined status types are not permitted.<br/>
    /// <br/>
    /// It is therefore possible, for example, to identify a product as a special offer or a new product and to comment on it.<br/>
    /// It is intended that the target system should highlight products identified in this way (e.g., graphic identification, including in a special catalog rubric or by search-and-find process which support this attribute).<br/>
    /// <br/>
    /// For each product multiple special status can be defined.<br/>
    /// The individual types may not appear more than once, however.<br/>
    /// The order in which the elements appear is not relevant.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT_STATUS")]
    public List<ProductStatus>? Statuses { get; set; } = [];
    public bool StatusesSpecified => Statuses?.Count > 0;

    /// <summary>
    /// (optional) International delivery restrictions<br/>
    /// <br/>
    /// Details of international restrictions, e.g. compulsory import / export authorization.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("INTERNALTIONAL_RESTRICTIONS")]
    public List<InternationalRestriction> InternationalRestrictions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool InternationalRestrictionsSpecified => InternationalRestrictions?.Count > 0;

    /// <summary>
    /// (optional) Accounting information<br/>
    /// <br/>
    /// Information on the accounting treatment of costs incurred by the buyer as a result of the order.<br/>
    /// This information is supplied by the buyer to allow the supplier to include it in the following invoice, thereby making invoice verification by the buyer easier.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ACCOUNTING_INFO")]
    public AccountingInformation? AccountingInformation { get; set; }

    /// <summary>
    /// (optional) Skeleton agreement reference<br/>
    /// <br/>
    /// Reference to a skeleton agreement (AGREEMENT), which has been named in the document header.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AGREEMENT_REF")]
    public List<AgreementReference>? AgreementRefs { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AgreementRefsSpecified => AgreementRefs?.Count > 0;

    /// <summary>
    /// (optional) Product type<br/>
    /// <br/>
    /// Characterizes the product with regard to its general type, i.e. being tangible or service.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT_TYPE")]
    public List<ProductType>? Types { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TypesSpecified => Types?.Count > 0;

    /// <summary>
    /// (optional) Product category<br/>
    /// <br/>
    /// Characterises the product based on its usage.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT_CATEGORY")]
    public ProductCategory? Category { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CategorySpecified => Category.HasValue;
}
