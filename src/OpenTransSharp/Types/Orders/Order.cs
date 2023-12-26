﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Order)<br/>
/// <br/>
/// Every valid ORDER business document in openTRANS® format is triggered by the root element ORDER and consists of a header (ORDER_HEADER), an item level (ORDER_ITEM_LIST) and a summary(ORDER_SUMMARY).<br/>
/// <br/>
/// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on suppliers or information on skeleton agreements which may exist between the buyer and the supplier.<br/>
/// The header also lays down default settings for the following item level.<br/>
/// <br/>
/// The item level contains the individual positions in the order. Here the information is transferred from the header on the item level provided the item level has not been overwritten. This principle is valid for all elements with the exception of the element PARTIAL_SHIPMENT_ALLOWED. Where this element is used in the header, it may not be used at item level.<br/>
/// <br/>
/// The summary contains a summary of the information on the order.The information in this element is redundant and can be used for control and statistical evaluation
/// </summary>
[XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "ORDER")]
[Serializable]
public class Order : IOpenTransRoot
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

    /// <summary>
    /// <inheritdoc cref="Order"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Order() { }

    /// <summary>
    /// <inheritdoc cref="Order"/>
    /// </summary>
    /// <param name="version"></param>
    /// <param name="type"></param>
    /// <param name="header"></param>
    /// <param name="items"></param>
    /// <param name="summary"></param>
    public Order(OpenTransVersion version, OrderType type, OrderHeader header, IEnumerable<OrderItem> items, OrderSummary summary)
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
    /// (required) Type of order<br/>
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
    [XmlElement("ORDER_HEADER")]
    public OrderHeader Header { get; set; } = new OrderHeader();

    /// <summary>
    /// (required) Item level<br/>
    /// <br/>
    /// The item level lists the individual positions of the order.
    /// </summary>
    [XmlArray("ORDER_ITEM_LIST")]
    [XmlArrayItem("ORDER_ITEM")]
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    /// <summary>
    /// (required) Summary<br/>
    /// <br/>
    /// Summary of the request for order information. The information in this element is redundant.
    /// </summary>
    [XmlElement("ORDER_SUMMARY")]
    public OrderSummary Summary { get; set; } = new OrderSummary();
}
