using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="BMESupplierAddress"/>.
    /// </summary>
    public enum BMESupplierAddressType
    {
        [XmlEnum("supplier")]
        Supplier
    }
}
