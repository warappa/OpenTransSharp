using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class PaymentTerms
    {
        /// <summary>
        /// (optional) Term of payment<br/>
        /// <br/>
        /// The information can be given according to UN/ECE or be company-specific.
        /// </summary>
        [XmlElement("PAYMENT_TERM")]
        public List<PaymentTerm>? PaymentTermList { get; set; } = new List<PaymentTerm>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PaymentTermListSpecified => PaymentTermList?.Count > 0;

        /// <summary>
        /// (optional) Time for payment<br/>
        /// <br/>
        /// Information to time-related payment details like period for payment, early payment discounts.
        /// </summary>
        [XmlElement("TIME_FOR_PAYMENT")]
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
        [XmlElement("VALUE_DATE")]
        public DateTime? ValueDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValueDateSpecified => ValueDate.HasValue;
    }
}
