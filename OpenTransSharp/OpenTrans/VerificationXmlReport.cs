using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Verification report in XML)<br/>
    /// <br/>
    /// Verification report in XML-structure.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class VerificationXmlReport
    {
        /// <summary>
        /// (required) Multimedia document<br/>
        /// <br/>
        /// The element describes the XML-structure in REPORT_UDX.<br/>
        /// Notice: the standard-format for the name should follow "<Name>-<Major Version>.<Minor Version>".<br/>
        /// <br/>
        /// Example: SigRepo-7.14.
        /// </summary>
        [OpenTransXmlElement("XML_FORMAT")]
        public string XmlFormat { get; set; }

        /// <summary>
        /// (optional) User-defined extensions<br/>
        /// <br/>
        /// With the help of this element signature verification reports can be represented in XMLstructures not specified in openTRANS.<br/>
        /// The element can be used like the ITEM_UDX element.
        /// </summary>
        [OpenTransXmlArray("REPORT_UDX")]
        public List<object>? ReportUdx { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReportUdxSpecified => ReportUdx?.Count > 0;
    }
}
