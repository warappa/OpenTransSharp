using System.Xml.Serialization;

namespace OpenTransSharp
{
    public enum OrderType
    {
        /// <summary>
        /// Standard delivery<br/>
        /// <br/>
        /// A standard delivery is being requested for this order.
        /// </summary>
        [XmlEnum("standard")]
        Standard,
        /// <summary>
        /// Express delivery<br/>
        /// <br/>
        /// An express delivery is being requested for this order.
        /// </summary>
        [XmlEnum("express")]
        Express,
        /// <summary>
        /// Release<br/>
        /// <br/>
        /// The request for quotation is a release from a skeleton agreement. The skeleton agreement is specified under AGREEMENT.<br/>
        /// <br/>
        /// Caution:<br/>
        /// If prices have been laid down for the articles listed under RFQ_ITEM the use of a quotation is not meaningful.
        /// </summary>
        [XmlEnum("release")]
        Release
    }
}
