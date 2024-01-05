using System.Xml;

namespace OpenTransSharp;

/// <summary>
/// (Notification of dispatch)<br/>
/// <br/>
/// Every valid DISPATCHNOTIFICATION business document in the openTRANS® format is introduced with the Root-Element DISPATCHNOTIFICATION and is made up of a header (DISPATCHNOTIFICATION_HEADER), an item level (DISPATCHNOTIFICATION_ITEM_LIST) and a summary (DISPATCHNOTIFICATION_SUMMARY).<br/>
/// The header is at the beginning of the business documents and contains global data valid for all types of business data exchange such as, for example, information on automatic processing of the business document and information for identifying the business document.<br/>
/// The header also lays down default settings for the following item level.<br/>
/// <br/>
/// The item level contains the individual positions in the dispatch notification.<br/>
/// In this, information is taken over from the header on the item level, provided it has not been overwritten on item level.<br/>
/// <br/>
/// The summary contains a summary of the items in the dispatch notification.The information in this element is redundant and can be used for control and statistical purposes.
/// </summary>
[XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "DISPATCHNOTIFICATION")]
[Serializable]
public class DispatchNotification : IOpenTransRoot
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

    /// <summary>
    /// <inheritdoc cref="DispatchNotification"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DispatchNotification()
    {

    }

    /// <summary>
    /// <inheritdoc cref="DispatchNotification"/>
    /// </summary>
    /// <param name="version"></param>
    /// <param name="header"></param>
    /// <param name="items"></param>
    /// <param name="summary"></param>
    public DispatchNotification(OpenTransVersion version, DispatchNotificationHeader header, IEnumerable<DispatchNotificationItem> items, DispatchNotificationSummary summary)
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
    [XmlElement("DISPATCHNOTIFICATION_HEADER")]
    public DispatchNotificationHeader Header { get; set; } = new DispatchNotificationHeader();

    /// <summary>
    /// (required) Item level<br/>
    /// <br/>
    /// The item level lists the individual positions of the notification of the dispatch notification.
    /// </summary>
    [XmlArray("DISPATCHNOTIFICATION_ITEM_LIST")]
    [XmlArrayItem("DISPATCHNOTIFICATION_ITEM")]
    public List<DispatchNotificationItem> Items { get; set; } = [];

    /// <summary>
    /// (required) Summary<br/>
    /// <br/>
    /// Summary of the item information on the dispatch notification. The information in this element is redundant..
    /// </summary>
    [XmlElement("DISPATCHNOTIFICATION_SUMMARY")]
    public DispatchNotificationSummary Summary { get; set; } = new DispatchNotificationSummary();
}
