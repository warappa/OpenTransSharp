namespace OpenTransSharp;

/// <summary>
/// (Information on the business document)<br/>
/// <br/>
/// In the element ORDERRESPONSE_INFO administrative information on this order is summarized.
/// </summary>
public class OrderResponseInformation
{
    /// <summary>
    /// <inheritdoc cref="OrderResponseInformation"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderResponseInformation()
    {
        OrderId = null!;
    }

    /// <summary>
    /// <inheritdoc cref="OrderResponseInformation"/>
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="date"></param>
    /// <param name="parties"></param>
    /// <param name="orderPartiesReference"></param>
    public OrderResponseInformation(string orderId, DateTime date, IEnumerable<OpenTransParty> parties,
        OrderPartiesReference orderPartiesReference)
    {
        if (string.IsNullOrWhiteSpace(orderId))
        {
            throw new ArgumentException($"'{nameof(orderId)}' cannot be null or whitespace.", nameof(orderId));
        }

        if (parties is null)
        {
            throw new ArgumentNullException(nameof(parties));
        }

        OrderId = orderId;
        Date = date;
        OrderPartiesReference = orderPartiesReference ?? throw new ArgumentNullException(nameof(orderPartiesReference));
        Parties = parties.ToList();
    }

    /// <summary>
    /// (required) Order number of buyer<br/>
    /// <br/>
    /// Unique order number of the buyer.
    /// </summary>
    [XmlElement("ORDER_ID")]
    public string OrderId { get; set; }

    /// <summary>
    /// (required) Date of confirmation of order<br/>
    /// <br/>
    /// Date of confirmation of order receipt.
    /// </summary>
    [XmlElement("ORDERRESPONSE_DATE")]
    public DateTime Date { get; set; }

    /// <summary>
    /// (optional) Date of the order<br/>
    /// <br/>
    /// Date of the order.
    /// </summary>
    [XmlElement("ORDER_DATE")]
    public DateTime? OrderDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OrderDateSpecified => OrderDate.HasValue;

    /// <summary>
    /// (optional) Alternative order number of the buyer<br/>
    /// <br/>
    /// Further buyer order numbers which can be specified by the buyer.<br/>
    /// Relevant in the case of orders which are passed on again.<br/>
    /// Here the order number of the original ordering party can be set down.
    /// </summary>
    [XmlElement("ALT_CUSTOMER_ORDER_ID")]
    public List<string>? AlternativeCustomerOrderId { get; set; } = [];

    /// <summary>
    /// (optional) Supplier order number<br/>
    /// <br/>
    /// Unique order number of the supplier.
    /// </summary>
    [XmlElement("SUPPLIER_ORDER_ID")]
    public string? SupplierOrderId { get; set; }

    /// <summary>
    /// (optional) Order change sequence<br/>
    /// <br/>
    /// The alteration sequence is increased by one with the dispatch of each ORDERCHANGE business document.<br/>
    /// <br/>
    /// The numbering begins at 1.
    /// </summary>
    [XmlElement("ORDERCHANGE_SEQUENCE_ID")]
    public int OrderChangeSequenceId { get; set; }

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
    public List<Remark> Remarks { get; set; } = [];
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
