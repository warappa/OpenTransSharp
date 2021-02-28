namespace OpenTransSharp
{
    /// <summary>
    /// (IPP transfered parameter)<br/>
    /// <br/>
    /// This element contains a paramter which has to be transferred in the IPP call.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppParam
    {
        /// <summary>
        /// (required) Reference to IPP parameter<br/>
        /// <br/>
        /// This element references to the specification of a parameter in a definition of an IPP application (IPP_DEFINITION).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM_NAMEREF")]
        public string IppParamNameref { get; set; }

        /// <summary>
        /// (required) IPP parameter value<br/>
        /// <br/>
        /// This element contains the value of an IPP parameter.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM_VALUE")]
        public string IppParamValue { get; set; }
    }
}
