using System.Collections.Generic;

namespace OpenTransSharp
{
    /// <summary>
    /// (IPP details)<br/>
    /// <br/>
    /// This element contains product-specific information on IPP applications.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ProductIppDetails
    {
        /// <summary>
        /// (required) IPP application<br/>
        /// <br/>
        /// Is used to overwrite and particularise specifications of an IPP application which have been made in the header in the element IPP_DEFINITION with new specifications on product level.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP")]
        public List<Ipp> Ipps { get; set; } = new List<Ipp>();
    }
}
