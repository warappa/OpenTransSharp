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
        /// (required - choice ValueIdref/ValueSimple/ValueText,ValueRange) Reference to a value<br/>
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
        public string Idref { get; set; }

        /// <summary>
        /// (required - choice ValueIdref/ValueSimple/ValueText,ValueRange) Atomic value<br/>
        /// <br/>
        /// A single, atomic value.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("VALUE_SIMPLE")]
        public string Simple { get; set; }

        /// <summary>
        /// (required - choice ValueIdref/ValueSimple/ValueText,ValueRange) Text value<br/>
        /// <br/>
        /// This element contains a text.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("VALUE_TEXT")]
        public MultiLingualString Text { get; set; }

        /// <summary>
        /// (required - choice ValueIdref/ValueSimple/ValueText,ValueRange) Interval of values<br/>
        /// <br/>
        /// Definition of an interval of values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("VALUE_RANGE")]
        public ValueRange Range { get; set; }

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
        public BMEcatMimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Configuration information<br/>
        /// <br/>
        /// Information on creating order numbers and prices if the enumerative value is subject of product configuration.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONFIG_INFO")]
        public ConfigurationInformation ConfigurationInformation { get; set; }

        /// <summary>
        /// (optional) Value order<br/>
        /// <br/>
        /// The order determines how a list of values is presented in target systems, beginning with the lowest number.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VALUE_ORDER")]
        public int? Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order.HasValue;

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
