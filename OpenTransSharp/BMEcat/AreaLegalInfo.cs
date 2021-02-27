using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Areas-specific legal information)<br/>
    /// <br/>
    /// This element contains legal information valid for an area or a country.<br/>
    /// Legal information may include 'General Terms of Delivery', information on the management, or the legal venue.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class AreaLegalInfo
    {
        /// <summary>
        /// (optional - choice Territories/AreaRefs) Territory<br/>
        /// <br/>
        /// Territory (i.e. country, state, region) coded according to ISO 3166.<br/>
        /// <br/>
        /// The element specifies in which territories (regions, states, countries, continents) the prices are vaild which means that the products from the catalog are available.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TERRITORY")]
        public List<CountryCode>? Territories { get; set; } = new List<CountryCode>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TerritoriesSpecified => Territories?.Count > 0;

        /// <summary>
        /// (optional - choice Territories/AreaRefs) Area references<br/>
        /// <br/>
        /// List of references to areas.<br/>
        /// <br/>
        /// Areas, where the prices are valid which means that the products from the catalog are available.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("AREA_REFS")]
        [BMEXmlArrayItem("AREA_IDREF")]
        public List<string>? AreaRefs { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AreaRefsSpecified => AreaRefs?.Count > 0;

        /// <summary>
        /// (optional) Legal text<br/>
        /// <br/>
        /// Text of a legal information. This text can also be transferred as a file using the MIME element.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("LEGAL_TEXT")]
        public MultiLingualString? LegalText { get; set; }

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// For instance the general terms and conditions or other documents could be added here.
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public BMEcatMimeInfo? MimeInfo { get; set; }
    }
}
