namespace BMEcatSharp;

/// <summary>
/// (Product features)<br/>
/// <br/>
/// This element can be used to (1) describe a product by features and/or to (2) map a product to a group of a classification system.<br/>
/// <br/>
/// The element should not be confused with PRODUCT_COMPONENT, which describes parts of a product (with their own PRODUCT_ID).<br/>
/// <list type="number">
///     <item> The product description by features is done using the FEATURE element.<br/>
///         The feature has to named, and a value has to be assigned to this feature (bmecat:FVALUE_DETAILS).<br/>
///         It can be complemented by the unit of measurement(bmecat:FUNIT).<br/>
///         Moreover, it is possible to provide a detailed, complete definition of the feature (CLASSIFICATION_SYSTEM_FEATURE_TEMPLATE), i.e.data type and domain.<br/>
///         If features are used that are pre-defined by a classification or feature system, then all features belonging to the same system haven to grouped in a common PRODUCT_FEATURES element.<br/>
///         In this area, the respective system has to be referenced (REFERENCE_FEATURE_SYSTEM_NAME), eventually each feature has to be referenced by a FREF element.<br/>
///         <br/>
///         All features that are not pre-defined by a classification or feature system have to be stored in the same PRODUCT_FEATURES element;<br/>
///         this element may not contain REFERENCE_FEATURE_SYSTEM_NAME, REFERENCE_FEATURE_GROUP_ID or REFERENCE_FEATURE_GROUP_NAME elements; its FEATUREsub-elements may not include FREF elements.<br/>
///         <br/>
///         For each PRODUCT_FEATURES area, the feature names must be unique, thus the values of all respective bmecat:FNAME elements are different.<br/>
///         By defining multiple PRODUCT_FEATURES areas it is, however, possible to use the same feature name for various purposes.<br/>
///     </item>
///     <item>
///         The PRODUCT_FEATURES element is also used for mapping products to classifications groups.<br/>
///         The respective classification system has to be referenced (REFERENCE_FEATURE_SYSTEM_NAME); eventually the classification group is either referenced by its identifier (REFERENCE_FEATURE_GROUP_ID) or directly named (REFERENCE_FEATURE_GROUP_NAME).<br/>
///         It is not allowed to define two or more PRODUCT_FEATURES areas with references to the same classification system.
///     </item>
/// </list><br/>
/// <br/>
/// XML-namespace: BMECAT, OpenTrans
/// </summary>
public class ProductFeatures
{
    /// <summary>
    /// <inheritdoc cref="ProductFeatures"/>
    /// </summary>
    public ProductFeatures() { }

    /// <summary>
    /// (optional) Classification or feature system<br/>
    /// <br/>
    /// Name of the referenced classification or feature system<br/>
    /// If the classification system is transferred by the T_NEW_CATALOG transaction and its CLASSIFICATION_SYSTEM element, the value of this element must be equal with the name defined in CLASSIFICATION_SYSTEM_NAME.<br/>
    /// <br/>
    /// Remark: The format for the name (CLASSIFICATION_SYSTEM_NAME) should comply with the following structure:<br/>
    /// "&lt;Name&gt;-&lt;Major Version&gt;.&lt;Minor Version&gt;"<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("REFERENCE_FEATURE_SYSTEM_NAME")]
    public string? SystemName { get; set; }

    /// <summary>
    /// (optional) Group reference<br/>
    /// <br/>
    /// Reference to the unique identifier of an existing group of the respective classification system; this element may only be used if the REFERENCE_FEATURE_GROUP_NAME element is not used.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("REFERENCE_FEATURE_GROUP_ID")]
    public List<ReferenceFeatureGroupId>? GroupIds { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GroupIdsSpecified => GroupIds?.Count > 0;

    /// <summary>
    /// (optional) Group name reference<br/>
    /// <br/>
    /// Reference to the unique, though language-dependent name of an existing group of the respective classification system.<br/>
    /// <br/>
    /// This element may only be used if the REFERENCE_FEATURE_GROUP_ID element is not used.<br/>
    /// <br/>
    /// Notice:<br/>
    /// The group can also be referenced by its language-independent identifier (see REFERENCE_FEATURE_GROUP_ID).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("REFERENCE_FEATURE_GROUP_NAME")]
    public List<MultiLingualString>? GroupNames { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GroupNamesSpecified => GroupNames?.Count > 0;

    /// <summary>
    /// (optional) Additional group reference<br/>
    /// <br/>
    /// This element provides an additional identifier of the same group which has already been referenced in the REFERENCE_FEATURE_GROUP_ID element.<br/>
    /// The element should be only if the classification system defines two different identifier for the same group.<br/>
    /// <br/>
    /// Caution:<br/>
    /// When classifying product according to eCl@ss, this element has to be filled with the eCl@ss field 'idcl' (primary key) and the 'type' attribute has to be set to 'flat'.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("REFERENCE_FEATURE_GROUP_ID2")]
    public List<ReferenceFeatureGroupId2>? GroupId2s { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GroupId2sSpecified => GroupId2s?.Count > 0;

    /// <summary>
    /// (optional) Classification group product order<br/>
    /// <br/>
    /// Order number for the graphical user interface.<br/>
    /// When products of a group are listed they are always represented in ascending order (the first product is the one with the lowest number).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("GROUP_PRODUCT_ORDER")]
    public int? GroupProductOrder { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GroupProductOrderSpecified => GroupProductOrder.HasValue;

    /// <summary>
    /// (optional) Product feature<br/>
    /// <br/>
    /// Information about a single product feature.
    /// </summary>
    [XmlElement("FEATURE")]
    public List<Feature> Features { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool FeaturesSpecified => Features?.Count > 0;
}
