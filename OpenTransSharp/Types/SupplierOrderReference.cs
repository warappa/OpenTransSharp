using OpenTransSharp.Xml;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Supplier order reference)<br/>
    /// <br/>
    /// The element SUPPLIER_ORDER_REFERENCE is reserved for information about the order which the supplier uses for the order involved.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class SupplierOrderReference
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SupplierOrderReference()
        {
            Id = null!;
            LineItemId = null!;
        }

        public SupplierOrderReference(string id, string lineItemId)
        {
            Id = id;
            LineItemId = lineItemId;
        }

        /// <summary>
        /// (required) Supplier order number<br/>
        /// <br/>
        /// Unique order number of the supplier.<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [OpenTransXmlElement("SUPPLIER_ORDER_ID")]
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
        [OpenTransXmlElement("SUPPLIER_ORDER_ITEM_ID")]
        public string LineItemId { get; set; }
    }
}
