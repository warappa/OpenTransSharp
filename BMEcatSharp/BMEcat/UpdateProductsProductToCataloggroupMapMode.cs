using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="NewCatalogProductToCataloggroupMap.Mode"/>.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public enum UpdateProductsProductToCataloggroupMapMode
    {
        /// <summary>
        /// New<br/>
        /// <br/>
        /// Assignment of the product to a catalog group is redefined.
        /// </summary>
        [XmlEnum("new")]
        New,
        /// <summary>
        /// Delete<br/>
        /// <br/>
        /// The existing assignment is deleted.
        /// </summary>
        [XmlEnum("delete")]
        Delete
    }
}
