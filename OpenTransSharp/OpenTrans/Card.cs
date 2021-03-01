using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Card payment)<br/>
    /// <br/>
    /// The CARD element summarizes information about payment using credit or purchasing cards.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class Card
    {
        /// <summary>
        /// (required) Card type<br/>
        /// <br/>
        /// The type of the card. See <see cref="CardTypeValues"/>.
        /// </summary>
        [OpenTransXmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (required) Card number<br/>
        /// <br/>
        /// Number of the credit or purchasing card.
        /// </summary>
        [OpenTransXmlElement("CARD_NUM")]
        public string Number { get; set; }

        /// <summary>
        /// (optional) PIN<br/>
        /// <br/>
        /// Caution:<br/>
        /// Not recommended for use for insecure transmission!
        /// </summary>
        [OpenTransXmlElement("CARD_AUTH_CODE")]
        public string? PIN { get; set; }

        /// <summary>
        /// (optional) Reference number<br/>
        /// <br/>
        /// Customer reference number.
        /// </summary>
        [OpenTransXmlElement("CARD_REF_NUM")]
        public string? ReferenceNumber { get; set; }

        /// <summary>
        /// (required) Expiration date<br/>
        /// <br/>
        /// Expiration date Example: "2001-03" for 03/2001.
        /// </summary>
        [OpenTransXmlElement("CARD_EXPIRATION_DATE")]
        public DateTime? ExpirationDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ExpirationDateSpecified => ExpirationDate.HasValue;

        /// <summary>
        /// (required) Card holder<br/>
        /// <br/>
        /// Name of the card holder the credit card has been issued to.
        /// </summary>
        [OpenTransXmlElement("CARD_HOLDER_NAME")]
        public string HolderName { get; set; }
    }
}
