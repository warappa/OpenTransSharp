using System.Xml;

namespace OpenTransSharp;

/// <summary>
/// (Payment/Remittance advice)<br/>
/// <br/>
/// The business document REMITTANCEADVICE can contain several payment advice documents by one invoice recipient to many invoicing parties.<br/>
/// Every valid REMITTANCEADVICE in openTRANS® format is triggered by the root element REMITTANCEADVICE and consists of a header (REMITTANCEADVICE_HEADER), an item level (REMITTANCEADVICE_ITEM_LIST) and a summary (REMITTANCEADVICE_SUMMARY).<br/>
/// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on the automatic processing of the business document or information identifying the document.<br/>
/// The header also lays down default settings for the following item level.<br/>
/// The item level contains the individual positions in the payment advice.<br/>
/// Here the information is taken from the header on the item level provided the item level has not been overwritten.<br/>
/// The summary contains a summary of the information on the receipt acknowledgement.<br/>
/// The information in this element is redundant and can be used for control and statistical purposes and statistical evaluation.
/// </summary>
[XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "REMITTANCEADVICE")]
[Serializable]
public class RemittanceAdvice : IOpenTransRoot
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

    /// <summary>
    /// <inheritdoc cref="RemittanceAdvice"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public RemittanceAdvice() { }

    /// <summary>
    /// <inheritdoc cref="RemittanceAdvice"/>
    /// </summary>
    /// <param name="version"></param>
    /// <param name="header"></param>
    /// <param name="items"></param>
    /// <param name="summary"></param>
    public RemittanceAdvice(OpenTransVersion version, RemittanceAdviceHeader header, IEnumerable<RemittanceAdviceItem> items, RemittanceAdviceSummary summary)
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
    /// The header level is used to transfer information about business partners and the business document and enter default settings which can be overwritten on item level.
    /// </summary>
    [XmlElement("REMITTANCEADVICE_HEADER")]
    public RemittanceAdviceHeader Header { get; set; } = new RemittanceAdviceHeader();

    /// <summary>
    /// (required) Item level<br/>
    /// <br/>
    /// The item level lists all inoivce groups in a payment advice.
    /// </summary>
    [XmlArray("REMITTANCEADVICE_ITEM_LIST")]
    [XmlArrayItem("REMITTANCEADVICE_ITEM")]
    public List<RemittanceAdviceItem> Items { get; set; } = [];

    /// <summary>
    /// (required) Summary<br/>
    /// <br/>
    /// Summary of the payment advice information. Usually the information in this element is redundant.
    /// </summary>
    [XmlElement("REMITTANCEADVICE_SUMMARY")]
    public RemittanceAdviceSummary Summary { get; set; } = new RemittanceAdviceSummary();
}
