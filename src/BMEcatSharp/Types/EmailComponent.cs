namespace BMEcatSharp;

[XmlInclude(typeof(EmailAddress))]
[XmlInclude(typeof(PublicKey))]
[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class EmailComponent
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void EmailsToEmailComponents(Lazy<List<Email>?> emails, ref List<EmailComponent>? emailComponents)
    {
        if (emails.Value is null)
        {
            emailComponents = [];
            return;
        }

        emailComponents ??= [];
        emailComponents.Clear();
        foreach (var email in emails.Value)
        {
            emailComponents.Add(new EmailAddress { Value = email.EmailAddress });
            emailComponents.AddRange(email.PublicKeys);
        }
    }

    public static List<Email>? EmailComponentsToEmails(List<EmailComponent>? emailComponents)
    {
        var emails = new List<Email>();
        if (emailComponents?.Count > 0)
        {
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
                    email = new Email
                    {
                        EmailAddress = emailAddress.Value
                    };
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

        return emails;
    }
}
