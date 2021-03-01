using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Hash value of a file)<br/>
    /// <br/>
    /// The element contains a hash value to an external refered file.<br/>
    /// The hash value can be used to check if the file was changed since the last generation of the hash value.<br/>
    /// Generally hash values serve as input for data comparison tasks.<br/>
    /// <br/>
    /// Caution:<br/>
    /// This element can only be used once per language in a document.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class FileHashValue
    {
        /// <summary>
        /// (required) Methods of Hashing<br/>
        /// <br/>
        /// The attribute indicates the used hash-function - see <see cref="FileHashValueTypeValues"/>.<br/>
        /// In germany the BNetzA or BSI guidelines are fundamental for legal certainity, therefore the used hash-function should match the guidelines.<br/>
        /// <br/>
        /// Max length: 50
        /// </summary>
        [OpenTransXmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (optional) Language version of the file<br/>
        /// <br/>
        /// The attribute "lang" indicates the language of the referenced file in MIME_SOURCE.
        /// </summary>
        [OpenTransXmlAttribute("lang")]
        public LanguageCodes Language { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LanguageSpecified => Language != LanguageCodes.Undefined;

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 100
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
