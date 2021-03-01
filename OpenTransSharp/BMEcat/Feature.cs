using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
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
        /// (required) Feature name<br/>
        /// <br/>
        /// Unique name used to describe the feature within the PRODUCT_FEATURES element.<br/>
        /// <br/>
        /// If in this feature is part of a referenced classification or feature group system, then the feature name must correspond to the name that is defined in the respective system.<br/>
        /// <br/>
        /// This element is language-dependent, thus the feature name has to be given in the language that is set in the document header (HEADER).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FNAME")]
        public List<MultiLingualString> FeatureNames { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureNamesSpecified => FeatureNames?.Count > 0;

        /// <summary>
        /// (required) Feature reference<br/>
        /// <br/>
        /// Reference to the unique ID of a feature (seeCLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_IDREF")]
        public string FtIdref { get; set; }

        /// <summary>
        /// (required) Feature definition<br/>
        /// <br/>
        /// Definition of the feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FTEMPLATE")]
        public FeatureTemplate FeatureTemplate { get; set; }

        /// <summary>
        /// (required) Feature value<br/>
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
        [Required]
        [BMEXmlElement("FVALUE")]
        public List<MultiLingualString> FeatureValues { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureValuesSpecified => FeatureValues?.Count > 0;

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
        [Required]
        [BMEXmlElement("VALUE_IDREF")]
        public List<string> ValueIdrefs { get; set; } = new List<string>();

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
        public string? FeatureUnit { get; set; }

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
        public int? FeatureOrder { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureOrderSpecified => FeatureOrder.HasValue;

        /// <summary>
        /// (optional) Feature description<br/>
        /// <br/>
        /// Element which can be used to describe the exact meaning of the feature; the purpose of this element is not to explain the value of the feature in more detail.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FDESCR")]
        public List<MultiLingualString>? FeatureDescriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureDescriptionsSpecified => FeatureDescriptions?.Count > 0;

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
        public List<MultiLingualString>? FeatureValueDetails { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureValueDetailsSpecified => FeatureValueDetails?.Count > 0;

        /// <summary>
        /// (optional) Feature value type<br/>
        /// <br/>
        /// Indicates how the feature domain is structured.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FVALUE_TYPE")]
        public FeatureValueTypeValues? FeatureValueType { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureValueTypeSpecified => FeatureValueType.HasValue;
    }
    /// <summary>
    /// (Variants)<br/>
    /// <br/>
    /// This element describes variants of products.<br/>
    /// The product variants have no effect on the price of the product.<br/>
    /// The variants are described using the element VARIANT.<br/>
    /// These variants expand the basic product number (SUPPLIER_PID) of the product by a suffix.<br/>
    /// VARIANTS is used to link together different products of the same price and with only a few different feature values by expanding the basic product number by a few positions depending on the variant chosen in order to achieve unique identification of the variant.<br/>
    /// <br/>
    /// The basic product number must already be unique when used alone even if it is to be used with variants.<br/>
    /// <br/>
    /// This element will not be used in the future.
    /// </summary>
    public class Variants
    {
        /// <summary>
        /// (required) Variant<br/>
        /// <br/>
        /// Description of a variant (feature value and product number supplement).
        /// </summary>
        [BMEXmlElement("VARIANT")]
        public List<Variant> FeatureVariants { get; set; } = new List<Variant>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureVariantsSpecified => FeatureVariants?.Count > 0;

        /// <summary>
        /// (required) Variant<br/>
        /// <br/>
        /// Defines which order is to be used to link the product number supplement (SUPPLIER_AID_SUPPLEMENT) with the basic product number (SUPPLIER_PID); the product number expansions are linked to the value VORDER in ascending order.
        /// </summary>
        [BMEXmlElement("VORDER")]
        public int VariantOrder { get; set; }
    }
    /// <summary>
    /// (Variant)<br/>
    /// <br/>
    /// Description of a possible variant using the relevant feature values and the corresponding article number supplement.<br/>
    /// For a more detailed explanation please refer to the following Example.<br/>
    /// This element will not be used in the future.
    /// </summary>
    public class Variant
    {
        /// <summary>
        /// (required) Feature value<br/>
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
        [Required]
        [BMEXmlElement("FVALUE")]
        public List<MultiLingualString> FeatureValues { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureValuesSpecified => FeatureValues?.Count > 0;

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
        [Required]
        [BMEXmlElement("VALUE_IDREF")]
        public List<string> ValueIdrefs { get; set; } = new List<string>();

        /// <summary>
        /// (required) Article number supplement<br/>
        /// <br/>
        /// For every selection value within one variant an unique supplement of the basic product number must be transferred.<br/>
        /// Through the link of all the supplements a further unique number must be created.<br/>
        /// If there are several VARIANTS elements defined for one article, particular care must be taken that the supplements to the article numbers can be clearly separated from the article number resulting from the selection made.<br/>
        /// This can be achieved, for example, if the supplement is always a fixed length (always 3 figures "003" = black) or by integrating a hyphen ("-red").<br/>
        /// The length of the basic product number + the length of all supplements may not be longer than 32 characters(see field length of SUPPLIER_PID).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("SUPPLIER_AID_SUPPLEMENT")]
        public string SupplierAidSupplement { get; set; }
    }
}
