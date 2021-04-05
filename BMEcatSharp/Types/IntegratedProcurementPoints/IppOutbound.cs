using BMEcatSharp.Xml;
using System;
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
        /// <summary>
        /// <inheritdoc cref="IppOutbound"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppOutbound()
        {
            Format = null!;
        }

        /// <summary>
        /// <inheritdoc cref="IppOutbound"/>
        /// </summary>
        /// <param name="format">
        /// Exchange format used for implementing the IPP operation, e.g., OCI 4.0 (Open Catalog Interface).<br/>
        /// <br/>
        /// See <see cref="IppOutboundFormatValues"/>.
        /// </param>
        /// <param name="uri">Calling address of the IPP operation.</param>
        public IppOutbound(string format, IEnumerable<MultiLingualString> uri)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new ArgumentException($"'{nameof(format)}' cannot be null or whitespace.", nameof(format));
            }

            if (uri is null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            Format = format;
            Uri = uri.ToList();
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
        public List<MultiLingualString> Uri { get; set; } = new List<MultiLingualString>();
    }
}
