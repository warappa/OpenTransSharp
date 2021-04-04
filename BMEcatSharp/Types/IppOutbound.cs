using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
{
    /// <summary>
    /// (IPP call)<br/>
    /// <br/>
    /// This element contains information about the exchange format used for the IPP call and the exchanged parameter.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppOutbound
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppOutbound()
            : this(null!, null!)
        { }

        public IppOutbound(string format, IEnumerable<MultiLingualString> uris)
        {
            Format = format;
            Uris = uris?.ToList() ?? new();
        }

        /// <summary>
        /// (required) Exchange format<br/>
        /// <br/>
        /// Exchange format used for implementing the IPP operation, e.g., OCI 4.0 (Open Catalog Interface).<br/>
        /// <br/>
        /// See <see cref="IppOutboundFormatValues"/>.
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OUTBOUND_FORMAT")]
        public string Format { get; set; }

        /// <summary>
        /// (optional) IPP input parameters<br/>
        /// <br/>
        /// List of input parameters and their allowed values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OUTBOUND_PARAMS")]
        public IppOutboundParams? Params { get; set; }

        /// <summary>
        /// (required) IPP operation URL<br/>
        /// <br/>
        /// Calling address of the IPP operation.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_URI")]
        public List<MultiLingualString> Uris { get; set; } = new List<MultiLingualString>();
    }
}
