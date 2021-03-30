using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Quotation)<br/>
    /// <br/>
    /// Every valid QUOTATION business document in openTRANS® format is triggered by the root element QUOTATION and consists of a header (QUOTATION_HEADER), an item level (QUOTATION_ITEM_LIST) and a summary (QUOTATION_SUMMARY).<br/>
    /// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on suppliers or information on skeleton agreements which may exist between the buyer and the supplier.The header also lays down default settings for the following item level.<br/>
    /// The item level contains the individual positions in the order.<br/>
    /// Here the information is taken from the header on the item level provided the item level has not been overwritten. This principle is valid for all elements.<br/>
    /// The summary contains a summary of the information on the quotation.<br/>
    /// The information in this element is redundant and can be used for control and statistical evaluation purposes.
    /// </summary>
    [XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "QUOTATION")]
    [Serializable]
    public class Quotation : IValidatable
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
        [XmlElement("QUOTATION_HEADER")]
        public QuotationHeader Header { get; set; } = new QuotationHeader();

        /// <summary>
        /// (required) Item level<br/>
        /// <br/>
        /// The item level lists the individual positions of the quotation.
        /// </summary>
        [XmlArray("QUOTATION_ITEM_LIST")]
        [XmlArrayItem("QUOTATION_ITEM")]
        public List<QuotationItem> Items { get; set; } = new List<QuotationItem>();

        /// <summary>
        /// (required) Summary<br/>
        /// <br/>
        /// Summary of the request for quotation information. The information in this element is redundant.
        /// </summary>
        [XmlElement("QUOTATION_SUMMARY")]
        public QuotationSummary Summary { get; set; } = new QuotationSummary();
    }
}
