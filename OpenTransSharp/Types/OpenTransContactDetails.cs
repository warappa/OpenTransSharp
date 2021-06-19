using BMEcatSharp.Xml;
using OpenTransSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
        /// <inheritdoc cref="OpenTransContactDetails"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OpenTransContactDetails()
        {
            Id = null!;
        }

        /// <summary>
        /// <inheritdoc cref="OpenTransContactDetails"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surname"></param>
        public OpenTransContactDetails(string? id, IEnumerable<BMEcatSharp.MultiLingualString> surname)
        {
            if (surname is null)
            {
                throw new System.ArgumentNullException(nameof(surname));
            }

            Id = id;
            Surname = surname.ToList();
        }

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
        public string? Id { get; set; }

        /// <summary>
        /// (required) Contact name<br/>
        /// <br/>
        /// Last name of the contact<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTACT_NAME")]
        public List<global::BMEcatSharp.MultiLingualString>? Surname { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
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
        public List<global::BMEcatSharp.MultiLingualString>? FirstName { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
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
        public List<global::BMEcatSharp.MultiLingualString>? Title { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
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
        public List<global::BMEcatSharp.MultiLingualString>? AcademicTitle { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
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
        public List<global::BMEcatSharp.ContactRole>? ContactRoles { get; set; } = new List<global::BMEcatSharp.ContactRole>();
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
        public List<global::BMEcatSharp.MultiLingualString>? Description { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
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
        public List<global::BMEcatSharp.Phone>? Phones { get; set; } = new List<global::BMEcatSharp.Phone>();
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
        public List<global::BMEcatSharp.Fax>? Faxes { get; set; } = new List<global::BMEcatSharp.Fax>();
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
        public global::BMEcatSharp.Email? Email { get; set; }

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
        public global::BMEcatSharp.Authentification? Authentification { get; set; }
    }
}
