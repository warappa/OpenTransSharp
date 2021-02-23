using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class ControlInformation
    {
        /// <summary>
        /// (optional) Interruption of automatic processing in the target system<br/>
        /// <br/>
        /// An instruction for the target system can be stored here if manual processing of the business document is required. The element consists of a text explaining why manual processing is necessary. Automatic processing in the target system is interrupted if the element is not empty.<br/>
        /// <br/>
        /// Caution:<br/>
        /// The element should only be used in justified exceptional cases (e.g. "Import test – NO processing is necessary")!
        /// </summary>
        [XmlElement("STOP_AUTOMATIC_PROCESSING")]
        [MinLength(1)]
        [MaxLength(250)]
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
}
