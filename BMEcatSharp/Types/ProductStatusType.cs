using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="ProductStatus.Type"/>.
    /// </summary>
    public enum ProductStatusType
    {
        /// <summary>
        /// Bargain<br/>
        /// <br/>
        /// A bargain is a product offered at a special low price for a limited period of time.
        /// </summary>
        [XmlEnum("bargain")]
        Bargain,

        /// <summary>
        /// Core assortment<br/>
        /// <br/>
        /// A product which belongs to the core assortment for a particular customer.
        /// </summary>
        [XmlEnum("core_product")]
        CoreProduct,

        /// <summary>
        /// New<br/>
        /// <br/>
        /// A new product is a product which has only just been manufactured (i.e. has not been used).
        /// </summary>
        [XmlEnum("new")]
        New,

        /// <summary>
        /// New product<br/>
        /// <br/>
        /// The product has recently been added to the catalog.
        /// </summary>
        [XmlEnum("new_product")]
        NewProduct,

        /// <summary>
        /// Old product<br/>
        /// <br/>
        /// An old product is an product which can no longer be purchased but which is still displayed in the catalog, for example in order to refer to the follow-up product (see also PRODUCT_REFERENCE element and its attribute "type" with value "followup").
        /// </summary>
        [XmlEnum("old_product")]
        OldProduct,

        /// <summary>
        /// Refurbished<br/>
        /// <br/>
        /// A refurbished product is a used product that has been specially processed in order to restore it to a condition close to its original condition.
        /// </summary>
        [XmlEnum("refurbished")]
        Refurbished,

        /// <summary>
        /// Used<br/>
        /// <br/>
        /// An used product is an product which has already been in use.
        /// </summary>
        [XmlEnum("used")]
        Used,

        /// <summary>
        /// Other status<br/>
        /// <br/>
        /// This status can be used if non of the predefined statuses adequately describe the product.
        /// </summary>
        [XmlEnum("others")]
        Others
    }
}
