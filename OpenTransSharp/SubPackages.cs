using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Sub packages)<br/>
    /// <br/>
    /// The element containes a list of sub-packages.<br/>
    /// Via this element nested package-relations can be modeled.
    /// </summary>
    public class SubPackages
    {
        /// <summary>
        /// (required) Packaging information<br/>
        /// <br/>
        /// Informations about the packaging of a good.<br/>
        /// It is possible to describe more than one packaging.<br/>
        /// The element can be used in a nested way together with the element SUB_PACKAGE to describe e.g.outer and inner packings.
        /// </summary>
        [XmlElement("PACKAGE")]
        public List<Package>? Packages { get; set; } = new List<Package>();
    }
}
