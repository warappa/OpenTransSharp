using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to invoicing party)<br/>
    /// <br/>
    /// Reference to an unique identifier of the invoicing party.<br/>
    /// The element refers to a PARTY_ID in the same document.<br/>
    /// <br/>
    /// Caution:<br/>
    /// If the document is used as a credit memo or advice of amendment (see also INVOICE_TYPE) the refered party of INVOICE_ISSUER_IDREF is additionally the recipient of the benefit/buyer.
    /// </summary>
    public class InvoiceIssuerIdref : global::BMEcatSharp.PartyRef<InvoiceIssuerIdref>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InvoiceIssuerIdref()
            : this(null!)
        {
        }

        public InvoiceIssuerIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">The most common coding standards are predefined - see <see cref="PartyTypeValues"/>.</param>
        public InvoiceIssuerIdref(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) Coding standard<br/>
        /// <br/>
        /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined.<br/>
        /// <br/>
        /// See <see cref="PartyTypeValues"/>.
        /// </summary>
        [XmlAttribute("type")]
        public override string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [XmlText]
        public override string Value { get; set; }

        public static explicit operator global::BMEcatSharp.PartyId(InvoiceIssuerIdref idRef)
        {
            if (idRef is null)
            {
                return null!;
            }

            return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
        }
    }
}
