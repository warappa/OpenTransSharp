﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Summary)<br/>
    /// <br/>
    /// The summary contains information on the number of item lines in the order change.<br/>
    /// This figure is used for control purposes to make sure that all items have been transferred.
    /// </summary>
    public class OrderChangeSummary
    {
        /// <summary>
        /// (required) Number of item lines<br/>
        /// <br/>
        /// Contains the total number of item lines in the business document.<br/>
        /// The information is redundant and is for the purposes of statistical evaluation (e.g. by an intermediary) if appropriate.
        /// </summary>
        [Required]
        [XmlElement("TOTAL_ITEM_NUM")]
        public int TotalItemCount { get; set; }

        /// <summary>
        /// (optional) Total amount<br/>
        /// <br/>
        /// Total amount covering all items in this business document.<br/>
        /// <br/>
        /// Caution:<br/>
        /// Changed definition:<br/>
        /// Gross price including surcharges, deductions and all taxes.<br/>
        /// Where no price per item can be given as the item level (e.g.bills of materials where explosion is not possible), the total price can be entered here.
        /// </summary>
        [Required]
        [XmlElement("TOTAL_AMOUNT")]
        public decimal? TotalAmount { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TotalAmountSpecified => TotalAmount.HasValue;
    }
}