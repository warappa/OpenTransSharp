using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="RemittanceAdviceInformation"/>.
    /// </summary>
    public enum RemittanceAdviceType
    {
        /// <summary>
        /// Payment<br/>
        /// <br/>
        /// The payment describes a payment triggered by the payer.
        /// </summary>
        [XmlEnum("payment")]
        Payment,
        /// <summary>
        /// Collection<br/>
        /// <br/>
        /// The payment advice describes a payment triggered by the remittee (e.g. via direct debit).
        /// </summary>
        [XmlEnum("collection")]
        Collection
    }
}
