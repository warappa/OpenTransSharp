using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenTransSharp
{
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
        /// (optional) Tax details<br/>
        /// <br/>
        /// Information to an applied tax.
        /// </summary>
        [OpenTransXmlElement("TAX_DETAILS_FIX")]
        public List<TaxDetailsFix> TaxDetailsFixes { get; set; } = new List<TaxDetailsFix>();
    }
}
