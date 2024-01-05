namespace OpenTransSharp;

/// <summary>
/// (Buyer information)<br/>
/// <br/>
/// In the element ORDER_INFO administrative information on this order is summarized.
/// </summary>
public class OrderInformation
{
    /// <summary>
    /// <inheritdoc cref="OrderInformation"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderInformation()
    {
        Id = null!;
        Currency = null!;
    }

    /// <summary>
    /// <inheritdoc cref="OrderInformation"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="date"></param>
    /// <param name="parties"></param>
    /// <param name="orderPartiesReference"></param>
    /// <param name="currency"></param>
    public OrderInformation(string id, DateTime date, IEnumerable<OpenTransParty> parties,
        OrderPartiesReference orderPartiesReference, string currency)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        if (parties is null)
        {
            throw new ArgumentNullException(nameof(parties));
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException($"'{nameof(currency)}' cannot be null or whitespace.", nameof(currency));
        }

        Id = id;
        Date = date;
        OrderPartiesReference = orderPartiesReference ?? throw new ArgumentNullException(nameof(orderPartiesReference));
        Currency = currency;
        Parties = parties.ToList();
    }

    /// <summary>
    /// (required) Order number of buyer<br/>
    /// <br/>
    /// Unique order number of the buyer.
    /// </summary>
    [XmlElement("ORDER_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (required) Date of the order<br/>
    /// <br/>
    /// Date of the order.
    /// </summary>
    [XmlElement("ORDER_DATE")]
    public DateTime Date { get; set; }

    /// <summary>
    /// (optional) Delivery date <br/>
    /// <br/>
    /// Date of shipment.<br/>
    /// <br/>
    /// The delivery date specifies the date the commissioned goods are accepted by the buyer. If the delivery date deviates from the one specified in the header, the delivery date on item level is valid.<br/>
    /// <br/>
    /// To specify exact one date for the shipment, e.g. in the RECEIPTACKNOWLEDGEMENT-document, both sub-elements the DELIVERY_DATE and the DELIVERY_END_DATE should be the equal.
    /// </summary>
    [XmlElement("DELIVERY_DATE")]
    public DeliveryDate? DeliveryDate { get; set; }

    /// <summary>
    /// (optional) Language<br/>
    /// <br/>
    /// Specification of used languages, especially the default language of all language-dependent information<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("LANGUAGE")]
    public List<global::BMEcatSharp.Language>? Languages { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool LanguagesSpecified => Languages?.Count > 0;

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
    public global::BMEcatSharp.MultiLingualString? MimeRoot { get; set; }

    /// <summary>
    /// (required) Parties<br/>
    /// <br/>
    /// List of parties that are relevant to this business document.
    /// </summary>
    [XmlArray("PARTIES")]
    [XmlArrayItem("PARTY")]
    public List<OpenTransParty> Parties { get; set; } = [];

    /// <summary>
    /// (optional) Customer order reference<br/>
    /// <br/>
    /// The element is related to an item and refers to the previous order where the item was ordered by the customer (purchasing party).
    /// </summary>
    [XmlElement("CUSTOMER_ORDER_REFERENCE")]
    public CustomerOrderReference? CustomerOrderReference { get; set; }

    /// <summary>
    /// (required) Business partners<br/>
    /// <br/>
    /// Reference to the business partners integrated in the process of the document flow.
    /// </summary>
    [XmlElement("ORDER_PARTIES_REFERENCE")]
    public OrderPartiesReference OrderPartiesReference { get; set; } = new OrderPartiesReference();

    /// <summary>
    /// (optional) Document exchange parties<br/>
    /// <br/>
    /// Reference to the business partners who take part in the document exchange.
    /// </summary>
    [XmlElement("DOCEXCHANGE_PARTIES_REFERENCE")]
    public DocexchangePartiesReference? DocexchangePartiesReference { get; set; }

    /// <summary>
    /// (required) Currency<br/>
    /// <br/>
    /// Provides the currency that is default for all price information in the catalog. If the price of a product has a different currency, or this element is not used, the the currency has to be specified in the PRICE_CURRENCY element for the respective product.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Therefore, the currency must be specified in the catalog header or for each product separately.It is recommended to define a default currency.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CURRENCY")]
    public string Currency { get; set; }

    /// <summary>
    /// (optional) Mode of payment<br/>
    /// <br/>
    /// Payment procedure<br/>
    /// <br/>
    /// Caution:<br/>
    /// The PAYMENT element is to be interpreted by the recipient of the document as a requested mode of payment. The binding payment procedure is laid down in the order.
    /// </summary>
    [XmlElement("PAYMENT")]
    public Payment? Payment { get; set; }

    /// <summary>
    /// (optional) GTC<br/>
    /// <br/>
    /// General terms and conditions.
    /// </summary>
    [XmlElement("TERMS_AND_CONDITIONS")]
    public string? TermsAndConditions { get; set; }

    /// <summary>
    /// (optional) Partial shipment allowed<br/>
    /// <br/>
    /// Flag to indicate whether partial shipment is allowed. If allowed the value is TRUE, FALSE otherwise.<br/>
    /// The flag is binding for the order, i.e. if the value is set to FALSE and only partial shipments can be made by the recipient of the order, the order shall be invalid.<br/>
    /// Additionally one can provide concrete dates for the shipment.<br/>
    /// <br/>
    /// In contrast to the general possibility for partial shipments one can use the element PARTIAL_DELIVERY_LIST for concrete dates for partial shipments. In this case the element PARTIAL_SHIPMENT_ALLOWED is not used.<br/>
    /// <br/>
    /// Caution:<br/>
    /// If the element is used in the context ORDER_HEADER, the element must not be used on item level ORDER_ITEM.
    /// </summary>
    [XmlIgnore]
    public bool? PartialShipmentAllowed { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlElement("PARTIAL_SHIPMENT_ALLOWED")]
    public string? PartialShipmentAllowedForSerializer { get => PartialShipmentAllowed is null ? null : PartialShipmentAllowed == true ? "true" : "false"; set => PartialShipmentAllowed = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PartialShipmentAllowedForSerializerSpecified => PartialShipmentAllowed == true;

    /// <summary>
    /// (optional) Transport<br/>
    /// <br/>
    /// Information about the terms of transport.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TRANSPORT")]
    public global::BMEcatSharp.Transport? Transport { get; set; }

    /// <summary>
    /// (optional) International delivery restrictions<br/>
    /// <br/>
    /// Details of international restrictions, e.g. compulsory import / export authorization.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("INTERNALTIONAL_RESTRICTIONS")]
    public List<global::BMEcatSharp.InternationalRestriction> InternationalRestrictions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool InternationalRestrictionsSpecified => InternationalRestrictions?.Count > 0;

    /// <summary>
    /// (optional) Additional multimedia information<br/>
    /// <br/>
    /// Information about multimedia files.
    /// </summary>
    [XmlElement("MIME_INFO")]
    public OpenTransMimeInfo? MimeInfo { get; set; }

    /// <summary>
    /// (optional) Remark<br/>
    /// <br/>
    /// Remark related to a business document.
    /// </summary>
    [XmlElement("REMARKS")]
    public List<Remark>? Remarks { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RemarksSpecified => Remarks?.Count > 0;

    /// <summary>
    /// (optional) User-defined extension<br/>
    /// <br/>
    /// This element can be used for transferring information in user-defined non-openTRANS-elements; hence it is possible to extend the pre-defined set of openTRANS-elements by user-defined ones. The usage of those elements results in openTRANS business documents, which can only be exchanged between the companies that have agreed on these extensions. The structure of these elements can be very complex, though it must be valid XML.<br/>
    /// <br/>
    /// &lt;User Defined Extensions&gt; are defined exclusively as optional fields. Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
    /// <br/>
    /// The names of the elements must be clearly distinguishable from the names of other elements contained in the openTRANS standard.For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
    /// <br/>
    /// The definition of user-defined extensions takes place by additional XML DTD or XML-Schema files.
    /// </summary>
    [XmlArray("HEADER_UDX")]
    public List<object>? HeaderUdx { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HeaderUdxSpecified => HeaderUdx?.Count > 0;
}
