using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Item line)<br/>
    /// <br/>
    /// An item line contains the information on precisely one position of the receipt acknowledgement.<br/>
    /// Any number of item lines may be used, and at least one must be used.
    /// </summary>
    public class ReceiptAcknowledgementItem
    {
        /// <summary>
        /// (required) Item number<br/>
        /// <br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// </summary>
        [XmlElement("LINE_ITEM_ID")]
        public string LineItemId { get; set; }

        /// <summary>
        /// (required) Product number<br/>
        /// <br/>
        /// Identifier of the product.<br/>
        /// The included elements ensure the capability of a unique identification of a product.
        /// </summary>
        [XmlElement("PRODUCT_ID")]
        public ProductId ProductId { get; set; }

        /// <summary>
        /// (required) Quantity<br/>
        /// <br/>
        /// Quantity.
        /// </summary>
        [XmlElement("QUANTITY")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// (required) Order unit<br/>
        /// <br/>
        /// Unit in which the product can be ordered; it is only possible to order multiples of the product unit.<br/>
        /// The price also always refers to this unit (or to part of or multiples of it).<br/>
        /// <br/>
        /// Example: Crate of mineral water with 6 bottles<br/>
        /// Order unit: "crate", contents unit/unit of the article: "bottle"<br/>
        /// Packing quantity: "6"<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ORDER_UNIT")]
        public string OrderUnit { get; set; }

        /// <summary>
        /// (optional) Delivery completed<br/>
        /// <br/>
        /// This element contains information on the completion of the delivery.<br/>
        /// If the element is TRUE, the relevant order item has been delivered in full.<br/>
        /// In the case of FALSE, at least a part of the order remains to be delivered.
        /// </summary>
        [XmlElement("DELIVERY_COMPLETED")]
        public bool? DeliveryCompleted { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeliveryCompletedSpecified => DeliveryCompleted.HasValue;

        /// <summary>
        /// (optional) Receipt date<br/>
        /// <br/>
        /// Dates the commissioned goods are received by the buyer.<br/>
        /// If the receipt date deviates from the one specified on the header, the delivery date on item level applies.
        /// </summary>
        [XmlElement("RECEIPT_DATE")]
        public DateTime? ReceiptDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReceiptDateSpecified => ReceiptDate.HasValue;

        /// <summary>
        /// (required) Order reference<br/>
        /// <br/>
        /// The element is related to an item and refers to the previous order.
        /// </summary>
        [XmlElement("ORDER_REFERENCE")]
        public OrderReference OrderReference { get; set; }

        /// <summary>
        /// (optional) Supplier order reference<br/>
        /// <br/>
        /// Reference information of the supplier on the order to which the item relates.<br/>
        /// <br/>
        /// Caution:<br/>
        /// While the element ORDER_REFERENCE contains information on the order at the buyer’s, the element "Supplier order reference" provides information on the order at the supplier's.
        /// </summary>
        [XmlElement("SUPPLIER_ORDER_REFERENCE")]
        public SupplierOrderReference? SupplierOrderReference { get; set; }

        /// <summary>
        /// (optional) Customer order reference<br/>
        /// <br/>
        /// The element is related to an item and refers to the previous order where the item was ordered by the customer (purchasing party).
        /// </summary>
        [XmlElement("CUSTOMER_ORDER_REFERENCE")]
        public CustomerOrderReference? CustomerOrderReference { get; set; }

        /// <summary>
        /// (optional) Delivery reference<br/>
        /// <br/>
        /// Reference information on the delivery to which the reference item relates.
        /// </summary>
        [XmlElement("DELIVERY_REFERENCE")]
        public DeliveryReference? DeliveryReference { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref? SupplierIdref { get; set; }

        /// <summary>
        /// (optional) Reference to final recipient<br/>
        /// <br/>
        /// Reference to the unique identifier of the final recipient (shipping address and contact).<br/>
        /// The element has to refer to a PARTY_ID in the same document.
        /// </summary>
        [XmlElement("DELIVERY_IDREF")]
        public DeliveryIdref? DeliveryIdref { get; set; }

        /// <summary>
        /// (optional) Reference to a final recipient<br/>
        /// <br/>
        /// Reference to a unique identifier of the final recipient.<br/>
        /// The element has to refer to a PARTY_ID in the same document.
        /// </summary>
        [XmlElement("FINAL_DELIVERY_IDREF")]
        public FinalDeliveryIdref? FinalDeliveryIdref { get; set; }

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// </summary>
        [XmlElement("MIME_INFO")]
        public OpenTransMimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Remark<br/>
        /// <br/>
        /// Remark related to a business document.
        /// </summary>
        [XmlElement("REMARKS")]
        public List<Remark>? Remarks { get; set; } = new List<Remark>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemarksSpecified => Remarks?.Count > 0;

        /// <summary>
        /// (optional) User-defined extensions<br/>
        /// <br/>
        /// This element can be used for transferring information in user-defined non-openTRANS-elements; hence it is possible to extend the pre-defined set of openTRANS-elements by user-defined ones.<br/>
        /// <br/>
        /// The usage of those elements results in openTRANS business documents, which can only be exchanged between the companies that have agreed on these extensions.<br/>
        /// The structure of these elements can be very complex, though it must be valid XML.<br/>
        /// <br/>
        /// Caution:<br/>
        /// &lt;User Defined Extensions&gt; are defined exclusively as optional fields. Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
        /// The names of the elements must be clearly distinguishable from the names of other elements contained in the openTRANS standard.<br/>
        /// For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
        /// <br/>
        /// The definition of user-defined extensions takes place by additional XML DTD or XML.
        /// </summary>
        [XmlArray("ITEM_UDX")]
        public List<object>? ItemUdx { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ItemUdxSpecified => ItemUdx?.Count > 0;
    }
}
