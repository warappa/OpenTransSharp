using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Classification system)<br/>
    /// <br/>
    /// This element allows to define a classification classification completely, including groups, synonyms, features and default values (if available).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ClassificationSystem
    {
        /// <summary>
        /// <inheritdoc cref="ClassificationSystem"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClassificationSystem()
        {
            Name = null!;
        }

        /// <summary>
        /// <inheritdoc cref="ClassificationSystem"/>
        /// </summary>
        /// <param name="name"></param>
        public ClassificationSystem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// (required) Classification system name<br/>
        /// <br/>
        /// Unique designation of the classification system, this identification must combine the (short) name of the classification system with the version number so that unique referencing of the classification system is possible.<br/>
        /// The format for the identification number should follow the pattern "&lt;Name&gt;-&lt;MajorVersion&gt;.&lt;MinorVersion&gt;".<br/>
        /// <br/>
        /// See <see cref="ClassificationSystemNameValues"/>.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// (optional) Complete name of the classification system<br/>
        /// <br/>
        /// Full name of the classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_FULLNAME")]
        public string? Fullname { get; set; }

        /// <summary>
        /// (optional - choice ClassificationSystemVersionDetails/(deprecated)ClassificationSystemVersion) Version of the classification system<br/>
        /// <br/>
        /// Detailled information on the version of the classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_VERSION_DETAILS")]
        public ClassificationSystemVersionDetails? VersionDetails { get; set; }

        /// <summary>
        /// (optional) Version of the classification system<br/>
        /// <br/>
        /// This element contains the version of the classification system.<br/>
        /// The element CLASSIFICATION_SYSTEM_VERSION will be replaced by the element CLASSIFICATION_SYSTEM_VERSION_DETAILS in future versions and will be omitted then.<br/>
        /// <br/>
        /// Example (eCl@ss)<br/>
        /// <c>&lt;CLASSIFICATION_SYSTEM_VERSION&gt;5.1&lt;/CLASSIFICATION_SYSTEM_VERSION&gt;</c><br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_VERSION")]
        //[Obsolete("The element CLASSIFICATION_SYSTEM_VERSION will be replaced by the element CLASSIFICATION_SYSTEM_VERSION_DETAILS in future versions and will be omitted then.")]
        public string? Version { get; set; }

        /// <summary>
        /// (optional) Classification system description<br/>
        /// <br/>
        /// Description of the classification system and its content.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_DESCR")]
        public string? Descripiton { get; set; }

        /// <summary>
        /// (optional) Reference to classification system party<br/>
        /// <br/>
        /// Reference to the ID of the organization that creates, maintains and/or provides the classification system. The element has to point to a PARTY_ID within the document.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_PARTY_IDREF")]
        public ClassificationSystemPartyIdRef? ClassificationSystemPartyIdRef { get; set; }

        /// <summary>
        /// (optional) Number of hierarchical levels<br/>
        /// <br/>
        /// Number of hierarchy levels in the classification system<br/>
        /// <br/>
        /// 
        /// Example (eCl@ss)<br/>
        /// <c>&lt;CLASSIFICATION_SYSTEM_LEVELS&gt;4&lt;/CLASSIFICATION_SYSTEM_LEVELS&gt;</c><br/>
        /// <br/>
        /// Example (ETIM)<br/>
        /// <c>&lt;CLASSIFICATION_SYSTEM_LEVELS&gt;2&lt;/CLASSIFICATION_SYSTEM_LEVELS&gt;<br/></c>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_LEVELS")]
        public int? Levels { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LevelsSpecified => Levels.HasValue;

        /// <summary>
        /// (optional) Designation of the hierarchical levels<br/>
        /// <br/>
        /// Specifies the names of the hierarchical levels.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("CLASSIFICATION_SYSTEM_LEVEL_NAMES")]
        [BMEXmlArrayItem("CLASSIFICATION_SYSTEM_LEVEL_NAME")]
        public List<ClassificationSystemLevelName>? LevelNames { get; set; } = new List<ClassificationSystemLevelName>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LevelNamesSpecified => LevelNames?.Count > 0;

        /// <summary>
        /// (optional) Classification system type<br/>
        /// <br/>
        /// Information about the structure of the classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM_TYPE")]
        public ClassificationSystemType? Type { get; set; }

        /// <summary>
        /// (optional) Allowed values<br/>
        /// <br/>
        /// List of allowed values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("ALLOWED_VALUES")]
        [BMEXmlArrayItem("ALLOWED_VALUE")]
        public List<AllowedValue>? AllowedValues { get; set; } = new List<AllowedValue>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowedValuesSpecified => AllowedValues?.Count > 0;

        /// <summary>
        /// (optional) Units of measurement<br/>
        /// <br/>
        /// Specifies the units of measurement used within the classification system and its features.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("UNITS")]
        [BMEXmlArrayItem("UNIT")]
        public List<Unit>? Units { get; set; } = new List<Unit>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UnitsSpecified => Units?.Count > 0;

        /// <summary>
        /// (optional) Feature groups<br/>
        /// <br/>
        /// Specifies the feature groups within a classification system; these groups are build upon single feature and categorize them.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("FT_GROUPS")]
        [BMEXmlArrayItem("FT_GROUP")]
        public List<FeatureGroup>? FeatureGroups { get; set; } = new List<FeatureGroup>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureGroupsSpecified => FeatureGroups?.Count > 0;

        /// <summary>
        /// (optional) Features of the classification system<br/>
        /// <br/>
        /// Specifies the features used within the classification system .<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("CLASSIFICATION_SYSTEM_FEATURE_TEMPLATES")]
        [BMEXmlArrayItem("CLASSIFICATION_SYSTEM_FEATURE_TEMPLATE")]
        public List<ClassificationSystemFeatureTemplate>? FeatureTemplates { get; set; } = new List<ClassificationSystemFeatureTemplate>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureTemplatesSpecified => FeatureTemplates?.Count > 0;

        /// <summary>
        /// (optional) Classification groups<br/>
        /// <br/>
        /// Contains all groups of the classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("CLASSIFICATION_GROUPS")]
        [BMEXmlArrayItem("CLASSIFICATION_GROUP")]
        public List<ClassificationGroup>? Groups { get; set; } = new List<ClassificationGroup>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GroupsSpecified => Groups?.Count > 0;
    }
}
