using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (Reference to an IPP product configuration)<br/>
/// <br/>
/// This element determines if and how identifiers of product configurations have to be used when calling an IPP application.<br/>
/// This element must be empty and the occurence-attribute specifies, whether providing such an identifier is optional or mandatory.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppProductconfigIdRef : IppParamsBase
{
    /// <summary>
    /// <inheritdoc cref="IppProductconfigIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IppProductconfigIdRef()
    {
    }

    /// <summary>
    /// <inheritdoc cref="IppProductconfigIdRef"/>
    /// </summary>
    /// <param name="occurrence"></param>
    public IppProductconfigIdRef(IppOccurrence occurrence)
    {
        Occurrence = occurrence;
    }
}
