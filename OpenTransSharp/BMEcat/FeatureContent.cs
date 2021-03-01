using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Feature content definition)<br/>
    /// <br/>
    /// This element contains detailled information on the feature content, e.g., data type, unit of measurement, application, synonyms, and many more characteristics.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureContent
    {
        /// <summary>
        /// (required) Feature data type<br/>
        /// <br/>
        /// This element contains the data type of the feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_DATATYPE")]
        public FeatureTemplateDataTypeValues DataType { get; set; } = new FeatureTemplateDataTypeValues();

        /// <summary>
        /// (optional) Data type restrictions<br/>
        /// <br/>
        /// List of data type restrictions.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("FT_FACETS")]
        [BMEXmlArrayItem("FT_FACET")]
        public List<FeatureTemplateFacet>? Facets { get; set; } = new List<FeatureTemplateFacet>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FacetsSpecified => Facets?.Count > 0;

        /// <summary>
        /// (optional) Feature domain values<br/>
        /// <br/>
        /// List of allowed values for the feature (only available for enumerative features).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("FT_VALUES")]
        [BMEXmlArrayItem("FT_VALUE")]
        public List<FeatureTemplateValue>? Values { get; set; } = new List<FeatureTemplateValue>();
        public bool ValuesSpecified => Values?.Count > 0;

        /// <summary>
        /// (optional) Feature valency<br/>
        /// <br/>
        /// Indicates whether the product feature can have more than one value (multivalent) or only one value(univalent).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_VALENCY")]
        public FeatureTemplateValencyValues? Valency { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValencySpecified => Valency.HasValue;

        /// <summary>
        /// (optional) Feature unit ID reference<br/>
        /// <br/>
        /// Reference to the unique ID of a unit of measurement.<br/>
        /// The reference must point to a UNIT_ID, which has been defined in the UNIT element for the respective classification system.<br/>
        /// <br/>
        /// This element can only be used for defining features of a classification system.<br/>
        /// Therefore, it can not used on the product level for defining static features (PRODUCT_FEATURES) or for configuration purposes (CONFIG_FEATURE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_UNIT_IDREF")]
        public string? UnitIdref { get; set; }

        /// <summary>
        /// (optional) Feature unit<br/>
        /// <br/>
        /// Unit of measurement for the feature; the unit should be coded in accordance with the dtUNIT data type.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_UNIT")]
        public string? Unit { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UnitSpecified => Unit is string;

        /// <summary>
        /// (optional) Mandatory feature<br/>
        /// <br/>
        /// This element specifies, whether the feature is mandatory or optional; if so, the feature must be used when classifying a respective product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_MANDATORY")]
        public bool? Mandatory { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MandatorySpecified => Mandatory.HasValue;

        /// <summary>
        /// (optional) Feature order<br/>
        /// <br/>
        /// Defines the order (sequence) in which the feature has to be presented in the target system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_Order")]
        public int? Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order.HasValue;

        /// <summary>
        /// (optional) Feature symbol<br/>
        /// <br/>
        /// Symbol of the feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_SYMBOL")]
        public List<MultiLingualString>? Symbols { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SymbolsSpecified => Symbols?.Count > 0;

        /// <summary>
        /// (optional) Feature synonyms<br/>
        /// <br/>
        /// List of synonyms for the feature name.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_SYNONYMS")]
        public FeatureTemplateSynonyms? Synonyms { get; set; }

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// <br/>
        /// For example an illustration which clarifies the measurements relevant for the feature or any other feature related document could be added here.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public BMEcatMimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Feature source<br/>
        /// <br/>
        /// Source for the feature definition which has been given in the FT_DESCR element; e.g. a reference to a document, standard or definition describing the feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_SOURCE")]
        public FeatureTemplateSource? Source { get; set; }

        /// <summary>
        /// (optional) Feature note<br/>
        /// <br/>
        /// The note should be extracted from the source of the definition (element FT_SOURCE).<br/>
        /// It increases the tangibility of the definition.<br/>
        /// <br/>
        /// This element has been adopted from ISO 13584.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_NOTE")]
        public List<MultiLingualString>? Notes { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NotesSpecified => Notes?.Count > 0;

        /// <summary>
        /// (optional) Feature remark<br/>
        /// <br/>
        /// Remark giving additional information about the feature and its definition.<br/>
        /// <br/>
        /// This element has been adopted from ISO 13584.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_REMARK")]
        public MultiLingualString? Remark { get; set; }
    }
}
