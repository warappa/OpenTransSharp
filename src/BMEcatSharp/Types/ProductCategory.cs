using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// For <see cref="ProductDetails.Category"/>.
/// </summary>
public enum ProductCategory
{
    /// <summary>
    /// Consignment product<br/>
    /// <br/>
    /// The product is a consignment product.
    /// </summary>
    [XmlEnum("consignment")]
    Consignment,
    /// <summary>
    /// Core product<br/>
    /// <br/>
    /// The product belongs to the core.
    /// </summary>
    [XmlEnum("core_product")]
    CoreProduct,
    /// <summary>
    /// Preferred product<br/>
    /// <br/>
    /// The product is a preferred product.
    /// </summary>
    [XmlEnum("preferred")]
    Preferred,
    /// <summary>
    /// Standard product<br/>
    /// <br/>
    /// The product is a standard product.
    /// </summary>
    [XmlEnum("standard")]
    Standard,
    /// <summary>
    /// Stock product<br/>
    /// <br/>
    /// The product is available on stock.
    /// </summary>
    [XmlEnum("stock")]
    Stock,
    /// <summary>
    /// Other<br/>
    /// <br/>
    /// The product belongs to another category.
    /// </summary>
    [XmlEnum("others")]
    Other
}
