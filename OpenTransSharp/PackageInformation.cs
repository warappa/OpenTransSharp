using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Packaging information)<br/>
    /// <br/>
    /// Information according to the packaging.
    /// </summary>
    public class PackageInformation
    {
        /// <summary>
        /// (optional) Packaging information <br/>
        /// <br/>
        /// Informations about the packaging of a good.<br/>
        /// It is possible to describe more than one packaging.<br/>
        /// The element can be used in a nested way together with the element SUB_PACKAGE to describe e.g.outer and inner packings.
        /// </summary>
        [XmlElement("PACKAGE")]
        public List<Package>? Packages { get; set; } = new List<Package>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PackagesSpecified => Packages?.Count > 0;
    }
}
