using System.Collections.Generic;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (IPP authentification information)<br/>
    /// <br/>
    /// This element specifies if and how authentification information are used with an IPP application call.<br/>
    /// Two cases have to be distinguished: If there are authentification information included in this element these authentification information have to be transfered during the IPP application call.<br/>
    /// If the element is empty the attribute "occurance" states wether the authentification information is mandatory or optional in the IPP call but not which are the authentification information.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppAuthentificationInfo : IppParamsBase
    {
        /// <summary>
        /// (optional) Authentification information<br/>
        /// <br/>
        /// Authentification information.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AUTHENTIFICATION")]
        public List<Authentification>? Authentifications { get; set; } = new List<Authentification>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AuthentificationsSpecified => Authentifications?.Count > 0;
    }
}
