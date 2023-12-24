using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    [XmlInclude(typeof(EmailAddress))]
    [XmlInclude(typeof(PublicKey))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class EmailComponent
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void EmailsToEmailComponents(ref List<Email>? emails, ref List<EmailComponent>? emailComponents)
        {
            if (emails is null)
            {
                emailComponents = null;
                return;
            }

            emailComponents ??= new List<EmailComponent>();
            emailComponents.Clear();
            foreach (var email in emails)
            {
                emailComponents.Add(new EmailAddress { Value = email.EmailAddress });
                emailComponents.AddRange(email.PublicKeys);
            }
        }

        public static void EmailComponentsToEmails(ref List<EmailComponent>? emailComponents, ref List<Email>? emails)
        {
            emails ??= new List<Email>();
            emails.Clear();
            if (emailComponents?.Count > 0)
            {
                emails ??= new List<Email>();

                Email? email = null;
                for (var i = 0; i < emailComponents.Count; i++)
                {
                    var component = emailComponents[i];
                    if (component is EmailAddress emailAddress)
                    {
                        if (email is not null)
                        {
                            emails.Add(email);
                        }
                        email = new Email();
                        email.EmailAddress = emailAddress.Value;
                    }
                    else if (component is PublicKey publicKey)
                    {
                        email?.PublicKeys!.Add(publicKey);
                    }
                }

                if (email is not null)
                {
                    emails.Add(email);
                }
            }
        }
    }
}
