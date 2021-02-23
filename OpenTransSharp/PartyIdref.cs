using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to a business partner)<br/>
    /// <br/>
    /// This element provides a reference to a business partner.<br/>
    /// It contains the unique identifier(PARTY_ID) of the respective party(element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class PartyIdref : PartyRef<PartyIdref>
    {
        public PartyIdref()
        {
        }

        public PartyIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined. See <see cref="PartyTypeValues"/>. Custom values can be used.</param>
        public PartyIdref(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined. See <see cref="PartyTypeValues"/>. Custom values can be used.
        /// </summary>
        [XmlAttribute("type")]
        public override string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [Required]
        [XmlText]
        public override string Value { get; set; }
    }
}
