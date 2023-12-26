namespace OpenTransSharp;

/// <summary>
/// For <see cref="InvoiceInformation.Coverage"/>.
/// </summary>
public enum InvoiceCoverage
{
    /// <summary>
    /// Individual invoice<br/>
    /// <br/>
    /// The invoice comprises of items refering to one order.
    /// </summary>
    [XmlEnum("single")]
    Single,
    /// <summary>
    /// Collective invoice<br/>
    /// <br/>
    /// The invoice comprises of items refering to several orders.
    /// </summary>
    [XmlEnum("collective")]
    Collective,
}
