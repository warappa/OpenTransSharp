using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="BMEBuyerAddress"/>.
    /// </summary>
    public enum BMEBuyerAddressType
    {
        [XmlEnum("buyer")]
        Buyer
    }
}
