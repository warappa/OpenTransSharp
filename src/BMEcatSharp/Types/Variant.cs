using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp;

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
    /// <inheritdoc cref="Variant"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Variant()
    { }

    /// <summary>
    /// <inheritdoc cref="Variant"/>
    /// </summary>
    /// <param name="featureValues"></param>
    public Variant(IEnumerable<MultiLingualString> featureValues)
    {
        if (featureValues is null)
        {
            throw new ArgumentNullException(nameof(featureValues));
        }

        FeatureValues = featureValues.ToList();
    }

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
    [BMEXmlElement("VALUE_IDREF")]
    public List<string> ValueIdRefs { get; set; } = new List<string>();

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
    [BMEXmlElement("SUPPLIER_AID_SUPPLEMENT")]
    //[Obsolete]
    public string? SupplierAidSupplement { get; set; }
}
