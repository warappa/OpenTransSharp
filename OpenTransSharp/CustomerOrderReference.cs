using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Customer order reference)<br/>
    /// <br/>
    /// The element is related to an item and refers to the previous order where the item was ordered by the customer (purchasing party).
    /// </summary>
    public class CustomerOrderReference
    {
        /// <summary>
        /// (optional) Order number of the buyer<br/>
        /// <br/>
        /// Unique order number of the buyer.
        /// </summary>
        [MinLength(1)]
        [MaxLength(250)]
        [XmlElement("ORDER_ID")]
        public string? OrderId { get; set; }

        /// <summary>
        /// (Optional) Item number<br/>
        /// <br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// </summary>
        [XmlElement("LINE_ITEM_ID")]
        public string? LineItemId { get; set; }

        /// <summary>
        /// (optional) Order date<br/>
        /// <br/>
        /// Date of the order.
        /// </summary>
        [XmlElement("ORDER_DATE")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// (optional) Description of the order<br/>
        /// <br/>
        /// Textual description of the order.
        /// </summary>
        [XmlElement("ORDER_DESCR")]
        public List<MultiLingualString> OrderDescriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderDescriptionsSpecified => OrderDescriptions?.Count > 0;

        /// <summary>
        /// (Optional) Reference to a customer<br/>
        /// <br/>
        /// Reference to a unique identifier of a customer of the purchasing company.<br/>
        /// The reference has to refer to a PARTY_ID in the same document
        /// </summary>
        [XmlElement("CUSTOMER_IDREF")]
        public CustomerIdRef? CustomerIdRef { get; set; }
    }
}
