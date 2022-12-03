using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
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
        /// <inheritdoc cref="ConfigurationParts"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConfigurationParts() { }

        /// <summary>
        /// <inheritdoc cref="ConfigurationParts"/>
        /// </summary>
        public ConfigurationParts(IEnumerable<PartAlternative> alternatives)
        {
            if (alternatives is null)
            {
                throw new ArgumentNullException(nameof(alternatives));
            }

            Alternatives = alternatives.ToList();
        }

        /// <summary>
        /// (required) Variant components<br/>
        /// <br/>
        /// Contains information about the componente, e.g. reference to the product and implications to the order code and configuration price.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PART_ALTERNATIVE")]
        public List<PartAlternative> Alternatives { get; set; } = new List<PartAlternative>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AlternativesSpecified => Alternatives?.Count > 0;

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
        public PartSelectionType SelectionType { get; set; } = PartSelectionType.NonDistinct;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SelectionTypeSpecified => SelectionType != PartSelectionType.NonDistinct;
    }
}
