﻿using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Address)<br/>
    /// <br/>
    /// This element is used to transfer address information of a business partner.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Address
    {
        /// <summary>
        /// <inheritdoc cref="Address"/>
        /// </summary>
        public Address() { }

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
        public List<MultiLingualString>? Name { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? Name2 { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? Name3 { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? Department { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DepartmentSpecified => Department?.Count > 0;

        /// <summary>
        /// (optional) Contact<br/>
        /// <br/>
        /// Information on a contact person.
        /// </summary>
        [XmlElement("CONTACT_DETAILS")]
        public List<BMEcatContactDetails>? ContactDetails { get; set; } = new List<BMEcatContactDetails>();
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
        public List<MultiLingualString>? Street { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? Zip { get; set; } = new List<MultiLingualString>();

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
        public List<MultiLingualString>? BoxNo { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? ZipBox { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? City { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? State { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? Country { get; set; } = new List<MultiLingualString>();
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
        public List<MultiLingualString>? Remarks { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemarksSpecified => Remarks?.Count > 0;
    }
}
