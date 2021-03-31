using System;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Accounting period)<br/>
    /// <br/>
    /// The time period reflected by a set of invoices.<br/>
    /// The crucial factor is the date of the related invoices, not the orders or the date of service provision.
    /// </summary>
    public class AccountingPeriod
    {
        /// <summary>
        /// (required) Start date of the accounting period<br/>
        /// <br/>
        /// Unique timestamp for the date where the accounting period begins.<br/>
        /// </summary>
        [XmlElement("ACCOUNTING_PERIOD_START_DATE")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// (required) End date of the accounting period<br/>
        /// <br/>
        /// Unique timestamp for the date where the accounting period ends.<br/>
        /// </summary>
        [XmlElement("ACCOUNTING_PERIOD_END_DATE")]
        public DateTime EndDate { get; set; }
    }
}
