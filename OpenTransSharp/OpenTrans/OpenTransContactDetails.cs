using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Contact)<br/>
    /// <br/>
    /// This element contains informations about a contact person.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class OpenTransContactDetails
    {
        /// <summary>
        /// (required) Contact ID<br/>
        /// <br/>
        /// Unique ID of the contact person.<br/>
        /// <br/>
        /// Max length: 60<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTACT_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (required) Contact name<br/>
        /// <br/>
        /// Last name of the contact<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTACT_NAME")]
        public List<MultiLingualString>? Surname { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SurnameSpecified => Surname?.Count > 0;

        /// <summary>
        /// (optional) First name <br/>
        /// <br/>
        /// First name of the contact person.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FIRST_NAME")]
        public List<MultiLingualString>? FirstName { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FirstNameSpecified => FirstName?.Count > 0;

        /// <summary>
        /// (optional) Title<br/>
        /// <br/>
        /// Form of address, e.g., Mr., Ms.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TITLE")]
        public List<MultiLingualString>? Title { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TitleSpecified => Title?.Count > 0;

        /// <summary>
        /// (optional) Academic title<br/>
        /// <br/>
        /// Academic title of the contact person, e.g., Dr.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ACADEMIC_TITLE")]
        public List<MultiLingualString>? AcademicTitle { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AcademicTitleSpecified => AcademicTitle?.Count > 0;

        /// <summary>
        /// (optional) Role<br/>
        /// <br/>
        /// Role or position of a contact.<br/>
        /// <br/>
        /// XML-namespace: OpenTrans
        /// </summary>
        [OpenTransXmlElement("CONTACT_ROLE")]
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
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

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
        /// URL of the web site, e.g., http://www.bmecat.org.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
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
        public Email? Email { get; set; }

        /// <summary>
        /// (optional) Authentification information<br/>
        /// <br/>
        /// Authentification information.<br/>
        /// <br/>
        /// XML-namespace: BMECAT<br/>
        /// <br/>
        /// Compatibility warning: in OpenTrans, not in BMEcat!
        /// </summary>
        [BMEXmlElement("AUTHENTIFICATION")]
        public Authentification? Authentification { get; set; }
    }
}
