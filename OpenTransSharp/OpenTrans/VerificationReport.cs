namespace OpenTransSharp
{
    /// <summary>
    /// (Verification report<br/>
    /// <br/>
    /// The element refers or directly contains a report to the verification of the signature.<br/>
    /// There are three options to refer to the report.<br/>
    /// The report can be in an extra file (e.g. as PDF or XML) and is refered via the VERIFICATION_ATTACHMENT element.<br/>
    /// The second option is to specify the verification results as XML-verification protocol   (VERIFICATION_PROTOCOL).<br/>
    /// The last option is to directly integrate the verification report in a special XML-format in the document(via VERIFICATION_XMLREPORT).<br/>
    /// <br/>
    /// Since a lack of standardization in the area of verification reports the following minimum information should be transmitted:<br/>
    /// <list type="bullet">
    /// <item>unique name of the signer</item>
    /// <item>unique name of the publisher</item>
    /// <item>serial number</item>
    /// <item>valid from / to</item>
    /// <item>used methods and the key-length</item>
    /// <item>online-verification successful</item>
    /// <item>superior certificate found</item>
    /// <item>time of verification</item>
    /// <item>time of signature</item>
    /// <item>possible restrictive certificates in plain text</item>
    /// <item>possible restrictive certificates in plain text</item>
    /// </list>
    /// <br/>
    /// Minimum requirement is the block "signer".<br/>
    /// All superior certificate/signatures should be declared in the summary likewise the number of successful or not successful online-verifications.<br/>
    /// Since a signer(1) is usually certified by a Trusted Entity(2) and the Trusted Entity is usually certified by a Root-CA (certification authority) (3) the successful verification evaluates to 3/3 successful tests.<br/>
    /// In case of not successful verifications the reason should be declared (rejected, disabled, expired, not valid ...).<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class VerificationReport
    {
        /// <summary>
        /// (required) Verification report as (integrated) file<br/>
        /// <br/>
        /// Reference to a verification report as a file or binary-coded and integrated in the document.
        /// </summary>
        [OpenTransXmlElement("VERIFICATION_ATTACHMENT")]
        public VerificationAttachment Attachment { get; set; }

        /// <summary>
        /// (required) Verification report as XML protocol<br/>
        /// <br/>
        /// Verification report as XML protocol.
        /// </summary>
        [OpenTransXmlElement("VERIFICATION_PROTOCOL")]
        public VerificationProtocol Protocol { get; set; }

        /// <summary>
        /// (required) Verification report in XML<br/>
        /// <br/>
        /// Verification report in XML-structure.
        /// </summary>
        [OpenTransXmlElement("VERIFICATION_XMLREPORT")]
        public VerificationXmlReport XmlReport { get; set; }
    }
}
