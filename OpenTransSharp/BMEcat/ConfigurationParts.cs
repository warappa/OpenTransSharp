using System.Collections.Generic;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Configuration component)<br/>
    /// <br/>
    /// This element defines a component, which can or must be selected in an actual product configuration.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ConfigurationParts
    {
        /// <summary>
        /// (required) Maximum occurence step<br/>
        /// <br/>
        /// This element contains the maximum number of components respectively feature values which can be selected.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PART_ALTERNATIVE")]
        public List<PartAlternative> PartAlternatives { get; set; } = new List<PartAlternative>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PartAlternativesSpecified => PartAlternatives?.Count > 0;

        /// <summary>
        /// (optional) Selection type <br/>
        /// <br/>
        /// If multiple components can be selected the selection type specifies wether the selected components have to be distinct or if one component can be selected multiple times.<br/>
        /// <br/>
        /// Example:<br/>
        /// If a laptop has two cartriges the value 'distinct' means that both cartriges have two be filled different.<br/>
        /// The value 'non-distinct' or the absence of the element PART_SELECTION_TYPE allows that both cartriges can be filled the same way.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PART_SELECTION_TYPE")]
        public PartSelectionType PartSelectionType { get; set; } = PartSelectionType.NonDistinct;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PartSelectionTypeSpecified => PartSelectionType != PartSelectionType.NonDistinct;
    }
}
