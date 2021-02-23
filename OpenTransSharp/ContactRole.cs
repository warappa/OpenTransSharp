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
        [XmlAttribute("type")]
        public ContactRoleType? Type { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        [MinLength(1)]
        [MaxLength(20)]
        [Required]
        [XmlText]
        public string Value { get; set; }
    }
}
