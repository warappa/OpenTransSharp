using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Integrated signature)<br/>
    /// <br/>
    /// The element contains the signature related to the document.<br/>
    /// The XML-structure is specified according to the w3c XML-Signature recommendation (see also http://www.w3.org/TR/xmldsig-core/).<br/>
    /// See Element E_BILLING for an example.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class XmlSignature
    {
        /// <summary>
        /// <inheritdoc cref="XmlSignature"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlSignature()
        {
            Signature = null!;
        }

        /// <summary>
        /// <inheritdoc cref="XmlSignature"/>
        /// </summary>
        /// <param name="signature"></param>
        public XmlSignature(string signature)
        {
            if (string.IsNullOrWhiteSpace(signature))
            {
                throw new ArgumentException($"'{nameof(signature)}' cannot be null or whitespace.", nameof(signature));
            }

            Signature = signature;
        }

        /// <summary>
        /// (required) Integrated signature<br/>
        /// <br/>
        /// An electronic signature of the business document can be inserted here.
        /// </summary>
        [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string Signature { get; set; }
    }
}
