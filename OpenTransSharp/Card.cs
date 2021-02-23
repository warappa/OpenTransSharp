using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Card payment)<br/>
    /// <br/>
    /// The CARD element summarizes information about payment using credit or purchasing cards.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// (required) Card type<br/>
        /// <br/>
        /// The type of the card. See <see cref="CardTypeValues"/>.
        /// </summary>
        [Required]
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (required) Card number<br/>
        /// <br/>
        /// Number of the credit or purchasing card.
        /// </summary>
        [Required]
        [XmlElement("CARD_NUM")]
        public string CardNum { get; set; }

        /// <summary>
        /// (optional) PIN<br/>
        /// <br/>
        /// Caution:<br/>
        /// Not recommended for use for insecure transmission!
        /// </summary>
        [XmlElement("CARD_AUTH_CODE")]
        public string? CardAuthCode { get; set; }

        /// <summary>
        /// (optional) Reference number<br/>
        /// <br/>
        /// Customer reference number.
        /// </summary>
        [XmlElement("CARD_REF_NUM")]
        public string? CardRefNum { get; set; }

        /// <summary>
        /// (required) Expiration date<br/>
        /// <br/>
        /// Expiration date Example: "2001-03" for 03/2001.
        /// </summary>
        [Required]
        [XmlElement("CARD_EXPIRATION_DATE")]
        public DateTime? CardExpirationDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CardExpirationDateSpecified => CardExpirationDate.HasValue;

        /// <summary>
        /// (required) Card holder<br/>
        /// <br/>
        /// Name of the card holder the credit card has been issued to.
        /// </summary>
        [Required]
        [XmlElement("CARD_HOLDER_NAME")]
        public string CardHolderName { get; set; }
    }
}
