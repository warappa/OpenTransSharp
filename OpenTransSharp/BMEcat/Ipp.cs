﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (IPP application)<br/>
    /// <br/>
    /// This element is used to overwrite and particularise specifications of an IPP application which have been made in the header in the element IPP_DEFINITION with new specifications on product level.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Ipp
    {
        /// <summary>
        /// (required) Reference to an IPP application<br/>
        /// <br/>
        /// Reference to the unique identifier of an IPP application.<br/>
        /// The reference has to link to an IPP_ID in the element IPP_DEFINITION.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_IDREF")]
        public string Idref { get; set; }

        /// <summary>
        /// (required) Reference to an IPP operation<br/>
        /// <br/>
        /// Specification of one or more Ipp operations.<br/>
        /// The reference has to link to an IPP_OPERATION_ID in the element IPP_DEFINITION.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATION_IDREF")]
        public List<string> OperationIdrefs { get; set; } = new List<string>();

        /// <summary>
        /// (optional) Guaranteed response time of the IPP application.<br/>
        /// <br/>
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

        /// <summary>
        /// (optional) IPP operation URL<br/>
        /// <br/>
        /// Calling address of the IPP operation.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_URI")]
        public List<string>? Uris { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UrisSpecified => Uris?.Count > 0;

        /// <summary>
        /// (optional) IPP transfered parameter<br/>
        /// <br/>
        /// Paramter that has to be transferred in the IPP call.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_PARAM")]
        public List<IppParam>? Parameters { get; set; } = new List<IppParam>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ParametersSpecified => Parameters?.Count > 0;
    }
}