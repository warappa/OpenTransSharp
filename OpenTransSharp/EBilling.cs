using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (E-Billing informations)<br/>
    /// <br/>
    /// This Element includes informations in the context of E-Billing.
    /// </summary>
    public class EBilling
    {
        /// <summary>
        /// (optional) Original invoice<br/>
        /// <br/>
        /// Represents the invoice document in the case that the openTRANS document is not the original invoice(e.g. as .pdf or grafical file).<br/>
        /// </summary>
        [XmlElement("INVOICE_ORIGINAL")]
        public InvoiceOriginal? InvoiceOriginal { get; set; }

        /// <summary>
        /// (optional) Signature and verification report<br/>
        /// <br/>
        /// Information regarding the electronic signature and the verification report.<br/>
        /// </summary>
        [XmlElement("SIGNATURE_AND_VERIFICATION")]
        public SignatureAndVerification? SignatureAndVerification { get; set; }
    }
}
