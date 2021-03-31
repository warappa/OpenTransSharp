using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to the payer)<br/>
    /// <br/>
    /// Reference to a unique identifier of the payer.<br/>
    /// The element refers to a PARTY_ID in the same document.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class PayerIdref : global::BMEcatSharp.PartyRef<PayerIdref>
    {
        public PayerIdref()
        {
        }

        public PayerIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">The most common coding standards are predefined - see <see cref="PartyTypeValues"/>.</param>
        public PayerIdref(string value, string type)
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
        [XmlText]
        public override string Value { get; set; }

        public static explicit operator global::BMEcatSharp.PartyId(PayerIdref idRef)
        {
            if (idRef is null)
            {
                return null;
            }

            return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
        }
    }
}
