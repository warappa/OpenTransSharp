using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Reference to the manufacturer)<br/>
    /// <br/>
    /// This element provides a reference to the manufacturer.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ManufacturerIdref : PartyRef<ManufacturerIdref>
    {
        /// <summary>
        /// <inheritdoc cref="LegalInfo"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManufacturerIdref()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="LegalInfo"/>
        /// </summary>
        /// <param name="value"></param>
        public ManufacturerIdref(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="ManufacturerIdref"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined. See <see cref="PartyTypeValues"/>. Custom values can be used.</param>
        public ManufacturerIdref(string value, string? type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) Coding standard<br/>
        /// <br/>
        /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined. See <see cref="PartyTypeValues"/>. Custom values can be used.
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

        public static explicit operator PartyId(ManufacturerIdref idRef)
        {
            if (idRef is null)
            {
                return null!;
            }

            return new PartyId(idRef.Value, idRef.Type);
        }
    }
}
