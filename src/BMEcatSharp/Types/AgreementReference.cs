using BMEcatSharp.Xml;
using System;
using System.ComponentModel;

namespace BMEcatSharp;

/// <summary>
/// (Skeleton agreement reference)<br/>
/// <br/>
/// This element contains a reference to a skeleton agreement (AGREEMENT), which has been named in the document header.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class AgreementReference
{
    /// <summary>
    /// <inheritdoc cref="AgreementReference"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AgreementReference()
    {
        IdReference = null!;
    }

    /// <summary>
    /// <inheritdoc cref="AgreementReference"/>
    /// </summary>
    /// <param name="idReference"></param>
    public AgreementReference(string idReference)
    {
        if (string.IsNullOrWhiteSpace(idReference))
        {
            throw new ArgumentException($"'{nameof(idReference)}' cannot be null or whitespace.", nameof(idReference));
        }

        IdReference = idReference;
    }

    /// <inheritdoc cref="AgreementReference"/>
    /// <param name="idReference"><inheritdoc cref="IdReference"/></param>
    /// <param name="lineIdReference"><inheritdoc cref="LineIdReference"/></param>
    public AgreementReference(string idReference, string? lineIdReference)
        : this(idReference)
    {
        LineIdReference = lineIdReference;
    }

    /// <summary>
    /// (required) Skeleton agreement ID reference<br/>
    /// <br/>
    /// Reference to the identifier (AGREEMENT_ID) of a skeleton agreement (AGREEMENT).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AGREEMENT_IDREF")]
    public string IdReference { get; set; }

    /// <summary>
    /// (optional) Line ID reference<br/>
    /// <br/>
    /// Reference to a line identifier (AGREEMENT_LINE_ID) of a skeleton agreement (AGREEMENT).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AGREEMENT_LINE_IDREF")]
    public string? LineIdReference { get; set; }
}
