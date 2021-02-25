using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="InvoiceInformation.InvoiceType"/>.
    /// </summary>
    public enum InvoiceType
    {
        /// <summary>
        /// Invoice<br/>
        /// <br/>
        /// The document is an invoice.
        /// </summary>
        [XmlEnum("invoice")]
        Invoice,
        /// <summary>
        /// Credit Memo<br/>
        /// <br/>
        /// The document is a credit memo (in the sense of the german Value Added Tax Act).
        /// </summary>
        [XmlEnum("credit_memo")]
        CreditMemo,
        /// <summary>
        /// Invoice copy <br/>
        /// <br/>
        /// The document is an invoice.
        /// </summary>
        [XmlEnum("invoice_copy")]
        InvoiceCopy,
        [EditorBrowsable(EditorBrowsableState.Never)]
        Undefined
    }
}
