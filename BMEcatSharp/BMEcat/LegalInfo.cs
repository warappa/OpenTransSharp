using System.Collections.Generic;

namespace OpenTransSharp
{
    /// <summary>
    /// (Legal information)<br/>
    /// <br/>
    /// Legal information; the content can be defined for each area or country seperately.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class LegalInfo
    {
        /// <summary>
        /// Areas-specific legal information<br/>
        /// <br/>
        /// Legal information valid for an area or a country.<br/>
        /// Legal information may include 'General Terms of Delivery', information on the management, or the legal venue.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AREA_LEGAL_INFO")]
        public List<AreaLegalInfo> AreaLegalInfos { get; set; }
    }
}
