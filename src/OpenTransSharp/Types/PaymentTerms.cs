using OpenTransSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Term of payment)<br/>
    /// Information to payment terms<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class PaymentTerms
    {
        /// <summary>
        /// <inheritdoc cref="PaymentTerms"/>
        /// </summary>
        public PaymentTerms() { }

        /// <summary>
        /// (optional) Term of payment<br/>
        /// <br/>
        /// The information can be given according to UN/ECE or be company-specific.
        /// </summary>
        [OpenTransXmlElement("PAYMENT_TERM")]
        public List<PaymentTerm>? PaymentTermList { get; set; } = new List<PaymentTerm>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PaymentTermListSpecified => PaymentTermList?.Count > 0;

        /// <summary>
        /// (optional) Time for payment<br/>
        /// <br/>
        /// Information to time-related payment details like period for payment, early payment discounts.
        /// </summary>
        [OpenTransXmlElement("TIME_FOR_PAYMENT")]
        public List<TimeForPayment>? TimeForPayments { get; set; } = new List<TimeForPayment>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TimeForPaymentsSpecified => TimeForPayments?.Count > 0;

        /// <summary>
        /// (optional) Value date<br/>
        /// <br/>
        /// Specifies the value date.<br/>
        /// If the time for payment are not specified using TIME_FOR_PAYMENT or only the DAYS are specified then the period of payment begins at this VALUE_DATE.<br/>
        /// Is the PAYMENT_DATE used then the element PAYMENT_DATE is decisive.
        /// </summary>
        [OpenTransXmlElement("VALUE_DATE")]
        public DateTime? ValueDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValueDateSpecified => ValueDate.HasValue;
    }
}
