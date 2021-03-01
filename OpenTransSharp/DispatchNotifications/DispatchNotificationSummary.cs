using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Summary)<br/>
    /// <br/>
    /// The summary contains information on the number of item lines in the dispatch notification.<br/>
    /// This figure is used for control purposes to make sure that all items have been transferred.
    /// </summary>
    public class DispatchNotificationSummary
    {
        /// <summary>
        /// (required) Number of item lines<br/>
        /// <br/>
        /// Contains the total number of item lines in the business document.<br/>
        /// The information is redundant and is for the purposes of statistical evaluation (e.g. by an intermediary) if appropriate.
        /// </summary>
        [XmlElement("TOTAL_ITEM_NUM")]
        public int TotalItemCount { get; set; }
    }
}
