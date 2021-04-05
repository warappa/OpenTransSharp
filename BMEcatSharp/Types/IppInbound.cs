using BMEcatSharp.Xml;
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (IPP return)<br/>
    /// <br/>
    /// This element contains information about the exchange format used for the IPP return and the exchanged parameter.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppInbound
    {
        /// <summary>
        /// <inheritdoc cref="IppInbound"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppInbound()
        {
            InboundFormat = null!;
        }

        /// <summary>
        /// <inheritdoc cref="IppInbound"/>
        /// </summary>
        /// <param name="inboundFormat">Exchange format used for implementing the IPP operation, e.g., OCI 4.0 (Open Catalog Interface).<br/>
        /// <br/>
        /// <see cref="IppInboundFormatValues"/>.
        /// </param>
        public IppInbound(string inboundFormat)
        {
            if (string.IsNullOrWhiteSpace(inboundFormat))
            {
                throw new ArgumentException($"'{nameof(inboundFormat)}' cannot be null or whitespace.", nameof(inboundFormat));
            }

            InboundFormat = inboundFormat;
        }

        /// <summary>
        /// (required) Exchange format<br/>
        /// <br/>
        /// Exchange format used for implementing the IPP operation, e.g., OCI 4.0 (Open Catalog Interface).<br/>
        /// <br/>
        /// <see cref="IppInboundFormatValues"/>
        /// </summary>
        [BMEXmlElement("IPP_INBOUND_FORMAT")]
        public string InboundFormat { get; set; }

        /// <summary>
        /// (optional) IPP output parameters<br/>
        /// <br/>
        /// List of output parameters and their allowed values of the IPP application.
        /// </summary>
        [BMEXmlElement("IPP_INBOUND_PARAMS")]
        public IppInboundParams? InboundParams { get; set; }

        /// <summary>
        /// (optional) Response time<br/>
        /// <br/>
        /// Guaranteed response time of the IPP application.<br/>
        /// If no response is received after this time beginning with the IPP initiation, the transaction has failed.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlIgnore]
        public TimeSpan? ResponseTime { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement(ElementName = "IPP_RESPONSE_TIME", DataType = "duration")]
        public string? ResponseTimeXmlFormatted
        {
            get
            {
                return ResponseTime is null ? null : XmlConvert.ToString(ResponseTime.Value);
            }
            set
            {
                ResponseTime = string.IsNullOrEmpty(value) ?
                    null : XmlConvert.ToTimeSpan(value);
            }
        }
    }
}
