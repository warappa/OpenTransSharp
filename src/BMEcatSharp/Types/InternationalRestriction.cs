using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (International delivery restrictions)<br/>
    /// <br/>
    /// This element contains details of international restrictions, e.g.compulsory import / export authorization.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class InternationalRestriction
    {
        /// <summary>
        /// <inheritdoc cref="InternationalRestriction"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InternationalRestriction()
        {
            Value = null!;
            Type = null!;
        }

        /// <summary>
        /// <inheritdoc cref="InternationalRestriction"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">Specifies the type of international delivery restriction.<br/>
        /// <br/>
        /// See <see cref="InternationalRestrictionTypeValues"/>.
        /// </param>
        public InternationalRestriction(string value, string type)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }

            Value = value;
            Type = type;
        }

        /// <summary>
        /// (required) Type of restriction<br/>
        /// <br/>
        /// Specifies the type of international delivery restriction.<br/>
        /// <br/>
        /// See <see cref="InternationalRestrictionTypeValues"/>.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
