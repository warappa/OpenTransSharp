﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Buyer information - deprecated)<br/>
    /// <br/>
    /// This element contains information on the buyer.<br/>
    /// This element will not be used in the future.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [Obsolete("This element will not be used in the future.")]
    public class Buyer
    {
        /// <summary>
        /// (optional - deprecated) ID of the buying company<br/>
        /// <br/>
        /// Unique number of the buying company; the optional attribute "type" determines the type of ID.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("BUYER_ID")]
        public BuyerId? BuyerId { get; set; }

        /// <summary>
        /// (required - deprecated) ID of the buying company<br/>
        /// <br/>
        /// Unique number of the buying company; the optional attribute "type" determines the type of ID.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [Required]
        [BMEXmlElement("BUYER_NAME")]
        public string? BuyerName { get; set; }

        /// <summary>
        /// (optional - deprecated) Address<br/>
        /// <br/>
        /// Address information of a business partner.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("ADDRESS")]
        public BMEBuyerAddress? Address { get; set; }
    }
}