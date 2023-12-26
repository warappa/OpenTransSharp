using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (IPP product ID)<br/>
/// <br/>
/// This element contains the identifier ID which is input for the IPP application.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppSupplierPid : IppParamsBase
{
    /// <summary>
    /// <inheritdoc cref="IppSupplierPid"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IppSupplierPid()
    {
    }

    public IppSupplierPid(IppOccurrence occurrence)
    {
        Occurrence = occurrence;
    }
}
