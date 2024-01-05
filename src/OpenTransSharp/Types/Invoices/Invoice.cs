using System.Xml;

namespace OpenTransSharp;

/// <summary>
/// (Invoice)<br/>
/// <br/>
/// Every valid INVOICE business document in the openTRANS® format is triggered by the root element INVOICE and consists of a header(INVOICE_HEADER), an item level (INVOICE_ITEM_LIST) and a summary(INVOICE_SUMMARY).<br/>
/// <br/>
/// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on suppliers or information on skeleton agreements which may exist between the buyer and the supplier.<br/>
/// The header also lays down default settings for the following item level.<br/>
/// <br/>
/// The item level contains the individual positions in the invoice. Here the information is transferred from the header on the item level provided the item level has not been overwritten.<br/>
/// This principle is valid for all elements.<br/>
/// <br/>
/// The summary contains a summary of the items ordered.The information in this element is redundant and can be used for control and statistical evaluation.
/// </summary>
[XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "INVOICE")]
[Serializable]
public class Invoice : IOpenTransRoot
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

    /// <summary>
    /// <inheritdoc cref="Invoice"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Invoice() { }

    /// <summary>
    /// <inheritdoc cref="Invoice"/>
    /// </summary>
    /// <param name="version"></param>
    /// <param name="header"></param>
    /// <param name="items"></param>
    /// <param name="summary"></param>
    public Invoice(OpenTransVersion version, InvoiceHeader header, IEnumerable<InvoiceItem> items, InvoiceSummary summary)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        Version = version;
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
    /// (required) Header level<br/>
    /// <br/>
    /// The header level is used to transfer information about business partners and the business document and enter default settings which can be overwritten on item level (e.g.date of delivery).
    /// </summary>
    [XmlElement("INVOICE_HEADER")]
    public InvoiceHeader Header { get; set; } = new InvoiceHeader();

    /// <summary>
    /// (required) Item level<br/>
    /// <br/>
    /// The item level lists the individual positions of the invoice.
    /// </summary>
    [XmlArray("INVOICE_ITEM_LIST")]
    [XmlArrayItem("INVOICE_ITEM")]
    public List<InvoiceItem> Items { get; set; } = [];

    /// <summary>
    /// (required) Summary<br/>
    /// <br/>
    /// Summary of the invoice information. The information in this element is generally redundant.
    /// </summary>
    [XmlElement("INVOICE_SUMMARY")]
    public InvoiceSummary Summary { get; set; } = new InvoiceSummary();
}
