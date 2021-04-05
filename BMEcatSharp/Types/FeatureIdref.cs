using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// Feature reference<br/>
    /// <br/>
    /// Reference to the unique ID of a feature (seeCLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureIdref
    {
        /// <summary>
        /// <inheritdoc cref="FeatureIdref"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FeatureIdref()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="FeatureIdref"/>
        /// </summary>
        /// <param name="value"></param>
        public FeatureIdref(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 60
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
