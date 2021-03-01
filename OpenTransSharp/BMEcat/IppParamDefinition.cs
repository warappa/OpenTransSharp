namespace OpenTransSharp
{
    /// <summary>
    /// (Other IPP input parameters)<br/>
    /// <br/>
    /// This element is used to define if and how additional parameters have to be used in the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppParamDefinition : IppParamsBase
    {
        /// <summary>
        /// (required) Parameter name<br/>
        /// <br/>
        /// Name of the parameter.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// (optional) Description of the parameter<br/>
        /// <br/>
        /// This element is used to describe the parameter.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM_DESCR")]
        public MultiLingualString? Description { get; set; }
    }
}
