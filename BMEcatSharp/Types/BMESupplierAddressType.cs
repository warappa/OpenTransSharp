using System;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="BMESupplierAddress"/>.
    /// </summary>
    //[Obsolete("This element will not be used in the future.")]
    public enum BMESupplierAddressType
    {
        [XmlEnum("supplier")]
        //[Obsolete("This element will not be used in the future.")]
        Supplier
    }
}
