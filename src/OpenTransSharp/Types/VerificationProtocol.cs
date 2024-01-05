﻿namespace OpenTransSharp;

/// <summary>
/// (Verification report as XML protocol)<br/>
/// <br/>
/// The element contains a representation of the protocol records coded in the RESULT_CODE and a description of the record (RESULT_DESCR).<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class VerificationProtocol
{
    /// <summary>
    /// <inheritdoc cref="VerificationProtocol"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerificationProtocol()
    {
        ResultCode = null!;
    }

    /// <summary>
    /// <inheritdoc cref="VerificationProtocol"/>
    /// </summary>
    /// <param name="resultCode"></param>
    public VerificationProtocol(string resultCode)
    {
        if (string.IsNullOrWhiteSpace(resultCode))
        {
            throw new ArgumentException($"'{nameof(resultCode)}' cannot be null or whitespace.", nameof(resultCode));
        }

        ResultCode = resultCode;
    }

    /// <summary>
    /// (required) Coded protocol record<br/>
    /// <br/>
    /// Coded protocol record.<br/>
    /// Since a lack of standards in the area of signature verification reports the used coding-standard should be constituted between the partners.
    /// </summary>
    [OpenTransXmlElement("RESULT_CODE")]
    public string ResultCode { get; set; }

    /// <summary>
    /// (optional) Protocol record description<br/>
    /// <br/>
    /// Description of a protocol record in a human-readable form.<br/>
    /// </summary>
    [OpenTransXmlElement("RESULT_DESCR")]
    public List<global::BMEcatSharp.Language>? ResultDescriptions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ResultDescriptionsSpecified => ResultDescriptions?.Count > 0;
}
