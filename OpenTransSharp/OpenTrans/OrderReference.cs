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
    /// The ORDER_REFERENCE element summarizes information about acquisition activities on item level which have preceded this invoice.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
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
        [OpenTransXmlElement("ORDER_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (required) Item number<br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// <br/>
        /// Max length: 50
        /// </summary>
        [OpenTransXmlElement("LINE_ITEM_ID")]
        public string LineItemId { get; set; }

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
        /// Textual description of the order.<br/>
        /// <br/>
        /// Max length: 300
        /// </summary>
        [OpenTransXmlElement("ORDER_DESCR")]
        public string? Description { get; set; }

        /// <summary>
        /// (optional) Reference to a skeleton agreement<br/>
        /// <br/>
        /// Information on the skeleton agreement which serves as a basis for the validity of the business document.
        /// </summary>
        [OpenTransXmlElement("AGREEMENT")]
        public List<OpenTransAgreement>? Agreements { get; set; } = new List<OpenTransAgreement>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AgreementsSpecified => Agreements?.Count > 0;

        /// <summary>
        /// (optional) Reference to an (electronic) product catalog<br/>
        /// <br/>
        /// Order reference to a catalog. This element can also be used as a reference to a price list.
        /// </summary>
        [OpenTransXmlElement("CATALOG_REFERENCE")]
        public CatalogReference? CatalogReference { get; set; }
    }
}
