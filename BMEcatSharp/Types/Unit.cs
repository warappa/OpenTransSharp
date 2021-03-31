using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Unit of measurement)<br/>
    /// <br/>
    /// Describes a unit of measurement used in the classification system.<br/>
    /// <br/>
    /// Caution:<br/>
    /// The element UNIT must not be confused with the data types dtUNIT or dtPUNIT.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// (optional) Unit system<br/>
        /// <br/>
        /// This attribute sets the unit system to which the unit of measurement belongs<br/>
        /// <br/>
        /// See <see cref="UnitSystemValues"/>. Custom values may be used.
        /// </summary>
        [XmlAttribute("system")]
        public string? System { get; set; }

        /// <summary>
        /// (required) Unit ID<br/>
        /// <br/>
        /// Specifies the unique identification of the unit of measurement within the classification system; this identification is required for the description of multi-lingual units within a classification system as well as for referencing the measuring units from the classification group.<br/>
        /// <br/>
        /// Identification from standard unit systems should be used(e.g., UNECE, SI)<br/>
        /// Example: C62<br/>
        /// (piece according to UNECE Recommendation 20, http://www.unece.org/cefact/rec/rec20en.htm) <br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("UNIT_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (optional) Unit name<br/>
        /// <br/>
        /// Contains the name of the unit of measurement, e.g., "Megahertz".<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("UNIT_NAME")]
        public List<MultiLingualString>? Name { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NameSpecified => Name?.Count > 0;

        /// <summary>
        /// (optional) Unit short name<br/>
        /// <br/>
        /// Short name of the unit in addition to its name, e.g., "MHz" for "Megahertz".<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("UNIT_SHORTNAME")]
        public List<MultiLingualString>? Shortname { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShortnameSpecified => Shortname?.Count > 0;

        /// <summary>
        /// (optional) Unit description<br/>
        /// <br/>
        /// This element can be used to describe the unit of measurement in more detail.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("UNIT_DESCR")]
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

        /// <summary>
        /// (optional) Code of the unit<br/>
        /// <br/>
        /// Code of the unit in addition to its name, e.g., "MTR" for "Meter", "VLT" for "VOLT".<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("UNIT_CODE")]
        public string? Code { get; set; }

        /// <summary>
        /// (optional) URI of the unit <br/>
        /// <br/>
        /// This element can be used to point to an URI that presents additional information on the unit, e.g., a document or standard.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("UNIT_URI")]
        public string? Uri { get; set; }
    }
}
