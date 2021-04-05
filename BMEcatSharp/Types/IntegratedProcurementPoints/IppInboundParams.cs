using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BMEcatSharp
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
        /// <inheritdoc cref="IppInboundParams"/>
        /// </summary>
        public IppInboundParams() { }

        /// <summary>
        /// <inheritdoc cref="IppInboundParams"/>
        /// </summary>
        /// <param name="definitions"></param>
        public IppInboundParams(IEnumerable<IppParamDefinition> definitions)
        {
            if (definitions is null)
            {
                throw new ArgumentNullException(nameof(definitions));
            }

            Definitions = definitions.ToList();
        }
        /// <summary>
        /// (required) Other IPP input parameters<br/>
        /// <br/>
        /// Specification if and how additional parameters have to be used in the IPP application.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM_DEFINITION")]
        public List<IppParamDefinition> Definitions { get; set; } = new List<IppParamDefinition>();
    }
}
