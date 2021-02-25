using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class MimeData
    {
        public MimeData()
        {

        }

        public MimeData(byte[] value)
        {
            Value = Convert.ToBase64String(value);
        }

        public MimeData(byte[] value, string contentType)
            : this(value)
        {
            ContentType = contentType;
        }

        /// <summary>
        /// (optional) File type<br/>
        /// <br/>
        /// The attribute specifies the type of the embedded document according to the common used MIME-Types in the world wide web (ftp://ftp.isi.edu/in-notes/rfc1341.txt). The attribute is equivalent to the element MIME_TYPE but should be specified to ensure a better compatibility to the w3c-recommendation (http://www.w3.org/TR/xml-media-types/).
        /// </summary>
        [XmlAttribute("contentType", Namespace = "http://www.w3.org/2005/05/xmlmime")]
        public string? ContentType { get; set; }

        /// <summary>
        /// (required) File data<br/>
        /// <br/>
        /// base64 encoded.
        /// </summary>
        [Required]
        [XmlText]
        public string Value { get; set; }

        public static MimeData FromText(string text)
        {
            return new MimeData(Encoding.UTF8.GetBytes(text), "text/plain");
        }
    }
}
