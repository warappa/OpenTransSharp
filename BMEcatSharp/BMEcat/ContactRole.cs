using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Role)<br/>
    /// <br/>
    /// This element describes the role or position of the contact person.
    /// </summary>
    public class ContactRole
    {
        public ContactRole()
        {

        }

        public ContactRole(string value)
        {
            Value = value;
        }

        public ContactRole(string value, ContactRoleType type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// (optional) This attribute contains the role or position as a machine-readable code.
        /// </summary>
        [XmlIgnore]
        public ContactRoleType? Type { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("type")]
        public ContactRoleType TypeForSerializer { get => Type ?? ContactRoleType.Undefined; set => Type = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TypeForSerializerSpecified => Type.HasValue;

        /// <summary>
        /// (required)
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
