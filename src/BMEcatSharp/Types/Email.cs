using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;

namespace BMEcatSharp
{
    /// <summary>
    /// (E-mail addresses)<br/>
    /// <br/>
    /// This element contains a list of e-mail addresses.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlRoot("EMAIL")]
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


        //private static XmlSerializer _publicKeySerializer = new XmlSerializer(typeof(PublicKey), "http://www.bmecat.org/bmecat/2005");
        ///// <summary>
        ///// (optional - required if PublicKeys is specified) E-mail address<br/>
        ///// <br/>
        ///// e-mail address<br/>
        ///// <br/>
        ///// XML-namespace: BMECAT
        ///// </summary>
        ////[XmlArrayItem("EMAIL")]
        //[BMEXmlElement("EMAIL")]
        //public string? EmailAddress { get; set; }

        ///// <summary>
        ///// (optional) Public key<br/>
        ///// <br/>
        ///// Public key, e.g. PGP<br/>
        ///// <br/>
        ///// XML-namespace: BMECAT
        ///// </summary>
        //[BMEXmlElement("PUBLIC_KEY")]
        //public List<global::BMEcatSharp.PublicKey>? PublicKeys { get; set; } = new List<global::BMEcatSharp.PublicKey>();
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public bool PublicKeysSpecified => PublicKeys?.Count > 0;

        //public XmlSchema GetSchema()
        //{
        //    return null!;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    reader.MoveToContent();
        //    EmailAddress = (string?)reader.ReadElementContentAs(typeof(string), null);

        //    if (reader.IsStartElement() &&
        //        reader.LocalName == "PUBLIC_KEY")
        //    {
        //        var can = _publicKeySerializer.CanDeserialize(reader);
        //        while (reader.NodeType != XmlNodeType.EndElement &&
        //            reader.LocalName == "PUBLIC_KEY")
        //        {
        //            var publicKey = (PublicKey)_publicKeySerializer.Deserialize(reader);
        //            PublicKeys!.Add(publicKey);
        //        }
        //    }
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    //writer.WriteStartElement("EMAIL");
        //    writer.WriteString(EmailAddress);

        //    if (PublicKeys is not null)
        //    {
        //        writer.WriteEndElement();
        //        foreach (var publicKey in PublicKeys)
        //        {
        //            _publicKeySerializer.Serialize(writer, publicKey);
        //        }
        //    }
        //}
    }
}
