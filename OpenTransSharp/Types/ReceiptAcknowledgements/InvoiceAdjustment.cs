using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice correction)<br/>
    /// <br/>
    /// Correction of an invoice within the scope of a remittance advice.
    /// </summary>
    public class InvoiceAdjustment
    {
        /// <summary>
        /// (required) Adjusted invoice summary<br/>
        /// <br/>
        /// Total amount, net value and taxes of the revised invoice.<br/>
        /// </summary>
        [XmlElement("ADJUSTED_INVOICE_SUMMARY")]
        public AdjustedInvoiceSummary AdjustedInvoiceSummary { get; set; }

        /// <summary>
        /// (optional) Reason for adjustment<br/>
        /// <br/>
        /// Textual description for the reason of the adjustment.
        /// </summary>
        [XmlElement("ADJUSTMENT_REASON_DESCR")]
        public List<global::BMEcatSharp.MultiLingualString>? ReasonDescriptions { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReasonDescriptionsSpecified => ReasonDescriptions?.Count > 0;

        /// <summary>
        /// (optional) Adjustment reason<br/>
        /// <br/>
        /// Coded reason for the adjustment.<br/>
        /// </summary>
        [XmlElement("ADJUSTMENT_REASON_CODE")]
        public string? ReasonCode { get; set; }
    }
}
