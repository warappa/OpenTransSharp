using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (E-mail addresses)<br/>
    /// <br/>
    /// This element contains a list of e-mail addresses.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Email
    {
        /// <summary>
        /// (required) E-mail address<br/>
        /// <br/>
        /// E-mail address.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("EMAIL")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// (optional) Public key<br/>
        /// <br/>
        /// Public key, e.g. PGP.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PUBLIC_KEY")]
        public List<PublicKey>? PublicKeys { get; set; } = new List<PublicKey>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PublicKeysSpecified => PublicKeys?.Count > 0;
    }
}
