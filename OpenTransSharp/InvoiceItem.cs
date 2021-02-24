using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Item line)<br/>
    /// <br/>
    /// An item line contains invoice information on exactly one item.<br/>
    /// Any number of item lines may be used, and at least one item line must be used.
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// (optional) Characteristic of the item<br/>
        /// <br/>
        /// Specifies the content of an invoice line item in the sense of being an ordered product or an additional charge(e.g.handling charge).
        /// </summary>
        [XmlAttribute("type")]
        public InvoiceItemType? Type { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TypeSpecified => Type.HasValue;

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
        /// (required) Product number<br/>
        /// <br/>
        /// Identifier of the product.<br/>
        /// The included elements ensure the capability of a unique identification of a product.
        /// </summary>
        [Required]
        [XmlElement("PRODUCT_ID")]
        public ProductId ProductId { get; set; }

        /// <summary>
        /// (optional) Product features<br/>
        /// <br/>
        /// Description of the product by features and/or classification of the product.
        /// </summary>
        [XmlElement("PRODUCT_FEATURES")]
        public ProductFeatures? ProductFeatures { get; set; }

        /// <summary>
        /// (optional) Product components<br/>
        /// <br/>
        /// List of product componentes contained in a product.
        /// </summary>
        [XmlElement("PRODUCT_COMPONENTS")]
        public ProductComponents? ProductComponents { get; set; }

        /// <summary>
        /// (required) Quantity<br/>
        /// <br/>
        /// Quantity.
        /// </summary>
        [Required]
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
        [MaxLength(3)]
        [Required]
        [BMEXmlElement("ORDER_UNIT")]
        public string OrderUnit { get; set; }

        /// <summary>
        /// (required) Determined product price<br/>
        /// <br/>
        /// A fixed product price.
        /// </summary>
        [Required]
        [XmlElement("PRODUCT_PRICE_FIX")]
        public ProductPriceFix? ProductPriceFix { get; set; }

        /// <summary>
        /// (required) Total price of the position<br/>
        /// <br/>
        /// The total price of the item-line.<br/>
        /// In the normal case the value results from multiplying PRICE_AMOUNT and QUANTITY but has to be explicitly quoted.<br/>
        /// The element PRICE_LINE_AMOUNT can result from multiplying PRICE_AMOUNT and PRICE_UNIT_VALUE if the price is not connected to the ordered unit but to another price-unit.<br/>
        /// See PRICE_BASE_FIX for details.
        /// </summary>
        [Required]
        [XmlElement("PRICE_LINE_AMOUNT")]
        public decimal? PriceLineAmount { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PriceLineAmountSpecified => PriceLineAmount.HasValue;

        /// <summary>
        /// (optional) Foreign currency<br/>
        /// <br/>
        /// Provides a foreign currency.<brt/>
        /// When using this element the header element currency (CURRENCY) should be filled out to have a referenced standard-currency.
        /// </summary>
        [XmlElement("FOREIGN_CURRENCY")]
        public string? ForeignCurrency { get; set; }

        /// <summary>
        /// (optional) Exchange rate<br/>
        /// <br/>
        /// Exchange rate related to the foreign currency (FOREIGN_CURRENCY).
        /// </summary>
        [XmlElement("EXCHANGE_RATE")]
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// (optional) Invoice correction<br/>
        /// <br/>
        /// Informations related to a correction of an invoice.
        /// </summary>
        [XmlElement("INVOICE_CORRECTION")]
        public InvoiceCorrection? InvoiceCorrection { get; set; }

        /// <summary>
        /// (optional) Order reference<br/>
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
        /// (optional) Logistics information <br/>
        /// <br/>
        /// The element contains logistic details on item line level.
        /// </summary>
        [Required]
        [XmlElement("LOGISTIC_DETAILS")]
        public LogisticDetails? LogisticDetails { get; set; }

        /// <summary>
        /// (optional) Accounting information<br/>
        /// <br/>
        /// Information on the accounting treatment of costs incurred by the buyer as a result of the order.<br/>
        /// This information is supplied by the buyer to allow the supplier to include it in the following invoice, thereby making invoice verification by the buyer easier.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ACCOUNTING_INFO")]
        public AccountingInformation? AccountingInformation { get; set; }

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// </summary>
        [XmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Remark<br/>
        /// <br/>
        /// Remark related to a business document.
        /// </summary>
        [XmlElement("REMARKS")]
        public List<Remark> Remarks { get; set; } = new List<Remark>();
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
        public List<object> ItemUdx { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ItemUdxSpecified => ItemUdx?.Count > 0;
    }
}
