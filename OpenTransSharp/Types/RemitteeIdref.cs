using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to a remittee)<br/>
    /// <br/>
    /// Refers to a unique identifier of the remittee.<br/>
    /// The elemente refers to the PARTY_ID of the remittee in the same document.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class RemitteeIdref : global::BMEcatSharp.PartyRef<RemitteeIdref>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RemitteeIdref()
            : this(null!)
        {
        }

        public RemitteeIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">The most common coding standards are predefined - see <see cref="PartyTypeValues"/>.</param>
        public RemitteeIdref(string value, string type)
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
        public override string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [XmlText]
        public override string Value { get; set; }

        public static explicit operator global::BMEcatSharp.PartyId(RemitteeIdref idRef)
        {
            if (idRef is null)
            {
                return null!;
            }

            return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
        }
    }
}
