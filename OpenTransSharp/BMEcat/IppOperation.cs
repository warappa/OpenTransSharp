using System.Collections.Generic;
using System.ComponentModel;

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
        public string Id { get; set; }

        /// <summary>
        /// (required) IPP operation type<br/>
        /// <br/>
        /// An IPP application can provide more than one operation.<br/>
        /// This element sets the operation.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATION_TYPE")]
        public IppOperationType Type { get; set; }

        /// <summary>
        /// (required) Description of the IPP operation<br/>
        /// <br/>
        /// This element is used to describe the IPP operation.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATION_DESCR")]
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

        /// <summary>
        /// (required) IPP call<br/>
        /// <br/>
        /// Spezification of the IPP call.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OUTBOUND")]
        public List<IppOutbound> Outbounds { get; set; } = new List<IppOutbound>();

        /// <summary>
        /// (required) IPP return<br/>
        /// <br/>
        /// Spezification of the IPP return.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_INBOUND")]
        public List<IppInbound> Inbounds { get; set; } = new List<IppInbound>();
    }
}
