using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp;

/// <summary>
/// (Product configuration information)<br/>
/// <br/>
/// This element contains configuration information about the product.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class ProductConfigurationDetails
{
    /// <summary>
    /// <inheritdoc cref="ProductConfigurationDetails"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProductConfigurationDetails()
    {

    }

    /// <summary>
    /// <inheritdoc cref="ProductContacts"/>
    /// </summary>
    /// <param name="steps"></param>
    /// <param name="rules"></param>
    /// <param name="formulas"></param>
    public ProductConfigurationDetails(IEnumerable<ConfigurationStep> steps, IEnumerable<Term> rules, IEnumerable<ConfigurationFormula> formulas)
    {
        if (steps is null)
        {
            throw new ArgumentNullException(nameof(steps));
        }

        if (rules is null)
        {
            throw new ArgumentNullException(nameof(rules));
        }

        if (formulas is null)
        {
            throw new ArgumentNullException(nameof(formulas));
        }

        Steps = steps.ToList();
        Rules = rules.ToList();
        Formulas = formulas.ToList();
    }

    /// <summary>
    /// (required) Configuration step<br/>
    /// <br/>
    /// Information on a configuration step.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CONFIG_STEP")]
    public List<ConfigurationStep> Steps { get; set; } = new List<ConfigurationStep>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool StepsSpecified => Steps?.Count > 0;

    /// <summary>
    /// (optional) Predefined configurations<br/>
    /// <br/>
    /// List of predefined configurations.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PREDEFINED_CONFIGS")]
    public PredefinedConfigurations? PredefinedConfigurations { get; set; }

    /// <summary>
    /// (required) Config rules<br/>
    /// <br/>
    /// This element contains a list of terms (TERM).<br/>
    /// This terms are serving two functions.<br/>
    /// <list type="bullet">
    /// <item> First they allow the destinction between valid and not valid configurations.</item>
    /// <item> Second they are used to calculate values within configurations.</item>
    /// </list>
    /// <br/>
    /// Which of this two function a term serves depends on the content of the attribute "type" within the element TERM.<br/>
    /// <br/>
    /// The value of the attribute "type" is set to "constraint" when the terms is uesed for restricting valid configurations.<br/>
    /// When the term is used to describe a valid configuartion the term expression (TERM_EXPRESSION) has to be "true".<br/>
    /// A non-valid configuration is specified via the term expression (TERM_EXPRESSION) "false".<br/>
    /// <br/>
    /// Caution:<br/>
    /// For simplifying the definition and evaluation of these constraints either only valid configurations or only non-valid configurations are permitted within one product.<br/>
    /// This means that all terms with the attribute "type" equals "constraint" are containing all the value "true" or are containing all the value "false".<br/>
    /// <br/>
    /// Terms with the type "function" are used for calculating values depending on configurations (e.g. the weight of a product depending on the size specified in the configuration).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlArray("CONFIG_RULES")]
    [BMEXmlArrayItem("TERM")]
    public List<Term> Rules { get; set; } = new List<Term>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RulesSpecified => Rules?.Count > 0;

    /// <summary>
    /// (required) Configuration formulas<br/>
    /// <br/>
    /// This element contains a list of configuration formulas which refer to formulars of the global formula dictionary.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlArray("CONFIG_FORMULAS")]
    [BMEXmlArrayItem("CONFIG_FORMULA")]
    public List<ConfigurationFormula> Formulas { get; set; } = new List<ConfigurationFormula>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool FormulasSpecified => Formulas?.Count > 0;
}
