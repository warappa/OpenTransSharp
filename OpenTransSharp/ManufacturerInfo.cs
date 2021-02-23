using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Manufacturer information)<br/>
    /// <br/>
    /// The element MANUFACTURER_INFO contains information assigned to the article by the manufacturer.
    /// </summary>
    public class ManufacturerInfo
    {
        /// <summary>
        /// (required) Reference to the manufacturer<br/>
        /// <br/>
        /// This element provides a reference to the manufacturer.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("MANUFACTURER_IDREF")]
        public ManufacturerIdref ManufacturerIdref { get; set; }

        /// <summary>
        /// (required) Product ID of the manufacturer<br/>
        /// <br/>
        /// Product ID of the manufacturer.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("MANUFACTURER_PID")]
        public string ManufacturerPID { get; set; }

        /// <summary>
        /// (optional) Manufacturer type description<br/>
        /// <br/>
        /// The manufacturer’s type description is a name for the product which may, in certain circumstances, be more widely-known than the correct product name.<br/>
        /// When a manufacturer’s type description is specified, the name of the manufacturer must also be specified (MANUFACTURER_NAME).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MANUFACTURER_TYPE_DESCR")]
        public List<MultiLingualString>? ManufacturerTypeDescriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ManufacturerTypeDescriptionsSpecified => ManufacturerTypeDescriptions?.Count > 0;
    }
}
