using OpenTransSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace OpenTransSharp
{
    /// <summary>
    /// (Customer order reference)<br/>
    /// <br/>
    /// The element is related to an item and refers to the previous order where the item was ordered by the customer (purchasing party).<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class CustomerOrderReference
    {
        /// <summary>
        /// <inheritdoc cref="CustomerOrderReference"/>
        /// </summary>
        public CustomerOrderReference() { }

        /// <summary>
        /// (optional) Order number of the buyer<br/>
        /// <br/>
        /// Unique order number of the buyer.
        /// </summary>
        [OpenTransXmlElement("ORDER_ID")]
        public string? Id { get; set; }

        /// <summary>
        /// (Optional) Item number<br/>
        /// <br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// </summary>
        [OpenTransXmlElement("LINE_ITEM_ID")]
        public string? LineItemId { get; set; }

        /// <summary>
        /// (optional) Order date<br/>
        /// <br/>
        /// Date of the order.
        /// </summary>
        [OpenTransXmlElement("ORDER_DATE")]
        public DateTime? Date { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DateSpecified => Date.HasValue;

        /// <summary>
        /// (optional) Description of the order<br/>
        /// <br/>
        /// Textual description of the order.
        /// </summary>
        [OpenTransXmlElement("ORDER_DESCR")]
        public List<global::BMEcatSharp.MultiLingualString>? Description { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

        /// <summary>
        /// (Optional) Reference to a customer<br/>
        /// <br/>
        /// Reference to a unique identifier of a customer of the purchasing company.<br/>
        /// The reference has to refer to a PARTY_ID in the same document
        /// </summary>
        [OpenTransXmlElement("CUSTOMER_IDREF")]
        public CustomerIdRef? CustomerIdRef { get; set; }
    }
}
