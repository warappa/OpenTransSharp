using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Feature value)<br/>
    /// <br/>
    /// This element defines a value as part of the list of values for this feature.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureValue
    {
        /// <summary>
        /// <inheritdoc cref="FeatureValue"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FeatureValue()
        { }

        /// <summary>
        /// <inheritdoc cref="FeatureValue"/>
        /// </summary>
        /// <param name="simple"></param>
        public FeatureValue(string simple)
        {
            if (string.IsNullOrWhiteSpace(simple))
            {
                throw new ArgumentException($"'{nameof(simple)}' cannot be null or whitespace.", nameof(simple));
            }

            Simple = simple;
        }

        /// <summary>
        /// <inheritdoc cref="FeatureValue"/>
        /// </summary>
        /// <param name="text"></param>
        public FeatureValue(IEnumerable<MultiLingualString> text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text.ToList();
        }

        /// <summary>
        /// <inheritdoc cref="FeatureValue"/>
        /// </summary>
        /// <param name="range"></param>
        public FeatureValue(ValueRange range)
        {
            Range = range ?? throw new ArgumentNullException(nameof(range));
        }

        /// <summary>
        /// <inheritdoc cref="FeatureValue"/>
        /// </summary>
        /// <param name="idRef"></param>
        /// <returns></returns>
        public static FeatureValue FromIdRef(string idRef)
        {
            if (string.IsNullOrWhiteSpace(idRef))
            {
                throw new ArgumentException($"'{nameof(idRef)}' cannot be null or whitespace.", nameof(idRef));
            }

            return new()
            {
                IdRef = idRef
            };
        }

        /// <summary>
        /// (required - choice ValueIdRef/ValueSimple/ValueText/ValueRange) Reference to a value<br/>
        /// <br/>
        /// Reference to the unique identifier of a value.<br/>
        /// <br/>
        /// The reference must point to a value defined in the document (element ALLOWED_VALUE identified by ALLOWED_VALUE_ID).<br/>
        /// This element can only be used for defining features of a classification system; it can not be used for defining features directly for products (PRODUCT_FEATURES) or for configurations (CONFIG_FEATURE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VALUE_IDREF")]
        public string? IdRef { get; set; }

        /// <summary>
        /// (required - choice ValueIdRef/ValueSimple/ValueText/ValueRange) Atomic value<br/>
        /// <br/>
        /// A single, atomic value.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VALUE_SIMPLE")]
        public string? Simple { get; set; }

        /// <summary>
        /// (required - choice ValueIdRef/ValueSimple/ValueText/ValueRange) Text value<br/>
        /// <br/>
        /// This element contains a text.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VALUE_TEXT")]
        public List<MultiLingualString>? Text { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TextSpecified => Text?.Count > 0;

        /// <summary>
        /// (required - choice ValueIdRef/ValueSimple/ValueText/ValueRange) Interval of values<br/>
        /// <br/>
        /// Definition of an interval of values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VALUE_RANGE")]
        public ValueRange? Range { get; set; }

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
        public ConfigurationInformation? ConfigurationInformation { get; set; }

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
        [XmlIgnore]
        public bool? DefaultFlag { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [BMEXmlElement("DEFAULT_FLAG")]
        public string? DefaultFlagForSerializer { get => DefaultFlag is null ? null : DefaultFlag == true ? "true" : "false"; set => DefaultFlag = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DefaultFlagForSerializerSpecified => DefaultFlag == true;
    }
}
