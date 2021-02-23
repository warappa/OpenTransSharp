using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class MultiLingualString
    {
        public MultiLingualString()
        {

        }
        public MultiLingualString(string value)
        {
            Value = value;
        }
        public MultiLingualString(string value, string? language)
        {
            Value = value;
            Language = language;
        }

        [XmlAttribute("lang")]
        public string? Language { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        [Required]
        [XmlText]
        public string Value { get; set; }

        public static implicit operator MultiLingualString(string value)
        {
            return new MultiLingualString(value);
        }
    }
}
