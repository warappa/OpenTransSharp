using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Address)<br/>
    /// <br/>
    /// This element is used to transfer address information of a business partner.<br/>
    /// This element will not be used in the future.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [Obsolete("This element will not be used in the future.")]
    public class BMEBuyerAddress
    {
        /// <summary>
        /// (required) Address type<br/>
        /// <br/>
        /// Contains the address type.
        /// </summary>
        [XmlAttribute("type")]
        public BMEBuyerAddressType Type { get; set; }

        /// <summary>
        /// (optional) Address line<br/>
        /// <br/>
        /// First address line, in most cases the name of the organisation<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("NAME")]
        public MultiLingualString? Name { get; set; }

        /// <summary>
        /// (optional) Address line 2<br/>
        /// <br/>
        /// Additional space for address information<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("NAME2")]
        public MultiLingualString? Name2 { get; set; }

        /// <summary>
        /// (optional) Address line 3<br/>
        /// <br/>
        /// Additional space for address information<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("NAME3")]
        public MultiLingualString? Name3 { get; set; }

        /// <summary>
        /// (optional) Department<br/>
        /// <br/>
        /// Department of the organisation<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("DEPARTMENT")]
        public MultiLingualString? Department { get; set; }

        /// <summary>
        /// (optional - choice ContactDetails/(deprecated)Contact) Contact<br/>
        /// <br/>
        /// Information on a contact person.
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTACT_DETAILS")]
        public List<ContactDetails>? ContactDetails { get; set; } = new List<ContactDetails>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactDetailsSpecified => ContactDetails?.Count > 0;

        /// <summary>
        /// (optional - deprecated - choice ContactDetails/(deprecated)Contact) Contact name<br/>
        /// <br/>
        /// This element contains the name of the contact person.<br/>
        /// The element CONTACT will be replaced by the element CONTACT_DETAILS in future versions and will be omitted then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("The element CONTACT will be replaced by the element CONTACT_DETAILS in future versions and will be omitted then.")]
        [BMEXmlElement("CONTACT")]
        public MultiLingualString? Contact { get; set; }

        /// <summary>
        /// (optional) Street<br/>
        /// <br/>
        /// Street name and house number<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STREET")]
        public MultiLingualString? Street { get; set; }

        /// <summary>
        /// (optional) Zip code<br/>
        /// <br/>
        /// ZIP code of address<br/>
        /// <br/>
        /// Max length: 20<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ZIP")]
        public MultiLingualString? Zip { get; set; }

        /// <summary>
        /// (optional) P.O. Box<br/>
        /// <br/>
        /// P.O. box number<br/>
        /// <br/>
        /// Max length: 20<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("BOXNO")]
        public MultiLingualString? BoxNo { get; set; }

        /// <summary>
        /// (optional) Zip code of P.O. Box<br/>
        /// <br/>
        /// ZIP code of P.O. box<br/>
        /// <br/>
        /// Max length: 20<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ZIPBOX")]
        public MultiLingualString? ZipBoxNo { get; set; }

        /// <summary>
        /// (optional) Town or city<br/>
        /// <br/>
        /// Town or city of the company<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CITY")]
        public MultiLingualString? City { get; set; }

        /// <summary>
        /// (optional) Federal state<br/>
        /// <br/>
        /// Federal state, e.g., Michigan<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STATE")]
        public MultiLingualString? State { get; set; }

        /// <summary>
        /// (optional) Country<br/>
        /// <br/>
        /// Country, e.g., France<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("COUNTRY")]
        public MultiLingualString? Country { get; set; }

        /// <summary>
        /// (optional) Country code<br/>
        /// <br/>
        /// Country code, e.g. FR for France<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("COUNTRY_CODED")]
        public CountryCode? CountryCoded { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CountryCodedSpecified => CountryCoded.HasValue;

        /// <summary>
        /// (optional) VAT-ID<br/>
        /// <br/>
        /// VAT identification number of the business partner<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("VAT_ID")]
        public string? VatId { get; set; }

        /// <summary>
        /// (optional) Phone number<br/>
        /// <br/>
        /// Phone number including type<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PHONE")]
        public Phone? Phone { get; set; }

        /// <summary>
        /// (optional) Fax number<br/>
        /// <br/>
        /// Fax number including type<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FAX")]
        public Fax? Fax { get; set; }

        /// <summary>
        /// (required) E-mail address<br/>
        /// <br/>
        /// e-mail address<br/>
        /// The e-mail address refers to the organization only.<br/>
        /// E-mail address for individuals within this organization can be stored in the container element CONTACT_DETAILS and its sub-element EMAIL.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("EMAIL")]
        public string? Email { get; set; }

        /// <summary>
        /// (optional) Public key<br/>
        /// <br/>
        /// Public key, e.g. PGP<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PUBLIC_KEY")]
        public List<PublicKey>? PublicKeys { get; set; } = new List<PublicKey>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PublicKeysSpecified => PublicKeys?.Count > 0;

        /// <summary>
        /// (optional) Internet address<br/>
        /// <br/>
        /// URL of the web site, e.g., http://www.bmecat.org<br/>
        /// <br/>
        /// Max length: 255<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("URL")]
        public string? Url { get; set; }

        /// <summary>
        /// (optional) Remarks<br/>
        /// <br/>
        /// Remarks on the organization<br/>
        /// <br/>
        /// Max length: 250<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ADDRESS_REMARKS")]
        public MultiLingualString? Remarks { get; set; }
    }
}
