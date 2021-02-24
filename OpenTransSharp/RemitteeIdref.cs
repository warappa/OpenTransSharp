using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to a remittee)<br/>
    /// <br/>
    /// Refers to a unique identifier of the remittee.<br/>
    /// The elemente refers to the PARTY_ID of the remittee in the same document.
    /// </summary>
    public class RemitteeIdref : PartyRef<RemitteeIdref>
    {
        public RemitteeIdref()
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
        public override string Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [Required]
        [XmlText]
        public override string Value { get; set; }

        public static explicit operator PartyId(RemitteeIdref idRef)
        {
            if (idRef is null)
            {
                return null;
            }

            return new PartyId(idRef.Value, idRef.Type);
        }
    }
}
