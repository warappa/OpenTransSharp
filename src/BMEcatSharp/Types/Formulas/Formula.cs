using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp;

/// <summary>
/// (Formula)<br/>
/// <br/>
/// This element is used to define a formula on the header level.<br/>
/// All required parameters have to be specified here, this can include default values.<br/>
/// Eventually, the formula can be referenced on the product level, when referencing a formula, default values can be overwritten with values specific for the respective product.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class Formula
{
    /// <summary>
    /// <inheritdoc cref="Formula"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Formula()
    {
        Id = null!;
    }

    /// <summary>
    /// <inheritdoc cref="Formula"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameterDefinitions"></param>
    public Formula(string id, IEnumerable<ParameterDefinition> parameterDefinitions)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        if (parameterDefinitions is null)
        {
            throw new ArgumentNullException(nameof(parameterDefinitions));
        }

        Id = id;
        ParameterDefinitions = parameterDefinitions.ToList();
    }

    /// <summary>
    /// (required) Formula ID<br/>
    /// <br/>
    /// Unique identifier of the formula. This ID is used on the product level to reference the formula.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FORMULA_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (optional) Formula version<br/>
    /// <br/>
    /// Detailled information on the version of the formula.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FORMULA_VERSION")]
    public FormulaVersion? Version { get; set; }

    /// <summary>
    /// (optional) Formula name<br/>
    /// <br/>
    /// E.g., "Formula for livestocks".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FORMULA_NAME")]
    public List<MultiLingualString>? Name { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool NameSpecified => Name?.Count > 0;

    /// <summary>
    /// (optional) Description of the formula<br/>
    /// <br/>
    /// This element is used to describe the formula.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FORMULA_DESCR")]
    public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionSpecified => Description?.Count > 0;

    /// <summary>
    /// (optional) Formula source<br/>
    /// <br/>
    /// Reference to a document, standard or definition describing the formula.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FORMULA_SOURCE")]
    public FormulaSource? Source { get; set; }

    /// <summary>
    /// (optional) Additional multimedia information<br/>
    /// <br/>
    /// Information about multimedia files<br/>
    /// For example more detailed explanations of the formula or any other formula related documents could be added here.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_INFO")]
    public BMEcatMimeInfo? MimeInfo { get; set; }

    /// <summary>
    /// (optional) Function of the formula<br/>
    /// <br/>
    /// Mathematical description of the formula.
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FORMULA_FUNCTION")]
    public FormulaFunction? Function { get; set; }

    /// <summary>
    /// (required) Parameter definitions<br/>
    /// <br/>
    /// List of parameter definitions<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlArray("PARAMETER_DEFINITIONS")]
    [BMEXmlArrayItem("PARAMETER_DEFINITION")]
    public List<ParameterDefinition> ParameterDefinitions { get; set; } = new List<ParameterDefinition>();
}
