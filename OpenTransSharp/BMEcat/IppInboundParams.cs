using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (IPP output parameters)<br/>
    /// <br/>
    /// This element contains a list of output parameters that are received from the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppInboundParams
    {
        /// <summary>
        /// (required) Other IPP input parameters<br/>
        /// <br/>
        /// Specification if and how additional parameters have to be used in the IPP application.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("IPP_PARAM_DEFINITION")]
        public List<IppParamDefinition> IppParamDefinitions { get; set; } = new List<IppParamDefinition>();
    }
}
