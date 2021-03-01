using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
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
        public Fax()
        {

        }

        public Fax(string value)
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
        /// Specifies the type of the phone number.
        /// </summary>
        [BMEXmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 50
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
