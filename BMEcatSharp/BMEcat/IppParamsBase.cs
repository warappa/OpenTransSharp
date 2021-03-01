using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public abstract class IppParamsBase
    {
        /// <summary>
        /// (optional) Occurence<br/>
        /// <br/>
        /// Declares whether the parameter is optional or mandatory.
        /// </summary>
        [XmlAttribute("occurence")]
        public IppOccurrence Occurrence { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OccurrenceSpecified => Occurrence != IppOccurrence.Optional;
    }
}
