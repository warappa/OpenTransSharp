using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Logistics information)<br/>
    /// <br/>
    /// The element contains logistical details in document level(HEADER).
    /// </summary>
    public class LogisticDetailsInformation
    {
        /// <summary>
        /// (optional) Country of origin<br/>
        /// <br/>
        /// Contains the country of origin of the product.<br/>
        /// By using a subdivision code it is possible to reference a region.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("COUNTRY_OF_ORIGIN")]
        public List<CountryCode>? CountriesOfOrigins { get; set; } = new List<CountryCode>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CountriesOfOriginsSpecified => CountriesOfOrigins?.Count > 0;

        /// <summary>
        /// (optional) Transport<br/>
        /// <br/>
        /// Information about the terms of transport.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TRANSPORT")]
        public List<Transport>? Transports { get; set; } = new List<Transport>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TransportsSpecified => Transports?.Count > 0;

        /// <summary>
        /// (optional) Packaging information <br/>
        /// <br/>
        /// Information according to the packaging .
        /// </summary>
        [XmlElement("PACKAGE_INFO")]
        public PackageInformation? PackageInformation { get; set; }

        /// <summary>
        /// (optional) Means of transport <br/>
        /// <br/>
        /// Means of transport with which the goods to be delivered are transported.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MEANS_OF_TRANSPORT")]
        public List<MeansOfTransport>? MeansOfTransports { get; set; } = new List<MeansOfTransport>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MeansOfTransportsSpecified => MeansOfTransports?.Count > 0;
    }
}
