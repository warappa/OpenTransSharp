using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Signature and verification report)<br/>
    /// <br/>
    /// Information regarding the electronic signature and the verification report.
    /// </summary>
    public class SignatureAndVerification
    {
        /// <summary>
        /// (required) Signature-container<br/>
        /// <br/>
        /// Signature information.<br/>
        /// </summary>
        [Required]
        [XmlElement("SIGNATURE")]
        public Signature Signature { get; set; }

        /// <summary>
        /// (optional) Signature verification information<br/>
        /// <br/>
        /// Information related to a verification process of a signature.<br/>
        /// </summary>
        [XmlElement("VERIFICATION")]
        public Verification? Verification { get; set; }
    }
}
