using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Logistics information)<br/>
    /// <br/>
    /// The element contains logistical details on item line level.
    /// </summary>
    public class LogisticDetails
    {
        /// <summary>
        /// (optional) Information on the customs tariff number.
        /// </summary>
        [BMEXmlElement("CUSTOMS_TARIFF_NUMBER")]
        public List<CustomsTariffNumber>? CustomsTariffNumbers { get; set; } = new List<CustomsTariffNumber>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CustomsTariffNumbersSpecified => CustomsTariffNumbers?.Count > 0;

        /// <summary>
        /// (optional) Statistics factor.<br/>
        /// <br/>
        /// Factor that transform the order unit into the unit of measurement that is necessary for the foreign trade statistics.<br/>
        /// In this exemplarily example 3 m long pipes could be be ordered (order unit = each).<br/>
        /// The foreign trade statistics requires meter; therefore, the factor is 3.<br/>
        /// On base of this factor and the order unit also calculation factors for different sales units can be derived.
        /// </summary>
        [BMEXmlElement("STATISTICS_FACTOR")]
        public decimal? StatisticsFactor { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StatisticsFactorSpecified => StatisticsFactor.HasValue;

        /// <summary>
        /// (optional) Country of origin.<br/>
        /// <br/>
        /// Contains the country of origin of the product. By using a subdivision code it is possible to reference a region.
        /// </summary>
        [BMEXmlElement("COUNTRY_OF_ORIGIN")]
        public List<CountryCode>? CountryOfOrigins { get; set; } = new List<CountryCode>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CountryOfOriginsSpecified => CountryOfOrigins?.Count > 0;

        /// <summary>
        /// (optional) Product dimensions.<br/>
        /// <br/>
        /// Information on the product dimension from the view of business logistics.
        /// </summary>
        [BMEXmlElement("PRODUCT_DIMENSIONS")]
        public ProductDimensions? ProductDimensions { get; set; }

        /// <summary>
        /// (optional) Special treatment class<br/>
        /// <br/>
        /// Additional product classification used for hazardous goods or substances, primary pharmaceutical products, radioactive measuring equipment, etc.<br/>
        /// The "type" attribute specifies the dangerous goods classification scheme.
        /// </summary>
        [BMEXmlElement("SPECIAL_TREATMENT_CLASS")]
        public SpecialTreatmentClass? SpecialTreatmentClass { get; set; }

        /// <summary>
        /// (optional) Transport<br/>
        /// <br/>
        /// Information about the terms of transport.
        /// </summary>
        [BMEXmlElement("TRANSPORT")]
        public Transport? Transport { get; set; }

        /// <summary>
        /// (optional) Packaging information<br/>
        /// <br/>
        /// Information according to the packaging.
        /// </summary>
        [XmlArray("PACKAGE_INFO")]
        [XmlArrayItem("PACKAGE")]
        public List<Package> PackageInfos { get; set; } = new List<Package>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PackageInfosSpecified => PackageInfos?.Count > 0;

        /// <summary>
        /// (optional) Means of transport<br/>
        /// <br/>
        /// Means of transport with which the goods to be delivered are´transported.
        /// </summary>
        [BMEXmlElement("MEANS_OF_TRANSPORT")]
        public List<MeansOfTransport> MeansOfTransports { get; set; } = new List<MeansOfTransport>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MeansOfTransportsSpecified => MeansOfTransports?.Count > 0;
    }
}
