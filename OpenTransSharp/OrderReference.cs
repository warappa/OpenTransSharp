using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Order reference)<br/>
    /// <br/>
    /// The ORDER_REFERENCE element summarizes information about acquisition activities on item level which have preceded this invoice.
    /// </summary>
    public class OrderReference
    {
        /// <summary>
        /// (required) Order number of buyer.<br/>
        /// <br/>
        /// Unique order number of the buyer.<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [Required]
        [XmlElement("ORDER_ID")]
        public string OrderId { get; set; }

        /// <summary>
        /// (required) Item number<br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// <br/>
        /// Max length: 50
        /// </summary>
        [Required]
        [XmlElement("LINE_ITEM_ID")]
        public string LineItemId { get; set; }

        /// <summary>
        /// (optional) Order date<br/>
        /// <br/>
        /// Date of the order.
        /// </summary>
        [XmlElement("ORDER_DATE")]
        public DateTime? OrderDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderDateSpecified => OrderDate.HasValue;

        /// <summary>
        /// (optional) Description of the order<br/>
        /// <br/>
        /// Textual description of the order.<br/>
        /// <br/>
        /// Max length: 300
        /// </summary>
        [XmlElement("ORDER_DESCR")]
        public string? OrderDescription { get; set; }

        /// <summary>
        /// (optional) Reference to a skeleton agreement<br/>
        /// <br/>
        /// Information on the skeleton agreement which serves as a basis for the validity of the business document.
        /// </summary>
        [XmlElement("AGREEMENT")]
        public List<Agreement>? Agreements { get; set; } = new List<Agreement>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AgreementsSpecified => Agreements?.Count > 0;

        /// <summary>
        /// (optional) Reference to an (electronic) product catalog<br/>
        /// <br/>
        /// Order reference to a catalog. This element can also be used as a reference to a price list.
        /// </summary>
        [XmlElement("CATALOG_REFERENCE")]
        public CatalogReference? CatalogReference { get; set; }
    }
}
