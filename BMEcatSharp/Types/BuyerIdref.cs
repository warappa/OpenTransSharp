using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Reference to the buyer)<br/>
    /// <br/>This element contains a reference to the buyer.<br/>
    /// The reference has to point to a (PARTY_ID) that is defined in the document (PARTY element).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class BuyerIdref : PartyRef<BuyerIdref>
    {
        /// <summary>
        /// <inheritdoc cref="BuyerIdref"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BuyerIdref()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="BuyerIdref"/>
        /// </summary>
        /// <param name="value"></param>
        public BuyerIdref(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="BuyerIdref"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">The most common coding standards are predefined - see <see cref="PartyTypeValues"/>.</param>
        public BuyerIdref(string value, string? type)
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

        public static explicit operator PartyId(BuyerIdref idRef)
        {
            if (idRef is null)
            {
                return null!;
            }

            return new PartyId(idRef.Value, idRef.Type);
        }
    }
}
