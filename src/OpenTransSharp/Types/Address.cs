﻿using BMEcatSharp;
using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Address)<br/>
    /// <br/>
    /// This element is used to transfer address information of a business partner.
    /// </summary>
    public class Address
    {
        private bool emailsInitialized;
        private bool emailComponentsInitialized;

        /// <summary>
        /// <inheritdoc cref="Address"/>
        /// </summary>
        public Address()
        {
            emailsInitialized = false;
            emailComponentsInitialized = false;
        }

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
        public List<global::BMEcatSharp.MultiLingualString>? Name { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NameSpecified => Name?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? Name2 { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Name2Specified => Name2?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? Name3 { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Name3Specified => Name3?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? Department { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DepartmentSpecified => Department?.Count > 0;

        /// <summary>
        /// (optional) Contact<br/>
        /// <br/>
        /// Information on a contact person.
        /// </summary>
        [XmlElement("CONTACT_DETAILS")]
        public List<OpenTransContactDetails>? ContactDetails { get; set; } = new List<OpenTransContactDetails>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactDetailsSpecified => ContactDetails?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? Street { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StreetSpecified => Street?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? Zip { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ZipSpecified => Zip?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? BoxNo { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BoxNoSpecified => BoxNo?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? ZipBox { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ZipBoxSpecified => ZipBox?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? City { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CitySpecified => City?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? State { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StateSpecified => State?.Count > 0;

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
        public List<global::BMEcatSharp.MultiLingualString>? Country { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CountrySpecified => Country?.Count > 0;

        /// <summary>
        /// (optional) Country code<br/>
        /// <br/>
        /// Country code, e.g. FR for France<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("COUNTRY_CODED")]
        public global::BMEcatSharp.CountryCode? CountryCoded { get; set; }
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
        /// (optional) Tax number<br/>
        /// <br/>
        /// Tax number of a business partner.
        /// </summary>
        [XmlElement("TAX_NUMBER")]
        public string? TaxNumber { get; set; }

        /// <summary>
        /// (optional) Phone number<br/>
        /// <br/>
        /// Phone number including type<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PHONE")]
        public List<global::BMEcatSharp.Phone>? Phones { get; set; } = new List<global::BMEcatSharp.Phone>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PhonesSpecified => Phones?.Count > 0;

        /// <summary>
        /// (optional) Fax number<br/>
        /// <br/>
        /// Fax number including type<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FAX")]
        public List<global::BMEcatSharp.Fax>? Faxes { get; set; } = new List<global::BMEcatSharp.Fax>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FaxesSpecified => Faxes?.Count > 0;

        private List<Email>? emails;
        /// <summary>
        /// (optional - required if PublicKeys is specified) E-mail address<br/>
        /// <br/>
        /// e-mail address<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlIgnore]
        public List<Email>? Emails
        {
            get
            {
                if (emails is null)
                {
                    EmailComponentsToEmails();
                }
                return emails;
            }
            set
            {
                emails = value;
                EmailsToEmailComponents();
            }
        }

        private List<EmailComponent>? emailComponents;

        [BMEXmlElement(Type = typeof(EmailAddress), ElementName = "EMAIL")]
        [BMEXmlElement(Type = typeof(PublicKey), ElementName = "PUBLIC_KEY")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<EmailComponent>? EmailComponents
        {
            get
            {
                if (emailComponents is null)
                {
                    EmailsToEmailComponents();
                }

                return emailComponents;
            }
            set
            {
                emailComponents = value!;
            }
        }

        private void EmailComponentsToEmails()
        {
            emails ??= new List<Email>();
            emails.Clear();
            if (emailComponents?.Count > 0)
            {
                emails ??= new List<Email>();

                Email? email = null;
                for (var i = 0; i < emailComponents.Count; i++)
                {
                    var component = emailComponents[i];
                    if (component is EmailAddress emailAddress)
                    {
                        if (email is not null)
                        {
                            emails.Add(email);
                        }
                        email = new Email();
                        email.EmailAddress = emailAddress.Value;
                    }
                    else if (component is PublicKey publicKey)
                    {
                        email?.PublicKeys!.Add(publicKey);
                    }
                }

                if (email is not null)
                {
                    emails.Add(email);
                }
            }
        }

        public bool EmailComponentsSpecified
        {
            get
            {
                // HACK: called just before the payload gets serialized
                if (Emails is not null)
                {
                    EmailsToEmailComponents();
                }

                if (EmailComponents?.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

        private void EmailsToEmailComponents()
        {
            if (emails is null)
            {
                emailComponents = null;
                return;
            }

            emailComponents ??= new List<EmailComponent>();
            emailComponents.Clear();
            foreach (var email in emails)
            {
                emailComponents.Add(new EmailAddress { Value = email.EmailAddress });
                emailComponents.AddRange(email.PublicKeys);
            }
        }

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
        public List<global::BMEcatSharp.MultiLingualString>? Remarks { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemarksSpecified => Remarks?.Count > 0;
    }
}

//public class EmailPublicKey : IXmlSerializable
//{
//    private static XmlSerializer _publicKeySerializer = new XmlSerializer(typeof(PublicKey), "http://www.bmecat.org/bmecat/2005");
//    /// <summary>
//    /// (optional - required if PublicKeys is specified) E-mail address<br/>
//    /// <br/>
//    /// e-mail address<br/>
//    /// <br/>
//    /// XML-namespace: BMECAT
//    /// </summary>
//    public string? Email { get; set; }

//    /// <summary>
//    /// (optional) Public key<br/>
//    /// <br/>
//    /// Public key, e.g. PGP<br/>
//    /// <br/>
//    /// XML-namespace: BMECAT
//    /// </summary>
//    public List<global::BMEcatSharp.PublicKey>? PublicKeys { get; set; } = new List<global::BMEcatSharp.PublicKey>();
//    [EditorBrowsable(EditorBrowsableState.Never)]
//    public bool PublicKeysSpecified => PublicKeys?.Count > 0;

//    public XmlSchema GetSchema()
//    {
//        return null!;
//    }

//    public void ReadXml(XmlReader reader)
//    {
//        reader.MoveToContent();
//        Email = (string?)reader.ReadElementContentAs(typeof(string), null);

//        if (reader.IsStartElement() &&
//            reader.LocalName == "PUBLIC_KEY")
//        {
//            var can = _publicKeySerializer.CanDeserialize(reader);
//            while (reader.NodeType != XmlNodeType.EndElement &&
//                reader.LocalName == "PUBLIC_KEY")
//            {
//                var publicKey = (PublicKey)_publicKeySerializer.Deserialize(reader);
//                PublicKeys!.Add(publicKey);
//            }
//        }
//    }

//    public void WriteXml(XmlWriter writer)
//    {
//        writer.WriteElementString("EMAIL", Email);
//        if (PublicKeys is not null)
//        {
//            foreach (var publicKey in PublicKeys)
//            {
//                _publicKeySerializer.Serialize(writer, publicKey);
//            }
//        }
//    }
//}
