using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Mode of payment)<br/>
    /// <br/>
    /// The PAYMENT element summarizes information about the terms of payment.<br/>
    /// Exactly one term of payment must be used.<br/>
    /// If no information about payment is transferred (e.g. because this has been defined in a skeleton contract) the element is not used.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// (required) Card payment<br/>
        /// <br/>
        /// Use of credit cards, purchase cards etc.
        /// </summary>
        [OpenTransXmlElement("CARD")]
        public Card Card { get; set; }

        /// <summary>
        /// (required) Bank account<br/>
        /// <br/>
        /// Bank account details.
        /// </summary>
        [OpenTransXmlElement("ACCOUNT")]
        public List<Account> Accounts { get; set; }

        /// <summary>
        /// (required) Debit notification<br/>
        /// <br/>
        /// The element DEBIT specifies the credit note procedure as payment system.
        /// </summary>
        [OpenTransXmlElement("DEBIT")]
        public bool Debit { get; set; }

        /// <summary>
        /// (required) Check payment<br/>
        /// <br/>
        /// The element CHECK specifies paying by check as payment system.
        /// </summary>
        [OpenTransXmlElement("CHECK")]
        public bool Check { get; set; }

        /// <summary>
        /// (required) Cash payment<br/>
        /// <br/>
        /// The element CASH specifies cash payment as payment system.
        /// </summary>
        [OpenTransXmlElement("CASH")]
        public bool Cash { get; set; }

        /// <summary>
        /// (optional) Centralized settlement<br/>
        /// <br/>
        /// Indicates if the payment process is transacted via a centralized settlement.
        /// </summary>
        [OpenTransXmlElement("CENTRAL_REGULATION")]
        public bool CentralRegulation { get; set; } = false;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CentralRegulationSpecified => CentralRegulation;

        [OpenTransXmlElement("PAYMENT_TERMS")]
        public PaymentTerms PaymentTerms { get; set; }
    }
}
