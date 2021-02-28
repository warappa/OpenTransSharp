﻿using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="PredefinedConfigurations.PredefinedConfigCoverage"/>.
    /// </summary>
    public enum PredefinedConfigCoverage
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