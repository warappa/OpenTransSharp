using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// <br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class DocumentIssuerIdref : PartyRef<DocumentIssuerIdref>
    {
        public DocumentIssuerIdref()
        {
        }

        public DocumentIssuerIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined - see <see cref="PartyTypeValues"/>. Custom values can also be used.</param>
        public DocumentIssuerIdref(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined - see <see cref="PartyTypeValues"/>. Custom values can also be used.<br/>
        /// <br/>
        /// Max length: 250
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

        public static explicit operator PartyId(DocumentIssuerIdref idRef)
        {
            if (idRef is null)
            {
                return null;
            }

            return new PartyId(idRef.Value, idRef.Type);
        }
    }
}
