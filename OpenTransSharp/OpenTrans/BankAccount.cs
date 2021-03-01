using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Account number)<br/>
    /// <br/>
    /// Code to identify an account; the attribute "type" determines the coding of the account.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Many coding-standards do not allow that the credit institution or bank is stored in the account number.<br/>
    /// In those cases the credit institution is quoted via the BANK_CODE-element.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class BankAccount
    {
        public BankAccount()
        {
        }

        public BankAccount(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">For predefined values see <see cref="BankAccountTypeValues"/>.<br/>
        /// Custom values can also be used.</param>
        public BankAccount(string value, string type)
            : this(value)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }

            Type = type;
        }

        /// <summary>
        /// (optional) Coding of the account number<br/>
        /// <br/>
        /// Attribute indicating the coding-standard for the account number.<br/>
        /// <br/>
        /// Max length: 20<br/>
        /// <br/>
        /// See <see cref="BankAccountTypeValues"/>.
        /// </summary>
        [OpenTransXmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 100
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
