using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Data type restrictions)<br/>
    /// <br/>
    /// This element contains a list of data type restrictions.<br/>
    /// <br/>
    /// The restrictions(FT_FACET) are based on: XML Schema Part 2: Data types Second Edition - W3C Recommendation 28 October 2004 (http://www.w3.org/TR/xmlschema-2/#dt-constraining-facet).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureTemplateFacets
    {
        /// <summary>
        /// (required) Data type restriction<br/>
        /// <br/>
        /// Restriction of the datatpye, e.g. maximum field length.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_FACET")]
        public List<FeatureTemplateFacet> Facets { get; set; } = new List<FeatureTemplateFacet>();
    }
}
