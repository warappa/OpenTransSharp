using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Embedded document)<br/>
    /// <br/>
    /// The element consists of a sub-element for the transmission of a file and sub-elements containing additional information (e.g.file name).<br/>
    /// <br/>
    /// Caution:<br/>
    /// The element can only be used once per language, for example if three languages are implemented in the document this element can be used three times.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class MimeEmbedded
    {
        /// <summary>
        /// (optional) Language version of the file<br/>
        /// <br/>
        /// The attribute "lang" specifies the language of the embedded file.<br/>
        /// The encoding of the attribute value follows the corresponding data type dtLANG.<br/>
        /// This enables the implementation of more than one language in one document (see also Chapter: multilingual documents).<br/>
        /// <br/>
        /// In case of specifying more than one single-declared element to support a multilingual document all "lang"-attributes must contain different values(one unique value per language).
        /// </summary>
        [XmlAttribute("lang")]
        public global::BMEcatSharp.LanguageCodes Language { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LanguageSpecified => Language != global::BMEcatSharp.LanguageCodes.Undefined;

        /// <summary>
        /// (required) Coded deata of the file<br/>
        /// <br/>
        /// Element contains binary-coded file (base64).
        /// </summary>
        [OpenTransXmlElement("MIME_DATA")]
        public MimeData Data { get; set; }

        /// <summary>
        /// (optional) Filename<br/>
        /// <br/>
        /// Name of file.
        /// </summary>
        [OpenTransXmlElement("FILE_NAME")]
        public string FileName { get; set; }

        /// <summary>
        /// (optional) Filesize<br/>
        /// <br/>
        /// Size of the file in Byte.
        /// </summary>

        [OpenTransXmlElement("FILE_SIZE")]
        public int? FileSize { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FileSizeSpecified => FileSize.HasValue;
    }
}
