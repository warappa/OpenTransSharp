using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        private static readonly EmailAddressAttribute validationAttribute = new EmailAddressAttribute();

        /// <summary>
        /// <inheritdoc cref="Email"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Email()
        {
            EmailAddress = null!;
        }

        /// <summary>
        /// <inheritdoc cref="Email"/>
        /// </summary>
        /// <param name="emailAddress"></param>
        public Email(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress) ||
                !validationAttribute.IsValid(emailAddress))
            {
                throw new ArgumentException($"'{nameof(emailAddress)}' cannot be null or whitespace.", nameof(emailAddress));
            }

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
