using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice correction)<br/>
    /// <br/>
    /// The element is used if the superior invoice item is used to correct an already raised and cleared invoice.<br/>
    /// The element contains information related to the correction reason and a refers to the original invoice and invoice item.
    /// </summary>
    public class InvoiceCorrection
    {
        /// <summary>
        /// (optional) Invoice reference<br/>
        /// <br/>
        /// Information according to the invoice reference.<br/>
        /// </summary>
        [XmlElement("INVOICE_REFERENCE")]
        public InvoiceReference? InvoiceReference { get; set; }

        /// <summary>
        /// (optional) Reason for adjustment<br/>
        /// <br/>
        /// Textual description for the reason of the adjustment.
        /// </summary>
        [XmlElement("ADJUSTMENT_REASON_DESCR")]
        public List<MultiLingualString>? AdjustmentReasonDescriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AdjustmentReasonDescriptionsSpecified => AdjustmentReasonDescriptions?.Count > 0;

        /// <summary>
        /// (optional) Adjustment reason<br/>
        /// <br/>
        /// Coded reason for the adjustment.<br/>
        /// </summary>
        [XmlElement("ADJUSTMENT_REASON_CODE")]
        public string? AdjustmentReasonCode { get; set; }
    }
}
