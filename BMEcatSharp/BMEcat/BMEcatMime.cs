using System.Collections.Generic;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Multimedia document)<br/>
    /// <br/>
    /// Information about a multimedia file.<br/>
    /// The file itself is can be referenced and transferred separately or direclty binary-coded in the document via the element MIME_EMBEDDED.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class BMEcatMime
    {
        /// <summary>
        /// (optional) MIME type<br/>
        /// <br/>
        /// Type of the additional document; this element is oriented towards the mime type usual in the Internet (ftp://ftp.isi.edu/in-notes/rfc1341.txt).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_TYPE")]
        public string? MimeType { get; set; }

        /// <summary>
        /// (required - choice MimeSource/MimeEmbeddeds) Source<br/>
        /// <br/>
        /// The relative path and the file name or URL address.<br/>
        /// The MIME_SOURCE string is combined with the base path (MIME_ROOT) specified in the header of the document (attached to it by means of a simple contecatenation).<br/>
        /// Sub-directories must be separated by means of slashes("/") (e.g. /public/document/demo.pdf).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_SOURCE")]
        public List<MultiLingualString>? Source { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SourceSpecified => Source?.Count > 0;

        /// <summary>
        /// (optional) Designation<br/>
        /// <br/>
        /// Description of the additional file. It will be displayed in the target system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_DESCR")]
        public List<MultiLingualString>? Descriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionsSpecified => Descriptions?.Count > 0;

        /// <summary>
        /// (optional) Alternative text<br/>
        /// <br/>
        /// Alternative text used if the file cannot be represented in the target system, for example.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_ALT")]
        public List<MultiLingualString>? AlternativeTexts { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AlternativeTextsSpecified => AlternativeTexts?.Count > 0;

        /// <summary>
        /// (optional) Purpose<br/>
        /// <br/>
        /// Desired purpose for which the MIME document is to be used in the target system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_PURPOSE")]
        public MimePurpose? Purpose { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PurposeSpecified => Purpose.HasValue;

        /// <summary>
        /// (optional) Order<br/>
        /// <br/>
        /// Order in which the additional data is to be represented in the target system.<br/>
        /// When additional documents are listed they should be represented in ascending order (the first document is the one with the lowest number).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_ORDER")]
        public int? Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order.HasValue;
    }
}
