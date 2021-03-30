using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="PredefinedConfigurations.Coverage"/>.
    /// </summary>
    public enum PredefinedConfigurationCoverage
    {
        /// <summary>
        /// Partial coverage<br/>
        /// <br/>
        /// The specified predefined configurations cover only some of the valid configurations.
        /// </summary>
        [XmlEnum("partial")]
        Partial,
        /// <summary>
        /// Full coverage<br/>
        /// <br/>
        /// The specified predefined configurations cover all valid configurations. .
        /// </summary>
        [XmlEnum("full")]
        Full
    }
}
