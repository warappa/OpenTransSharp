using OpenTransSharp.Xml;
using System;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Signature and verification report)<br/>
    /// <br/>
    /// Information regarding the electronic signature and the verification report.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class SignatureAndVerification
    {
        /// <summary>
        /// <inheritdoc cref="SignatureAndVerification"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SignatureAndVerification()
        {
            Signature = null!;
        }

        /// <summary>
        /// <inheritdoc cref="SignatureAndVerification"/>
        /// </summary>
        /// <param name="signature"></param>
        public SignatureAndVerification(Signature signature)
        {
            Signature = signature ?? throw new ArgumentNullException(nameof(signature));
        }

        /// <summary>
        /// (required) Signature-container<br/>
        /// <br/>
        /// Signature information.<br/>
        /// </summary>
        [OpenTransXmlElement("SIGNATURE")]
        public Signature Signature { get; set; }

        /// <summary>
        /// (optional) Signature verification information<br/>
        /// <br/>
        /// Information related to a verification process of a signature.<br/>
        /// </summary>
        [OpenTransXmlElement("VERIFICATION")]
        public Verification? Verification { get; set; }
    }
}
