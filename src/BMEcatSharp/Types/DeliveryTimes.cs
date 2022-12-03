using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
{
    /// <summary>
    /// (Delivery time)<br/>
    /// <br/>
    /// This element describes, in which time windows ordered product can be delivered.<br/>
    /// It should not be confused with the lead time (LEADTIME).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class DeliveryTimes
    {
        /// <summary>
        /// <inheritdoc cref="DeliveryTimes"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeliveryTimes() { }

        /// <summary>
        /// <inheritdoc cref="DeliveryTimes"/>
        /// </summary>
        /// <param name="timeSpans"></param>
        public DeliveryTimes(IEnumerable<BMETimeSpan> timeSpans)
        {
            if (timeSpans is null)
            {
                throw new ArgumentNullException(nameof(timeSpans));
            }

            TimeSpans = timeSpans.ToList();
        }

        /// <summary>
        /// (optional - choice Territories/AreaRefs) Territory<br/>
        /// <br/>
        /// Territory (i.e. country, state, region) coded according to ISO 3166.<br/>
        /// <br/>
        /// The element specifies here to which territories the delivery times are related.<br/>
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
        /// The element specifies here to which areas the delivery times are related.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("AREA_REFS")]
        [BMEXmlArrayItem("AREA_IDREF")]
        public List<string>? AreaRefs { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AreaRefsSpecified => AreaRefs?.Count > 0;

        /// <summary>
        /// (required) Time span<br/>
        /// <br/>
        /// List of references to areas.<br/>
        /// <br/>
        /// Definition of a time span or time frame.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TIME_SPAN")]
        public List<BMETimeSpan>? TimeSpans { get; set; } = new List<BMETimeSpan>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TimeSpansSpecified => TimeSpans?.Count > 0;

        /// <summary>
        /// (optional) Leadtime<br/>
        /// <br/>
        /// Leadtime in working days defined as the interval between the receipt of the order and the earliest arrival at the customer.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("LEADTIME")]
        public decimal? Leadtime { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LeadtimeSpecified => Leadtime.HasValue;
    }
}
