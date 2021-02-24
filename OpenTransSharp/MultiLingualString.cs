using System.ComponentModel;
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

        public MultiLingualString(string value, LanguageCodes language)
        {
            Value = value;
            Language = language;
        }

        [XmlAttribute("lang")]
        public LanguageCodes Language { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LanguageSpecified => Language != LanguageCodes.Undefined;

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
