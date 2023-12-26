using System.Xml;

namespace OpenTransSharp;

/// <summary>
/// (Request For Quotation)<br/>
/// <br/>
/// Every valid RFQ business document in the openTRANS®-format is triggered by the root element RFQ and consists of a header(RFQ_HEADER), an item level (RFQ_ITEM_LIST) and a summary(RFQ_SUMMARY).<br/>
/// <br/>
/// The header is at the beginning of the business document and contains global data valid for all types of business data exchange, such as information on suppliers information about a skeleton agreement which can exist between the buying company and the supplier.The header also lays down default settings for the following item level.<br/>
/// <br/>
/// The item level contains the individual positions of the request for quotation.In this, information is taken over from the header on the item level, provided it has not been overwritten on item level.This principle is valid for all elements with the exception of the PARTIAL_SHIPMENT_ALLOWED element.If this element is used in the header, it must not be used on item level.<br/>
/// <br/>
/// The summary contains a summary of the request for quotation information. The information in this element is redundant and can be used for purposes of controls and statistics.
/// </summary>
[XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "RFQ")]
[Serializable]
public class RequestForQuotation : IOpenTransRoot
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

    /// <summary>
    /// <inheritdoc cref="RequestForQuotation"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public RequestForQuotation() { }

    public RequestForQuotation(OpenTransVersion version, OrderType type, RequestForQuotationHeader header, IEnumerable<RequestForQuotationItem> items, RequestForQuotationSummary summary)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        Version = version;
        Type = type;
        Header = header ?? throw new ArgumentNullException(nameof(header));
        Items = items.ToList();
        Summary = summary ?? throw new ArgumentNullException(nameof(summary));
    }

    /// <summary>
    /// (required) Indicates the version of the openTRANS® Standard to which the business document corresponds.<br/>
    /// <br/>
    /// Value range: "Major Version"."Minor Version" (Example: "1.0")
    /// </summary>
    [XmlAttribute("version")]
    public OpenTransVersion Version { get; set; } = OpenTransVersion.v2_1;

    /// <summary>
    /// (required) Type of request for quotation<br/>
    /// <br/>
    /// Specifies the type of request for quotation.
    /// </summary>
    [XmlAttribute("type")]
    public OrderType Type { get; set; } = OrderType.Standard;

    /// <summary>
    /// (required) Header level<br/>
    /// <br/>
    /// The header level is used to transfer information about business partners and the business document and enter default settings which can be overwritten on item level.
    /// </summary>
    [XmlElement("RFQ_HEADER")]
    public RequestForQuotationHeader Header { get; set; } = new RequestForQuotationHeader();

    /// <summary>
    /// (required) Item level<br/>
    /// <br/>
    /// The item level lists the individual positions of the request for quotation.
    /// </summary>
    [XmlArray("RFQ_ITEM_LIST")]
    [XmlArrayItem("RFQ_ITEM")]
    public List<RequestForQuotationItem> Items { get; set; } = new List<RequestForQuotationItem>();

    /// <summary>
    /// (required) Summary<br/>
    /// <br/>
    /// Summary of the request for quotation information. The information in this element is redundant.
    /// </summary>
    [XmlElement("RFQ_SUMMARY")]
    public RequestForQuotationSummary Summary { get; set; } = new RequestForQuotationSummary();
}
