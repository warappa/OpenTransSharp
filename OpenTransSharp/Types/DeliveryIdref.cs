using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to final recipient)<br/>
    /// <br/>
    /// Reference to the unique identifier of the final recipient (shipping address and contact).<br/>
    /// The element has to refer to a PARTY_ID in the same document.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class DeliveryIdref : global::BMEcatSharp.PartyRef<DeliveryIdref>
    {
        public DeliveryIdref()
        {
        }

        public DeliveryIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined - see <see cref="PartyTypeValues"/>. Custom values can also be used.</param>
        public DeliveryIdref(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined - see <see cref="PartyTypeValues"/>. Custom values can also be used.<br/>
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

        public static explicit operator global::BMEcatSharp.PartyId(DeliveryIdref idRef)
        {
            if (idRef is null)
            {
                return null;
            }

            return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
        }
    }
}
