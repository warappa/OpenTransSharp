using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Reference to classification system party)<br/>
    /// <br/>
    /// This element contains a reference to the ID of the organization that creates, maintains and/or provides the classification system.The element has to point to a PARTY_ID within the document.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ClassificationSystemPartyIdRef : PartyRef<ClassificationSystemPartyIdRef>
    {
        /// <summary>
        /// <inheritdoc cref="ClassificationSystemPartyIdRef"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClassificationSystemPartyIdRef()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="ClassificationSystemPartyIdRef"/>
        /// </summary>
        /// <param name="value"></param>
        public ClassificationSystemPartyIdRef(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">The most common coding standards are predefined - see <see cref="PartyTypeValues"/>.</param>
        public ClassificationSystemPartyIdRef(string value, string? type)
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

        public static explicit operator PartyId(ClassificationSystemPartyIdRef idRef)
        {
            if (idRef is null)
            {
                return null!;
            }

            return new PartyId(idRef.Value, idRef.Type);
        }
    }
}
