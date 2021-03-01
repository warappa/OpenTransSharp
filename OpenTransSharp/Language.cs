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
        public Language(LanguageCodes value)
            : this(value.ToString())
        {
        }

        public Language(string value, bool isDefault)
            : this(value)
        {
            Default = isDefault;
        }

        public Language(LanguageCodes value, bool isDefault)
            : this(value.ToString(), isDefault)
        {
        }

        /// <summary>
        /// (optional) Default flag<br/>
        /// <br/>
        /// This element determines the default language of all language-dependent information in the document.
        /// </summary>
        [XmlIgnore]
        public bool? Default { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("default")]
        public bool DefaultForSerializer { get => Default ?? false; set => Default = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DefaultForSerializerSpecified => Default == true;

        /// <summary>
        /// (required)
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
