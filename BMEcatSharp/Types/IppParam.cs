using BMEcatSharp.Xml;
using System.ComponentModel;

namespace BMEcatSharp
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppParam()
            : this(null!, null!)
        { }

        public IppParam(string nameref, string value)
        {
            Nameref = nameref;
            Value = value;
        }

        /// <summary>
        /// (required) Reference to IPP parameter<br/>
        /// <br/>
        /// This element references to the specification of a parameter in a definition of an IPP application (IPP_DEFINITION).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM_NAMEREF")]
        public string Nameref { get; set; }

        /// <summary>
        /// (required) IPP parameter value<br/>
        /// <br/>
        /// This element contains the value of an IPP parameter.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM_VALUE")]
        public string Value { get; set; }
    }
}
