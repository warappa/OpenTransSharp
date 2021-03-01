using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Packaging information)<br/>
    /// <br/>
    /// Informations about the packaging of a good.<br/>
    /// It is possible to describe more than one packaging.<br/>
    /// The element can be used in a nested way together with the element SUB_PACKAGE to describe e.g.outer and inner packings.
    /// </summary>
    public class Package
    {
        /// <summary>
        /// (optional) Package number <br/>
        /// <br/>
        /// Unique package number.<br/>
        /// <br/>
        /// Max length: 50
        /// </summary>
        [XmlElement("PACKAGE_ID")]
        public List<string>? Ids { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IdsSpecified => Ids?.Count > 0;

        /// <summary>
        /// (optional) Package description <br/>
        /// <br/>
        /// Textual description of the package.
        /// </summary>
        [XmlElement("PACKAGE_DESCR")]
        public List<MultiLingualString>? Descriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionsSpecified => Descriptions?.Count > 0;

        /// <summary>
        /// (optional) Packing unit code<br/>
        /// <br/>
        /// Code for the packing unit; has to be selected from the list of predefined values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [MaxLength(3)]
        [BMEXmlElement("PACKING_UNIT_CODE")]
        public string PackingUnitCode { get; set; }

        /// <summary>
        /// (optional) Packing unit description <br/>
        /// <br/>
        /// Description of the packing unit, i.e. explaination, additional information, hints etc.
        /// </summary>
        [XmlElement("PACKING_UNIT_DESCR")]
        public List<MultiLingualString>? PackingUnitDescriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PackingUnitDescriptionsSpecified => PackingUnitDescriptions?.Count > 0;

        /// <summary>
        /// (optional) Number of units per package<br/>
        /// <br/>
        /// Number of order units (ORDER_UNIT) related to a package.
        /// </summary>
        [XmlElement("PACKAGE_ORDER_UNIT_QUANTITY")]
        public decimal? OrderUnitQuantity { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderUnitQuantitySpecified => OrderUnitQuantity.HasValue;

        /// <summary>
        /// (optional) Number of packages<br/>
        /// <br/>
        /// Number of packages of a particular package type (PACKING_UNIT_CODE).
        /// </summary>
        [XmlElement("PACKAGE_QUANTITY")]
        public decimal? Quantity { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool QuantitySpecified => Quantity.HasValue;

        /// <summary>
        /// (optional) Package dimensions<br/>
        /// <br/>
        /// Information on the package dimension from the view of business logistics.<br/>
        /// </summary>
        [XmlElement("PACKAGE_DIMENSIONS")]
        public PackageDimensions? Dimensions { get; set; }

        /// <summary>
        /// (optional) Reference to means of transportation<br/>
        /// <br/>
        /// Reference to a unique identifier to means of transportation.<br/>
        /// The element refers to an ID (MEANS_OF_TRANSPORT_ID) in the same document.<br/>
        /// </summary>
        [XmlElement("MEANS_OF_TRANSPORT_IDREF")]
        public List<MeansOfTransportIdRef>? MeansOfTransportIdRefs { get; set; } = new List<MeansOfTransportIdRef>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MeansOfTransportIdRefsSpecified => MeansOfTransportIdRefs?.Count > 0;

        /// <summary>
        /// (optional) Sub packages<br/>
        /// <br/>
        /// List of sub-packages of the package.<br/>
        /// </summary>
        [XmlElement("SUB_PACKAGES")]
        public SubPackages? SubPackages { get; set; }
    }
}
