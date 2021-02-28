using System.Collections.Generic;

namespace OpenTransSharp
{
    /// <summary>
    /// (IPP operation)<br/>
    /// <br/>
    /// This element serves for specifying an IPP operation.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppOperation
    {
        /// <summary>
        /// (required) IPP operation ID<br/>
        /// <br/>
        /// Unique identifier of the IPP operation.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATION_ID")]
        public string IppOperationId { get; set; }

        /// <summary>
        /// (required) IPP operation type<br/>
        /// <br/>
        /// An IPP application can provide more than one operation.<br/>
        /// This element sets the operation.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATION_TYPE")]
        public IppOperationType IppOperationType { get; set; }

        /// <summary>
        /// (required) Description of the IPP operation<br/>
        /// <br/>
        /// This element is used to describe the IPP operation.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATION_DESCR")]
        public MultiLingualString? IppOperationDescription { get; set; }

        /// <summary>
        /// (required) IPP call<br/>
        /// <br/>
        /// Spezification of the IPP call.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OUTBOUND")]
        public List<IppOutbound> IppOutbounds { get; set; } = new List<IppOutbound>();

        /// <summary>
        /// (required) IPP return<br/>
        /// <br/>
        /// Spezification of the IPP return.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_INBOUND")]
        public List<IppInbound> IppInbounds { get; set; } = new List<IppInbound>();
    }
}
