using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Control information)<br/>
/// <br/>
/// Control information for the automatic processing of the business document is stored in the element CONTROL_INFO.<br/>
/// If the element CONTROL_INFO is used, at least one of the following elements must be included.
/// </summary>
public class ControlInformation
{
    /// <summary>
    /// <inheritdoc cref="ControlInformation"/>
    /// </summary>
    public ControlInformation() { }

    /// <summary>
    /// (optional) Interruption of automatic processing in the target system<br/>
    /// <br/>
    /// An instruction for the target system can be stored here if manual processing of the business document is required. The element consists of a text explaining why manual processing is necessary. Automatic processing in the target system is interrupted if the element is not empty.<br/>
    /// <br/>
    /// Caution:<br/>
    /// The element should only be used in justified exceptional cases (e.g. "Import test – NO processing is necessary")!
    /// </summary>
    [XmlElement("STOP_AUTOMATIC_PROCESSING")]
    public string? StopAutomaticProcessing { get; set; }

    /// <summary>
    /// (optional) Generator information<br/>
    /// <br/>
    /// Information about the generator (manual or automatic) of the document.
    /// </summary>
    [XmlElement("GENERATOR_INFO")]
    public string? GeneratorInfo { get; set; }

    /// <summary>
    /// (optional) Generation date of the business document<br/>
    /// <br/>
    /// Generation date of the XML-document.
    /// </summary>
    [XmlElement("GENERATION_DATE")]
    public DateTime? GenerationDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GenerationDateSpecified => GenerationDate.HasValue;
}
