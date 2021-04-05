using BMEcatSharp.Xml;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Parameter definition)<br/>
    /// <br/>
    /// This element defines the parameter in the document header.<br/>
    /// Referencing this parameter and setting a product-specific value takes place on the product level by the PARAMETERS element.<br/>
    /// Besides using the parameters to calculate the formula, the paramters could also be displayed as a list in the target system.<br/>
    /// Often this allready enables the buyer to evaluate the price.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ParameterDefinition
    {
        /// <summary>
        /// <inheritdoc cref="ParameterDefinition"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParameterDefinition()
        {
            Symbol = null!;
        }

        /// <summary>
        /// <inheritdoc cref="ParameterDefinition"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="basics"></param>
        /// <param name="featureReference"></param>
        public ParameterDefinition(string symbol, ParameterBasics basics, FeatureReference featureReference)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new System.ArgumentException($"'{nameof(symbol)}' cannot be null or whitespace.", nameof(symbol));
            }

            Symbol = symbol;
            Basics = basics ?? throw new System.ArgumentNullException(nameof(basics));
            FeatureReference = featureReference ?? throw new System.ArgumentNullException(nameof(featureReference));
        }

        /// <summary>
        /// (required) Parameter symbol<br/>
        /// <br/>
        /// This element contains the parameter symbol.<br/>
        /// The symbol can be used in formulas where its represents the parameter.<br/>
        /// In addition, the symbol can be used on the product level for setting product-specific parameter values.<br/>
        /// The symbol must start with a character followed by a combination of characters and numbers.<br/>
        /// Country-specific characters, i.e.vowels, are not allowed.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_SYMBOL")]
        public string Symbol { get; set; }

        /// <summary>
        /// (required) Basic parameter information<br/>
        /// <br/>
        /// Basic information on the parameter; it is not necessary, if the parameter has been derived from a property of a classification system(then, it is described there).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_BASICS")]
        public ParameterBasics Basics { get; set; } = new ParameterBasics();

        /// <summary>
        /// (required) Reference to a feature<br/>
        /// <br/>
        /// Reference to a feature which is defined in a classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FREF")]
        public FeatureReference FeatureReference { get; set; } = new FeatureReference();

        /// <summary>
        /// (optional) Parameter origin<br/>
        /// <br/>
        /// This element determines the origin of the parameter.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_ORIGIN")]
        public ParameterOrigin? Origin { get; set; }

        /// <summary>
        /// (optional) Default value of the parameter<br/>
        /// <br/>
        /// This element sets a default value for the parameter.<br/>
        /// The parameter can be changed on the product level by the PARAMETER_VALUE element.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_DEFAULT_VALUE")]
        public string? DefaultValue { get; set; }

        /// <summary>
        /// (optional) Parameter type<br/>
        /// <br/>
        /// Marks the meaning of the parameter.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_MEANING")]
        public ParameterMeaning? Meaning { get; set; }

        /// <summary>
        /// <br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_ORDER")]
        public int? Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order.HasValue;
    }
}
