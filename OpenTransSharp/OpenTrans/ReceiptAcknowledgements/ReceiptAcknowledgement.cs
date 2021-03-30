using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Confirmation of receipt of goods)<br/>
    /// <br/>
    /// The business document RECEIPTACKNOWLEDGEMENT is used to convey information on the receipt of the goods.<br/>
    /// <br/>
    /// Every valid RECEIPTACKNOWLEDGEMENT in openTRANS® format is triggered by the root element RECEIPTACKNOWLEDGEMENT and consists of a header (RECEIPTACKNOWLEDGEMENT_HEADER), an item level (RECEIPTACKNOWLEDGEMENT_ITEM_LIST) and a summary (RECEIPTACKNOWLEDGEMENT_SUMMARY).<br/>
    /// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on the automatic processing of the business document or information identifying the document.<br/>
    /// The header also lays down default settings for the following item level.<br/>
    /// <br/>
    /// The item level contains the individual positions in the receipt acknowledgement.Here the information is taken from the header on the item level provided the item level has not been overwritten.<br/>
    /// <br/>
    /// The summary contains a summary of the information on the receipt acknowledgement.<br/>
    /// The information in this element is redundant and can be used for control and statistical purposes and statistical evaluation.<br/>
    /// <br/>
    /// Caution:<br/>
    /// The document RECEIPTACKNOWLEDGEMENT may only be send once per article or article list, i.e.multiple confirmation of receipt of the goods, e.g.through the goods receiving department and the final recipient is not permitted.
    /// </summary>
    [XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "RECEIPTACKNOWLEDGEMENT")]
    [Serializable]
    public class ReceiptAcknowledgement : IValidatable
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

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
        [XmlElement("RECEIPTACKNOWLEDGEMENT_HEADER")]
        public ReceiptAcknowledgementHeader Header { get; set; } = new ReceiptAcknowledgementHeader();

        /// <summary>
        /// (required) Item level<br/>
        /// <br/>
        /// The item level lists the individual positions of the order.
        /// </summary>
        [XmlArray("RECEIPTACKNOWLEDGEMENT_ITEM_LIST")]
        [XmlArrayItem("RECEIPTACKNOWLEDGEMENT_ITEM")]
        public List<ReceiptAcknowledgementItem> Items { get; set; } = new List<ReceiptAcknowledgementItem>();

        /// <summary>
        /// (required) Summary<br/>
        /// <br/>
        /// Summary of the request for order information. The information in this element is redundant.
        /// </summary>
        [XmlElement("RECEIPTACKNOWLEDGEMENT_SUMMARY")]
        public ReceiptAcknowledgementSummary Summary { get; set; } = new ReceiptAcknowledgementSummary();
    }
}
