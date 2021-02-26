using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="UpdatePricesProduct.Mode"/>
    /// </summary>
    public enum UpdatePricesProductMode
    {
        /// <summary>
        /// Update<br/>
        /// <br/>
        /// The product already exists in the target system.<br/>
        /// The data fields will be completely replaced.<br/>
        /// Updating single data fields is not possible.
        /// </summary>
        [XmlEnum("update")]
        Update
    }
}
