using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="InvoiceItem.Type"/>.
    /// </summary>
    public enum InvoiceItemType
    {
        /// <summary>
        /// Ordered item<br/>
        /// <br/>
        /// The invoice line item refers to an ordered item/product.
        /// </summary>
        [XmlEnum("order_item")]
        OrderItem,
        /// <summary>
        /// Additional charges<br/>
        /// <br/>
        /// The invoice line item refers to additional charges which were not explicitly ordered (e.g. handling charge).
        /// </summary>
        [XmlEnum("extra_item")]
        ExtraItem,
        /// <summary>
        /// Pledge<br/>
        /// <br/>
        /// The invoice line item refers to a deposit (e.g. pallet, cable extension reel) which was not explicilty ordered and is refunded on return.
        /// </summary>
        [XmlEnum("pledge_item")]
        PledgeItem
    }
}
