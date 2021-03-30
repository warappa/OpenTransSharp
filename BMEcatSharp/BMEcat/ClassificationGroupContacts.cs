using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public List<string> ContactIdref { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactIdrefSpecified => ContactIdref?.Count > 0;
    }
}
