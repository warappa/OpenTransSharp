using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Logistics information)<br/>
    /// <br/>
    /// This element contains logistic information on the product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ProductLogisticDetails
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
        public ProductDimensions? Dimensions { get; set; }

        /// <summary>
        /// (optional) Delivery time.<br/>
        /// <br/>
        /// Information on the delivery time<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("DELIVERY_TIMES")]
        public List<DeliveryTimes>? DeliveryTimes { get; set; } = new List<DeliveryTimes>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeliveryTimesSpecified => DeliveryTimes?.Count > 0;

        /// <summary>
        /// (optional) Transport<br/>
        /// <br/>
        /// Information about the terms of transport.
        /// </summary>
        [BMEXmlElement("TRANSPORT")]
        public Transport? Transport { get; set; }

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
