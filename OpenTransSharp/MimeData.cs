using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class MimeData
    {
        public MimeData()
        {

        }

        public MimeData(string value)
        {
            Value = value;
        }

        public MimeData(string value, string contentType)
            :this(value)
        {
            ContentType = contentType;
        }

        /// <summary>
        /// (optional) File type<br/>
        /// <br/>
        /// The attribute specifies the type of the embedded document according to the common used MIME-Types in the world wide web (ftp://ftp.isi.edu/in-notes/rfc1341.txt). The attribute is equivalent to the element MIME_TYPE but should be specified to ensure a better compatibility to the w3c-recommendation (http://www.w3.org/TR/xml-media-types/).
        /// </summary>
        [Required]
        [XmlAttribute("contentType")]
        public string? ContentType { get; set; }

        /// <summary>
        /// (required) File data<br/>
        /// <br/>
        /// base64 encoded.
        /// </summary>
        [Required]
        [XmlText]
        public string Value { get; set; }
    }
}
