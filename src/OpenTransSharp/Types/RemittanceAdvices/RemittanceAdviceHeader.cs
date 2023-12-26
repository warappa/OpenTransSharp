﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Header level)<br/>
/// <br/>
/// The header is specified by the REMITTANCEADVICE_HEADER element.<br/>
/// REMITTANCEADVICE_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level (REMITTANCEADVICE_ITEM).
/// </summary>
public class RemittanceAdviceHeader
{
    /// <summary>
    /// <inheritdoc cref="RemittanceAdviceHeader"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public RemittanceAdviceHeader() { }

    /// <summary>
    /// <inheritdoc cref="RemittanceAdviceHeader"/>
    /// </summary>
    /// <param name="information"></param>
    public RemittanceAdviceHeader(RemittanceAdviceInformation information)
    {
        Information = information ?? throw new ArgumentNullException(nameof(information));
    }

    /// <summary>
    /// (optional) Control information<br/>
    /// <br/>
    /// Control information for the automatic processing of the business documents.
    /// </summary>
    [XmlElement("CONTROL_INFO")]
    public ControlInformation? ControlInformation { get; set; }

    /// <summary>
    /// (required) Information related to the remittance advice<br/>
    /// <br/>
    /// General information related to this business document.
    /// </summary>
    [XmlElement("REMITTANCEADVICE_INFO")]
    public RemittanceAdviceInformation Information { get; set; } = new RemittanceAdviceInformation();
}
