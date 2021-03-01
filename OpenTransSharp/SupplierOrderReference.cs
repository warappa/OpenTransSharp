﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Supplier order reference)<br/>
    /// <br/>
    /// The element SUPPLIER_ORDER_REFERENCE is reserved for information about the order which the supplier uses for the order involved.
    /// </summary>
    public class SupplierOrderReference
    {
        /// <summary>
        /// (required) Supplier order number<br/>
        /// <br/>
        /// Unique order number of the supplier.<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [XmlElement("SUPPLIER_ORDER_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (required) Item number of the supplier.<br/>
        /// <br/>
        /// Item number in the relevant order of the supplier.<br/>
        /// The item line of an order is uniquely identified using the item number.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Max length: 50
        /// </summary>
        [XmlElement("SUPPLIER_ORDER_ITEM_ID")]
        public string ItemId { get; set; }
    }
}
