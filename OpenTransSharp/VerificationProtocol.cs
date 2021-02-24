using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Verification report as XML protocol)<br/>
    /// <br/>
    /// The element contains a representation of the protocol records coded in the RESULT_CODE and a description of the record (RESULT_DESCR).
    /// </summary>
    public class VerificationProtocol
    {
        /// <summary>
        /// (required) Coded protocol record<br/>
        /// <br/>
        /// Coded protocol record.<br/>
        /// Since a lack of standards in the area of signature verification reports the used coding-standard should be constituted between the partners.
        /// </summary>
        [Required]
        [XmlElement("RESULT_CODE")]
        public string ResultCode { get; set; }


        /// <summary>
        /// (optional) Protocol record description<br/>
        /// <br/>
        /// Description of a protocol record in a human-readable form.<br/>
        /// </summary>
        [XmlElement("RESULT_DESCR")]
        public List<Language>? ResultDescriptions { get; set; } = new List<Language>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ResultDescriptionsSpecified => ResultDescriptions?.Count > 0;
    }
}
