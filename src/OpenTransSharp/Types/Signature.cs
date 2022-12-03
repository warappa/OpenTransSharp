using OpenTransSharp.Xml;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Signature-container)<br/>
    /// <br/>
    /// The element contains informtion about a signature of the document.<br/>
    /// The signature can be referenced (via MIME) or included in the original document (see also INVOICE_ORIGINAL) or directly intergated in the document(via XML_SIGNATURE).<br/>
    /// Only one of the three options is valid, therefore only one of the three sub-elements can be used.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class Signature
    {
        /// <summary>
        /// <inheritdoc cref="Signature"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Signature()
        {
            Mime = null!;
        }

        /// <summary>
        /// <inheritdoc cref="Signature"/>
        /// </summary>
        /// <param name="mime"></param>
        /// <param name="signatureInOriginal"></param>
        public Signature(OpenTransMime mime, bool signatureInOriginal)
        {
            Mime = mime ?? throw new ArgumentNullException(nameof(mime));
            SignatureInOriginal = signatureInOriginal;
        }

        /// <summary>
        /// (required) Multimedia document<br/>
        /// <br/>
        /// Information about a multimedia file.<br/>
        /// The file itself is can be referenced and transferred separately or direclty binary-coded in the document via the element MIME_EMBEDDED.<br/>
        /// For example logos, company profiles or other business partner related documents could be added here.
        /// </summary>
        [OpenTransXmlElement("MIME")]
        public OpenTransMime Mime { get; set; }

        /// <summary>
        /// (required) Signature in the original document<br/>
        /// <br/>
        /// Evaluating to 'true' the element specifies that the signature is contained in the original document (see also INVOICE_ORIGINAL).<br/>
        /// <br/>
        /// Notice: The element cannot evaluate to 'false'.<br/>
        /// To express that the signature is not in the original document one simply do not use this element and one of the other two options is being used(MIME or XML_SIGNATURE).
        /// </summary>
        [XmlIgnore]
        public bool SignatureInOriginal { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [OpenTransXmlElement("SIGNATURE_IN_ORIGINAL")]
        public string SignatureInOriginalForSerializer { get => SignatureInOriginal == true ? "true" : "false"; set => SignatureInOriginal = value.ToLowerInvariant() == "true" ? true : false; }

        /// <summary>
        /// (optional) Integrated signature<br/>
        /// <br/>
        /// An electronic signature of the business document can be inserted here.
        /// </summary>
        [OpenTransXmlElement("XML_SIGNATURE")]
        public XmlSignature? XmlSignature { get; set; }
    }
}
