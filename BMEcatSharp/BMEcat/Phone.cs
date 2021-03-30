using BMEcatSharp.Xml;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Phone number)<br/>
    /// <br/>
    /// This element contains a phone number.<br/>
    /// The respective attribute defines the type of the phone.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Phone : MultiLingualString
    {
        public Phone()
        {

        }

        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">For predefined values see <see cref="PhoneTypeValues"/>.<br/>
        /// Custom values can be used.</param>
        public Phone(string value, string type)
            : this(value)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new System.ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }

            Type = type;
        }

        /// <summary>
        /// (optional) Type of phone number.<br/>
        /// <br/>
        /// Specifies the type of the phone number.<br/>
        /// <br/>
        /// For predefined values see <see cref="PhoneTypeValues"/>.<br/>
        /// Custom values can be used.<br/>
        /// <br/>
        /// Max length: 50
        /// </summary>
        [BMEXmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
