using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Contact)<br/>
    /// <br/>
    /// This element contains informations about a contact person.
    /// </summary>
    public class ContactDetails
    {
        /// <summary>
        /// (optional) Contact ID<br/>
        /// <br/>
        /// Unique ID of the contact person.<br/>
        /// <br/>
        /// Max length: 60<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTACT_ID")]
        public string? ContactId { get; set; }

        /// <summary>
        /// (required) Contact name<br/>
        /// <br/>
        /// Last name of the contact<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [MinLength(1)]
        [Required]
        [BMEXmlElement("CONTACT_NAME")]
        public List<MultiLingualString>? ContactNames { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactNamesSpecified => ContactNames?.Count > 0;

        /// <summary>
        /// (optional) First name <br/>
        /// <br/>
        /// First name of the contact person.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FIRST_NAME")]
        public List<MultiLingualString>? Firstnames { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FirstnamesSpecified => Firstnames?.Count > 0;

        /// <summary>
        /// (optional) Title<br/>
        /// <br/>
        /// Form of address, e.g., Mr., Ms.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TITLE")]
        public List<MultiLingualString>? Titles { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TitlesSpecified => Titles?.Count > 0;

        /// <summary>
        /// (optional) Academic title<br/>
        /// <br/>
        /// Academic title of the contact person, e.g., Dr.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ACADEMIC_TITLE")]
        public List<MultiLingualString>? AcademicTitles { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AcademicTitlesSpecified => AcademicTitles?.Count > 0;

        /// <summary>
        /// (optional) Role<br/>
        /// <br/>
        /// Role or position of a contact.
        /// </summary>
        [BMEXmlElement("CONTACT_ROLE")]
        public List<ContactRole>? ContactRoles { get; set; } = new List<ContactRole>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactRolesSpecified => ContactRoles?.Count > 0;

        /// <summary>
        /// (optional) Contact description<br/>
        /// <br/>
        /// Additional information on the contact person.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTACT_DESCR")]
        public List<MultiLingualString>? ContactDescriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactDescriptionsSpecified => ContactDescriptions?.Count > 0;

        /// <summary>
        /// (optional) Phone number<br/>
        /// <br/>
        /// Phone number including type.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PHONE")]
        public List<Phone>? Phones { get; set; } = new List<Phone>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PhonesSpecified => Phones?.Count > 0;

        /// <summary>
        /// (optional) Fax number<br/>
        /// <br/>
        /// Fax number including type.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FAX")]
        public List<Fax>? Faxes { get; set; } = new List<Fax>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FaxesSpecified => Faxes?.Count > 0;

        /// <summary>
        /// (optional) Internet address<br/>
        /// <br/>
        /// URL of the web site, e.g., http://www.bmecat.org
        /// </summary>
        [BMEXmlElement("URL")]
        public string? Url { get; set; }


        /// <summary>
        /// (optional) E-mail addresses<br/>
        /// <br/>
        /// List of e-mail addresses.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("EMAILS")]
        public List<Email>? Emails { get; set; } = new List<Email>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EmailsSpecified => Emails?.Count > 0;

        /// <summary>
        /// (optional) Authentification information<br/>
        /// <br/>
        /// Authentification information.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AUTHENTIFICATION")]
        public Authentification Authentification { get; set; }
    }
}
