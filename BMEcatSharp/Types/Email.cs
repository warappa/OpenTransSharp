using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Email()
            : this(null!)
        { }

        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

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
