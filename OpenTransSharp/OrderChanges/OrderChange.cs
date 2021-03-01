using OpenTransSharp.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Change of order)<br/>
    /// <br/>
    /// Every valid ORDERCHANGE business document in openTRANS® format is triggered by the root element ORDERCHANGE and consists of a header (ORDERCHANGE_HEADER), an item level (ORDERCHANGE_ITEM_LIST) and a summary (ORDERCHANGE_SUMMARY).<br/>
    /// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on suppliers or information on skeleton agreements which may exist between the buyer and the supplier.<br/>
    /// The header also specifies default settings for the following item level.<br/>
    /// <br/>
    /// The item level contains the individual positions in the order change.<br/>
    /// Here the information is transferred from the header on the item level provided the item level has not been overwritten.<br/>
    /// This principle is valid for all elements.<br/>
    /// <br/>
    /// The summary contains a summary of the information on the order.<br/>
    /// The information in this element is redundant and can be used for control and statistical evaluation purposes.<br/>
    /// A reversal of single order items can be done via a negative quantity (QUANTITY) refering to the original order item.<br/>
    /// To do a reversal of a whole order every single order item has to be set to the corresponding negative quantity.
    /// </summary>
    [XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "ORDERCHANGE")]
    [Serializable]
    public class OrderChange : IValidatable
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = SharedXmlNamespaces.Xmlns;

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
        [XmlElement("ORDERCHANGE_HEADER")]
        public OrderChangeHeader Header { get; set; } = new OrderChangeHeader();

        /// <summary>
        /// (required) Item level<br/>
        /// <br/>
        /// The item level lists the individual positions of the order change.
        /// </summary>
        [XmlArray("ORDERCHANGE_ITEM_LIST")]
        [XmlArrayItem("ORDER_ITEM")]
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        /// <summary>
        /// (required) Summary<br/>
        /// <br/>
        /// Summary of the request for orderchange information. The information in this element is redundant.
        /// </summary>
        [XmlElement("ORDERCHANGE_SUMMARY")]
        public OrderChangeSummary Summary { get; set; } = new OrderChangeSummary();
    }
}
