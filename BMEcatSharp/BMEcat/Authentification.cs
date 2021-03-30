using BMEcatSharp.Xml;
using System.ComponentModel.DataAnnotations;

namespace BMEcatSharp
{
    /// <summary>
    /// (Authentification information)<br/>
    /// <br/>
    /// This element contains authentification information that is forwarded to the respective application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Authentification
    {
        public Authentification()
        {
        }

        public Authentification(string login, string password)
        {
            Login = login;
            Password = password;
        }

        /// <summary>
        /// (required) Login<br/>
        /// <br/>
        /// Login as part of the authentification<br/>
        /// <br/>
        /// Max length: 60<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("LOGIN")]
        public string Login { get; set; }

        /// <summary>
        /// (optional) Passwort<br/>
        /// <br/>
        /// Password for the login.<br/>
        /// <br/>
        /// Max length: 20<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PASSWORD")]
        public string Password { get; set; }
    }
}
