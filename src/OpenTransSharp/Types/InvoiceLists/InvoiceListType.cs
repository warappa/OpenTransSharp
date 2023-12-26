namespace OpenTransSharp;

/// <summary>
/// For <see cref="InvoiceListInformation.Type"/>.
/// </summary>
public enum InvoiceListType
{
    /// <summary>
    /// Credit card statement<br/>
    /// <br/>
    /// The document is a credit card statement.
    /// </summary>
    [XmlEnum("credit_card_statement")]
    CreditCardStatement,
    /// <summary>
    /// Invoice list<br/>
    /// <br/>
    /// he document is an invoice list and contains invoice summaries of (several) invoicing parties to (several) invoice recipients.
    /// </summary>
    [XmlEnum("credit_card_statement")]
    InvoiceList
}
