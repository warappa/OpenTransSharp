using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class Language
    {
        public Language()
        {
        }

        public Language(string value)
        {
            Value = value;
        }
        public Language(Languages value)
            : this(value.ToString())
        {
        }

        public Language(string value, bool isDefault)
            : this(value)
        {
            Default = isDefault;
        }

        public Language(Languages value, bool isDefault)
            : this(value.ToString(), isDefault)
        {
        }

        /// <summary>
        /// (optional) Default flag<br/>
        /// <br/>
        /// This element determines the default language of all language-dependent information in the document.
        /// </summary>
        [XmlAttribute("default")]
        public bool? Default { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DefaultSpecified => Default == true;

        /// <summary>
        /// (required)
        /// </summary>
        [Required]
        [XmlText]
        public string Value { get; set; }
    }
}
