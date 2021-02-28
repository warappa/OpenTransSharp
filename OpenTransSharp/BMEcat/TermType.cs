using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="Term.Type"/>.
    /// </summary>
    public enum TermType
    {
        /// <summary>
        /// Calculation<br/>
        /// <br/>
        /// The term contains a formula to calculate a value.
        /// </summary>
        [XmlEnum("function")]
        Function,

        /// <summary>
        /// Constraint<br/>
        /// <br/>
        /// The term is used to restrict valid configurations.
        /// </summary>
        [XmlEnum("constraint")]
        Constraint
    }
}
