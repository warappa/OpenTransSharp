using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
{
    /// <summary>
    /// (Classification group contacts)<br/>
    /// <br/>
    /// This element contains contact information for the respective group.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ClassificationGroupContacts
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClassificationGroupContacts() 
            : this(null!, null!)
        { }

        public ClassificationGroupContacts(PartyIdref partyIdref, IEnumerable<string> contactIdrefs)
        {
            PartyIdRef = partyIdref;
            ContactIdrefs = contactIdrefs?.ToList() ?? new List<string>();
        }
        /// <summary>
        /// (required) Reference to a business partner<br/>
        /// <br/>
        /// Reference to a business partner. It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARTY_IDREF")]
        public PartyIdref PartyIdRef { get; set; }

        /// <summary>
        /// (required) Reference to a business partner<br/>
        /// <br/>
        /// Reference to a business partner. It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTACT_IDREF")]
        public List<string> ContactIdrefs { get; set; } = new List<string>();
    }
}
