using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
[assembly:InternalsVisibleTo("OpenTransSharp")]

namespace BMEcatSharp
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
        [XmlText]
        public string Value { get; set; }

        public static implicit operator MultiLingualString(string value)
        {
            return new MultiLingualString(value);
        }
    }
}
