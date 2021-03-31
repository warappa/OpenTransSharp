using System;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="PriceFlag"/>.
    /// </summary>
    public static class PriceFlagTypes
    {   
        /// <summary>
        /// Including duty<br/>
        /// <br/>
        /// Price includes duty.
        /// </summary>
        public const string IncludingDuty = "incl_duty";
        /// <summary>
        /// Including freight<br/>
        /// <br/>
        /// Price includes freight costs.
        /// </summary>
        public const string IncludingFreight = "incl_freight";
        /// <summary>
        /// Including insureance<br/>
        /// <br/>
        /// Price includes insurance.
        /// </summary>
        public const string IncludingInsurance = "incl_insurance";
        /// <summary>
        /// Including packaging<br/>
        /// <br/>
        /// Price includes packing costs.
        /// </summary>
        public const string IncludingPacking = "incl_packing";

        [Obsolete("This value has been replaced by the new value PRICE_FLAG -->type =incl_insurance, it will be become obsolete.")]
        public const string IncludingAssurance = "incl_assurance";
    }
}
