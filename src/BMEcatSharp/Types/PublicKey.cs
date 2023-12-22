using BMEcatSharp.Xml;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Public key)<br/>
    /// <br/>
    /// Indicates the public key, e.g.PGP, of the person addressed here.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlRoot("PUBLIC_KEY")]
    public class PublicKey : EmailComponent
    {
        /// <summary>
        /// <inheritdoc cref="PublicKey"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PublicKey()
        {
            Value = null!;
            Type = null!;
        }

        /// <summary>
        /// <inheritdoc cref="PublicKey"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">This attribute indicates the Public Key coding process in which the e-mail is coded.<br/>
        /// Must comply with the format "&lt;Name&gt;-&lt;MajorVersion&gt;.&lt;MinorVersions&gt;".<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// Example.: PGP-6.5.1<br/>
        /// <br/>
        /// See <see cref="PublicKeyTypeValues"/>.</param>
        public PublicKey(string value, string type)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }

            Value = value;
            Type = type;
        }

        /// <summary>
        /// (required) Type of coding process<br/>
        /// <br/>
        /// This attribute indicates the Public Key coding process in which the e-mail is coded.<br/>
        /// Must comply with the format "&lt;Name&gt;-&lt;MajorVersion&gt;.&lt;MinorVersions&gt;".<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// Example.: PGP-6.5.1<br/>
        /// <br/>
        /// See <see cref="PublicKeyTypeValues"/>.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 64000
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
