using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to the recipient of the invoice)<br/>
    /// <br/>
    /// Reference to an unique identifier to the recipient of the invoice.<br/>
    /// The element refers to a PARTY_ID of an invoice recipient in the same document.<br/>
    /// <br/>
    /// Caution:<br/>
    /// If the document is used as a credit memo or advice of amendment (see also INVOICE_TYPE) the refered party of INVOICE_RECIPIENT_IDREF is also the supplier.
    /// </summary>
    public class InvoiceRecipientIdref : PartyRef<InvoiceRecipientIdref>
    {
        public InvoiceRecipientIdref()
        {
        }

        public InvoiceRecipientIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">The most common coding standards are predefined - see <see cref="PartyTypeValues"/>.</param>
        public InvoiceRecipientIdref(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) Coding standard<br/>
        /// <br/>
        /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined.
        /// </summary>
        [XmlAttribute("type")]
        public override string Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [Required]
        [XmlText]
        public override string Value { get; set; }

        public static explicit operator PartyId(InvoiceRecipientIdref idRef)
        {
            if (idRef is null)
            {
                return null;
            }

            return new PartyId(idRef.Value, idRef.Type);
        }
    }
}
