using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Contact)<br/>
    /// <br/>
    /// This element contains informations about a contact person.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ContactDetails
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
        [Required]
        [BMEXmlElement("CONTACT_ID")]
        public string ContactId { get; set; }

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
        public MultiLingualString? ContactName { get; set; }

        /// <summary>
        /// (optional) First name <br/>
        /// <br/>
        /// First name of the contact person.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FIRST_NAME")]
        public MultiLingualString? Firstname { get; set; }

        /// <summary>
        /// (optional) Title<br/>
        /// <br/>
        /// Form of address, e.g., Mr., Ms.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TITLE")]
        public MultiLingualString? Title { get; set; }

        /// <summary>
        /// (optional) Academic title<br/>
        /// <br/>
        /// Academic title of the contact person, e.g., Dr.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ACADEMIC_TITLE")]
        public MultiLingualString? AcademicTitle { get; set; }

        /// <summary>
        /// (optional) Role<br/>
        /// <br/>
        /// Role or position of a contact.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
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
        public MultiLingualString? ContactDescription { get; set; }

        /// <summary>
        /// (optional) Phone number<br/>
        /// <br/>
        /// Phone number including type.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PHONE")]
        public Phone? Phone { get; set; }

        /// <summary>
        /// (optional) Fax number<br/>
        /// <br/>
        /// Fax number including type.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FAX")]
        public Fax? Fax { get; set; }

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
