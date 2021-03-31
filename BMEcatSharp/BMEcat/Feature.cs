using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BMEcatSharp
{
    /// <summary>
    /// (Product feature)<br/>
    /// <br/>
    /// This element contains information on a product features (i.e., feature name, data type, explainations, domain).<br/>
    /// Using the VARIANTS feature it is also possible to describe variants of the product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// (required - choice Name/Idref/Template) Feature name<br/>
        /// <br/>
        /// Unique name used to describe the feature within the PRODUCT_FEATURES element.<br/>
        /// <br/>
        /// If in this feature is part of a referenced classification or feature group system, then the feature name must correspond to the name that is defined in the respective system.<br/>
        /// <br/>
        /// This element is language-dependent, thus the feature name has to be given in the language that is set in the document header (HEADER).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FNAME")]
        public List<MultiLingualString>? Name { get; set; } = new List<MultiLingualString>();

        /// <summary>
        /// (required - choice Name/Idref/Template) Feature reference<br/>
        /// <br/>
        /// Reference to the unique ID of a feature (see CLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_IDREF")]
        public string? Idref { get; set; }

        /// <summary>
        /// (required - choice Name/Idref/Template) Feature definition<br/>
        /// <br/>
        /// Definition of the feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FTEMPLATE")]
        public FeatureTemplate? Template { get; set; }

        /// <summary>
        /// (required - choice Values/ValueIdrefs) Feature value<br/>
        /// <br/>
        /// Actual value(s) of the respective feature.<br/>
        /// This element may only be specified if the element VARIANTS is not specified.<br/>
        /// <br/>
        /// FVALUE can occur as a multiple value, e.g. for describing a value range (Range) or a set of values (Set).<br/>
        /// <br/>
        /// If the element references a standard classification system which also pre-defines possible feature values for (alpha-numerical) features, the feature values must be derived from these pre-defined values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FVALUE")]
        public List<MultiLingualString>? Values { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValuesSpecified => Values?.Count > 0;

        /// <summary>
        /// (required) Reference to a value<br/>
        /// <br/>
        /// Reference to the unique identifier of a value.<br/>
        /// The reference must point to a value defined in the document (element ALLOWED_VALUE identified by ALLOWED_VALUE_ID).<br/>
        /// <br/>
        /// This element can only be used for defining features of a classification system; it can not be used for defining features directly for products (PRODUCT_FEATURES) or for configurations (CONFIG_FEATURE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VALUE_IDREF")]
        public List<string>? ValueIdrefs { get; set; } = new List<string>();

        /// <summary>
        /// (required - choice Variants/FValue_ValueIdref) Variants<br/>
        /// <br/>
        /// Designation of the variant.<br/>
        /// This element may only be specified if the element FVALUE is not specified.<br/>
        /// Variants will be transfered only with the element PRODUCT_CONFIG_DETAILS in future versions, therefore the element VARIANTS will be omitted then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("Variants will be transfered only with the element PRODUCT_CONFIG_DETAILS in future versions, therefore the element VARIANTS will be omitted then.")]
        [BMEXmlElement("VARIANTS")]
        public Variants? Variants { get; set; }

        /// <summary>
        /// (optional) Feature unit<br/>
        /// <br/>
        /// Unit of measurement of the feature.<br/>
        /// <br/>
        /// Standard measuring units should be used if possible(refer also to Type dtUNIT).<br/>
        /// <br/>
        /// If the element references a standard classification system which also pre-defines feature units for (numerical) features, the entry for the measuring unit in this element must correspond to the one pre-defined or the element can be left empty.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FUNIT")]
        public string? Unit { get; set; }

        /// <summary>
        /// (optional) Feature order<br/>
        /// <br/>
        /// Order in which the feature must appear in the referenced group in the target system; the order is fixed using ascending integer values.<br/>
        /// <br/>
        /// If the element references a standard classification system which also pre-defines feature orders for features, the entry for the order in this element must correspond to the one predefined or the element can be left empty.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FORDER")]
        public int? Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order.HasValue;

        /// <summary>
        /// (optional) Feature description<br/>
        /// <br/>
        /// Element which can be used to describe the exact meaning of the feature; the purpose of this element is not to explain the value of the feature in more detail.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FDESCR")]
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

        /// <summary>
        /// (optional) Additional details about the feature value<br/>
        /// <br/>
        /// Element which can be used to give more details about the feature value; thus the purpose of this element is to explain the value of the feature in more detail (not the explanation of the feature itself).<br/>
        /// <br/>
        /// This element is mainly useful, for example, for transferring manufacturer-specific value descriptions whenever only standard values are permitted as feature values in the given classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FVALUE_DETAILS")]
        public List<MultiLingualString>? ValueDetails { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValueDetailsSpecified => ValueDetails?.Count > 0;

        /// <summary>
        /// (optional) Feature value type<br/>
        /// <br/>
        /// Indicates how the feature domain is structured.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FVALUE_TYPE")]
        public FeatureValueType? ValueType { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValueTypeSpecified => ValueType.HasValue;
    }
}
