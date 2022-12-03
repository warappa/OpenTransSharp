using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="ConfigurationParts.SelectionType"/>.
    /// </summary>
    public enum PartSelectionType
    {
        /// <summary>
        /// Non-distinct<br/>
        /// <br/>
        /// This value specifies that in multiple selections each components can only be selected once..
        /// </summary>
        [XmlEnum("non-distinct")]
        NonDistinct,
        /// <summary>
        /// Distinct<br/>
        /// <br/>
        /// This value specifies that in multiple selections all components have to be distinct from each other. 
        /// </summary>
        [XmlEnum("distinct")]
        Distinct
    }
}
