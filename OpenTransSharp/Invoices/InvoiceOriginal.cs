using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Original invoice)<br/>
    /// <br/>
    /// Represents the invoice document in the case that the openTRANS document is not the original invoice (e.g. as .pdf or grafical file)
    /// </summary>
    public class InvoiceOriginal
    {
        /// <summary>
        /// (required) Multimedia document<br/>
        /// <br/>
        /// Information about a multimedia file.<br/>
        /// The file itself is can be referenced and transferred separately or direclty binary-coded in the document via the element MIME_EMBEDDED.<br/>
        /// For example logos, company profiles or other business partner related documents could be added here.
        /// </summary>
        [XmlElement("MIME")]
        public Mime Mime { get; set; }
    }
}
