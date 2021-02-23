using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Feature value)<br/>
    /// <br/>
    /// This element defines a value as part of the list of values for this feature.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureTemplateValue
    {
        /// <summary>
        /// (required) Reference to a value<br/>
        /// <br/>
        /// Reference to the unique identifier of a value.<br/>
        /// <br/>
        /// The reference must point to a value defined in the document (element ALLOWED_VALUE identified by ALLOWED_VALUE_ID).<br/>
        /// This element can only be used for defining features of a classification system; it can not be used for defining features directly for products (PRODUCT_FEATURES) or for configurations (CONFIG_FEATURE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("VALUE_IDREF")]
        public string ValueIdref { get; set; }

        /// <summary>
        /// (required) Atomic value<br/>
        /// <br/>
        /// A single, atomic value.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("VALUE_SIMPLE")]
        public string ValueSimple { get; set; }

        /// <summary>
        /// (required) Text value<br/>
        /// <br/>
        /// This element contains a text.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("VALUE_TEXT")]
        public List<MultiLingualString> ValueTexts { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValueTextsSpecified => ValueTexts?.Count > 0;

        /// <summary>
        /// (required) Interval of values<br/>
        /// <br/>
        /// Definition of an interval of values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("VALUE_RANGE")]
        public ValueRange ValueRange { get; set; }

        /// <summary>
        /// (optional) Additonal multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// <br/>
        /// For example an illustration which clarifies the value could be added here.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Configuration information<br/>
        /// <br/>
        /// Information on creating order numbers and prices if the enumerative value is subject of product configuration.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONFIG_INFO")]
        public ConfigInfo ConfigInfo { get; set; }

        /// <summary>
        /// (optional) Value order<br/>
        /// <br/>
        /// The order determines how a list of values is presented in target systems, beginning with the lowest number.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VALUE_ORDER")]
        public int? ValueOrder { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValueOrderSpecified => ValueOrder.HasValue;

        /// <summary>
        /// (optional) Default flag<br/>
        /// <br/>
        /// Sets the default value of a list of values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("DEFAULT_FLAG")]
        public bool? DefaultFlag { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DefaultFlagSpecified => DefaultFlag.HasValue;
    }
}
