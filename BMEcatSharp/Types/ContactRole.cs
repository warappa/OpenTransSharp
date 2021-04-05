using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Role)<br/>
    /// <br/>
    /// This element describes the role or position of the contact person.
    /// </summary>
    public class ContactRole
    {
        /// <summary>
        /// <inheritdoc cref="ContactRole"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContactRole()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="ContactRole"/>
        /// </summary>
        /// <param name="value"></param>
        public ContactRole(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="ContactRole"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public ContactRole(string value, ContactRoleType type)
            : this(value)
        {
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
