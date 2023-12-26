using OpenTransSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OpenTransSharp;

/// <summary>
/// (Total taxes)<br/>
/// <br/>
/// List of all applied taxes (summed up per tax).<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class TotalTax
{
    /// <summary>
    /// <inheritdoc cref="TotalTax"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public TotalTax() { }

    /// <summary>
    /// <inheritdoc cref="TotalTax"/>
    /// </summary>
    /// <param name="taxDetailsFixes"></param>
    public TotalTax(IEnumerable<TaxDetailsFix> taxDetailsFixes)
    {
        if (taxDetailsFixes is null)
        {
            throw new ArgumentNullException(nameof(taxDetailsFixes));
        }

        TaxDetailsFixes = taxDetailsFixes.ToList();
    }

    /// <summary>
    /// (required) Tax details<br/>
    /// <br/>
    /// Information to an applied tax.
    /// </summary>
    [OpenTransXmlElement("TAX_DETAILS_FIX")]
    public List<TaxDetailsFix> TaxDetailsFixes { get; set; } = new List<TaxDetailsFix>();
}
