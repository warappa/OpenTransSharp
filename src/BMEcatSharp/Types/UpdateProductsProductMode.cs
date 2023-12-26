using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// For <see cref="UpdateProductsProduct.Mode"/>
/// </summary>
public enum UpdateProductsProductMode
{
    /// <summary>
    /// Insert product<br/>
    /// <br/>
    /// The product does not exist in the target system, and will be inserted.
    /// </summary>
    [XmlEnum("new")]
    New,
    /// <summary>
    /// Update<br/>
    /// <br/>
    /// The product already exists in the target system.<br/>
    /// The data fields will be completely replaced.<br/>
    /// Updating single data fields is not possible.
    /// </summary>
    [XmlEnum("update")]
    Update,
    /// <summary>
    /// Delete<br/>
    /// <br/>
    /// The product will be deleted in the target system. All other data transfered with the product will be ignored.
    /// </summary>
    [XmlEnum("delete")]
    Delete
}
