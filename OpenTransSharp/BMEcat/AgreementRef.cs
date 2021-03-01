using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Skeleton agreement reference)<br/>
    /// <br/>
    /// This element contains a reference to a skeleton agreement (AGREEMENT), which has been named in the document header.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class AgreementReference
    {
        /// <summary>
        /// (required) Skeleton agreement ID reference<br/>
        /// <br/>
        /// Reference to the identifier (AGREEMENT_ID) of a skeleton agreement (AGREEMENT).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("AGREEMENT_IDREF")]
        public string IdReference { get; set; }

        /// <summary>
        /// (optional) Line ID reference<br/>
        /// <br/>
        /// Reference to a line identifier (AGREEMENT_LINE_ID) of a skeleton agreement (AGREEMENT).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AGREEMENT_LINE_IDREF")]
        public string? LineIdReference { get; set; }
    }
}
