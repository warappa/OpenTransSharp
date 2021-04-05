using System;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Fax number)<br/>
    /// <br/>
    /// This element contains a fax number.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Fax : MultiLingualString
    {
        /// <summary>
        /// <inheritdoc cref="Fax"/>
        /// </summary>
        public Fax() { }

        /// <summary>
        /// <inheritdoc cref="Fax"/>
        /// </summary>
        /// <param name="value"></param>
        public Fax(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="Fax"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">For predefined values see <see cref="FaxTypeValues"/>.<br/>
        /// Custom values can be used.</param>
        public Fax(string value, string type)
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
        /// (optional) Phone type<br/>
        /// <br/>
        /// Specifies the type of the phone number.<br/>
        /// <br/>
        /// See <see cref="FaxTypeValues"/>.
        /// </summary>
        [XmlAttribute("type")]
        public string? Type { get; set; }
    }
}
