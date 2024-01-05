﻿using System.Xml;

namespace OpenTransSharp;

/// <summary>
/// (Confirmation of the order)<br/>
/// <br/>
/// Every valid ORDERRESPONSE business document in openTRANS®-Format is triggered by the root element ORDERRESPONSE and consists of a header (ORDERRESPONSE_HEADER), an item level (ORDERRESPONSE_ITEM_LIST) and a summary (ORDERRESPONSE_SUMMARY).<br/>
/// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on suppliers or information on skeleton agreements which may exist between the buyer and the supplier.<br/>
/// The header also lays down default settings for the following item level.<br/>
/// <br/>
/// The item level contains the individual positions in the order.<br/>
/// In this, information is taken over from the header on the item level, provided it has not been overwritten on item level.<br/>
/// <br/>
/// The summary contains a summary of the information on the order.<br/>
/// The information in this element is redundant and can be used for control and statistical purposes.<br/>
/// <br/>
/// Caution:<br/>
/// A reversal of single order items can be done via a negative quantity (QUANTITY) refering to the original order item.<br/>
/// To do a reversal of a whole order every single order item has to be set to the corresponding negative quantity.
/// </summary>
[XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "ORDERRESPONSE")]
[Serializable]
public class OrderResponse : IOpenTransRoot
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

    /// <summary>
    /// <inheritdoc cref="OrderResponse"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderResponse() { }

    /// <summary>
    /// <inheritdoc cref="OrderResponse"/>
    /// </summary>
    /// <param name="version"></param>
    /// <param name="header"></param>
    /// <param name="items"></param>
    /// <param name="summary"></param>
    public OrderResponse(OpenTransVersion version, OrderResponseHeader header, IEnumerable<OrderResponseItem> items, OrderResponseSummary summary)
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
    [XmlElement("ORDERRESPONSE_HEADER")]
    public OrderResponseHeader Header { get; set; } = new OrderResponseHeader();

    /// <summary>
    /// (required) Item level<br/>
    /// <br/>
    /// In the item level the individual order items being confirmed are listed.
    /// </summary>
    [XmlArray("ORDERRESPONSE_ITEM_LIST")]
    [XmlArrayItem("ORDERRESPONSE_ITEM")]
    public List<OrderResponseItem> Items { get; set; } = [];

    /// <summary>
    /// (required) Summary<br/>
    /// <br/>
    /// Summary of the request for orderresponse information. The information in this element is redundant.
    /// </summary>
    [XmlElement("ORDERRESPONSE_SUMMARY")]
    public OrderResponseSummary Summary { get; set; } = new OrderResponseSummary();
}
