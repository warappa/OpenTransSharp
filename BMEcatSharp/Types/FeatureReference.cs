using BMEcatSharp.Xml;
using System;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Reference to a feature)<br/>
    /// <br/>
    /// This element contains a reference to a feature, which is defined in a classification system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureReference
    {
        /// <summary>
        /// <inheritdoc cref="FeatureReference"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FeatureReference()
        {
            SystemName = null!;
            Idref = null!;
        }

        /// <summary>
        /// <inheritdoc cref="FeatureReference"/>
        /// </summary>
        /// <param name="systemName"></param>
        /// <param name="idref"></param>
        public FeatureReference(string systemName, string idref)
        {
            if (string.IsNullOrWhiteSpace(systemName))
            {
                throw new ArgumentException($"'{nameof(systemName)}' cannot be null or whitespace.", nameof(systemName));
            }

            if (string.IsNullOrWhiteSpace(idref))
            {
                throw new ArgumentException($"'{nameof(idref)}' cannot be null or whitespace.", nameof(idref));
            }

            SystemName = systemName;
            Idref = idref;
        }

        /// <summary>
        /// (required) Classification or feature system<br/>
        /// <br/>
        /// Name of the referenced classification or feature system.<br/>
        /// If the classification system is transferred by the T_NEW_CATALOG transaction and its CLASSIFICATION_SYSTEM element, the value of this element must be equal with the name defined in CLASSIFICATION_SYSTEM_NAME.<br/>
        /// <br/>
        /// Remark:<br/>
        /// The format for the name (CLASSIFICATION_SYSTEM_NAME) should comply with the following structure:<br/>
        /// "&lt;Name&gt;-&lt;Major Version&gt;.&lt;Minor Version&gt;<br/>
        /// <br/>
        /// See also: Predefined values for element REFERENCE_FEATURE_SYSTEM_NAME<br/>
        /// <br/>
        /// Examples:<br/>
        /// ECLASS-4.1, UNSPSC-6.0801<br/>
        /// <c><REFERENCE_FEATURE_SYSTEM_NAME>ECLASS-4.1</REFERENCE_FEATURE_SYSTEM_NAME></c><br/>
        /// <br/>
        /// <see cref="ReferenceFeatureSystemNameValues"/><br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("REFERENCE_FEATURE_SYSTEM_NAME")]
        public string SystemName { get; set; }

        /// <summary>
        /// (required) Feature reference<br/>
        /// <br/>
        /// Reference to the unique ID of a feature (see CLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_IDREF")]
        public string Idref { get; set; }
    }
}
