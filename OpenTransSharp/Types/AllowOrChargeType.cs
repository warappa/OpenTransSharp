using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// <br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public enum AllowOrChargeType
    {
        /// <summary>
        /// The element is about an allowance.
        /// </summary>
        [XmlEnum("allowance")]
        Allowance,
        /// <summary>
        /// The element is about a surcharge.
        /// </summary>
        [XmlEnum("surcharge")]
        Surcharge
    }
}
