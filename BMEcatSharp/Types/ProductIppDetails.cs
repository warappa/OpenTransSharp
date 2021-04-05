using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
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
        /// c
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProductIppDetails() { }

        /// <summary>
        /// <inheritdoc cref="ProductDetails"/>
        /// </summary>
        /// <param name="ipps"></param>
        public ProductIppDetails(IEnumerable<Ipp> ipps)
        {
            if (ipps is null)
            {
                throw new System.ArgumentNullException(nameof(ipps));
            }

            Ipps = ipps.ToList();
        }

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
