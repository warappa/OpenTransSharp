using System.Collections.Generic;

namespace OpenTransSharp
{
    /// <summary>
    /// (Area)<br/>
    /// <br/>
    /// This element defines an area by merging multiple countries or regions (TERRITORY) to a unit, e.g. 'European Union' or 'Business Services Middle East'.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Area
    {
        /// <summary>
        /// (required) Area Identification<br/>
        /// <br/>
        /// Unique identifier of the area.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AREA_ID")]
        public string AreaId { get; set; }

        /// <summary>
        /// (required) Name of the area<br/>
        /// <br/>
        /// Name of the area, e.g., "European Union".<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AREA_NAME")]
        public MultiLingualString? AreaName { get; set; }

        /// <summary>
        /// (required) Description of the area<br/>
        /// <br/>
        /// This element can be used to describe the area in more detail.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AREA_DESCR")]
        public MultiLingualString? AreaDescription { get; set; }

        /// <summary>
        /// (optional) Countries and regions<br/>
        /// <br/>
        /// List of countries and regions.<br/>
        /// <br/>
        /// Territory (i.e. country, state, region) coded according to ISO 3166.
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("TERRITORIES")]
        [BMEXmlArrayItem("TERRITORY")]
        public List<CountryCode>? Territories { get; set; } = new List<CountryCode>();
    }
}
