﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Rewards)<br/>
    /// <br/>
    /// This element provides the possibilty to publish the rewards points which appeared with transactions.<br/>
    /// The element can be used directly for transactions in IL_INVOICE_LIST_ITEM and as summary in the element INVOICELIST_ITEM.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class Rewards
    {
        /// <summary>
        /// (required) Rewards points<br/>
        /// <br/>
        /// The rewards points earned with (some of) the transactions of the document.
        /// </summary>
        [OpenTransXmlElement("REWARDS_POINTS")]
        public decimal Points { get; set; }

        /// <summary>
        /// (optional) Rewards summary<br/>
        /// <br/>
        /// This is the record of the rewards points you have earned/redeemed till date.
        /// </summary>
        [OpenTransXmlElement("REWARDS_SUMMARY")]
        public decimal? Summary { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SummarySpecified => Summary.HasValue;

        /// <summary>
        /// (required) Name of the rewards system<br/>
        /// <br/>
        /// Name of the rewards system, e.g. frequent flyer program.
        /// </summary>
        [OpenTransXmlElement("REWARDS_SYSTEM")]
        public List<global::BMEcatSharp.MultiLingualString>? System { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SystemSpecified => System?.Count > 0;

        /// <summary>
        /// (required) Rewards description <br/>
        /// <br/>
        /// Description of the rewards system.
        /// </summary>
        [OpenTransXmlElement("REWARDS_DESCR")]
        public List<global::BMEcatSharp.MultiLingualString>? Descriptions { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionsSpecified => Descriptions?.Count > 0;
    }
}