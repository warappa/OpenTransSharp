using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Supplier)<br/>
    /// <br/>
    /// This element contains information on the supplier.<br/>
    /// This element will not be used in the future.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [Obsolete("This element will not be used in the future.")]
    public class Supplier
    {
        /// <summary>
        /// (optional) Supplier ID<br/>
        /// <br/>
        /// Unique identifier of the supplier, which can be used by the buyer for internal processes; the "type" attribute determines the ID type.
        /// </summary>
        [BMEXmlElement("SUPPLIER_ID")]
        public List<SupplierId>? SupplierIds { get; set; } = new List<SupplierId>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SupplierIdsSpecified => SupplierIds?.Count > 0;

        /// <summary>
        /// (required) Supplier name<br/>
        /// <br/>
        /// Name of the supplying company respectively organization.
        /// </summary>
        [Required]
        [BMEXmlElement("SUPPLIER_ID")]
        public string SupplierName { get; set; }

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// For example logos, company profiles or other supplier related documents could be added here.
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }
    }
}
