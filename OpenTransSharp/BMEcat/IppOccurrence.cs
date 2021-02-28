using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="IppParamsBase.Occurrence"/>.
    /// </summary>
    public enum IppOccurrence
    {
        /// <summary>
        /// Optional<br/>
        /// <br/>
        /// Optional occurence
        /// </summary>
        [XmlEnum("optional")]
        Optional,
        /// <summary>
        /// Mandatory<br/>
        /// <br/>
        /// Mandatory occurence.
        /// </summary>
        [XmlEnum("mandatory")]
        Mandatory
    }
}
