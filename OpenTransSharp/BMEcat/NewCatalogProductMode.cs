using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="NewCatalogProduct.Mode"/>
    /// </summary>
    public enum NewCatalogProductMode
    {
        /// <summary>
        /// Insert product<br/>
        /// <br/>
        /// In the context of the T_NEW_CATALOG transaction, determing the transfer mode is not necessary, otherwise it is always 'new'.<br/>
        /// <br/>
        /// See also example (combination of different transactions)".
        /// </summary>
        [XmlEnum("new")]
        New,
        [XmlEnum("update")]
        Update,
        [XmlEnum("delete")]
        Delete
    }
}
