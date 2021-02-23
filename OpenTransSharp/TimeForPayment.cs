﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Time for payment)<br/>
    /// <br/>
    /// The element contains information to time-related payment details like period for payment, early payment discounts.For specifying the period of payment the element PAYMENT_DATE (to set a date) or the element DAYS (to set a time-frame) can be used.<br/>
    /// In the case of no further specification of detials the specified period for payment is the "net time for payment".<br/>
    /// The sub-element DISCOUNT_FACTOR specifies the factor used for a early payment discount.<br/>
    /// If the element ALLOW_OR_CHARGES_FIX is used any surrcharges or discounts can be used (e.g. early payment discounts or late fees for exceeding the deadline for payment).
    /// </summary>
    public class TimeForPayment
    {
        /// <summary>
        /// (required) Time for payment<br/>
        /// <br/>
        /// Time where the payment is supposed to be done.
        /// </summary>
        [Required]
        [XmlElement("PAYMENT_DATE")]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// (required) Days<br/>
        /// <br/>
        /// Time designation by days.
        /// </summary>
        [Required]
        [XmlElement("DAYS")]
        public int Days { get; set; }

        /// <summary>
        /// (optional) Cash discount factor<br/>
        /// <br/>
        /// Factor to calculate the cash discount, e.g. 0.3 means 3% cash discount.
        /// </summary>
        [XmlElement("DISCOUNT_FACTOR")]
        public decimal? DiscountFactor { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DiscountFactorSpecified => DiscountFactor.HasValue;

        /// <summary>
        /// (optional) Fixed allowance or surcharges<br/>
        /// <br/>
        /// A list of fixed allowances or surcharges which are to be applied on the price.
        /// </summary>
        [XmlElement("ALLOW_OR_CHARGES_FIX")]
        public AllowOrChargesFix AllowOrChargesFix { get; set; }
    }
}
