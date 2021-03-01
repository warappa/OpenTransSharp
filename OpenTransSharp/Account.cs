using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Bank account)<br/>
    /// <br/>
    /// The ACCOUNT element summarizes information about bank accounts.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// (requrired) Account holder<br/>
        /// <br/>
        /// Name of the account holder.
        /// </summary>
        [XmlElement("HOLDER")]
        public string Holder { get; set; }

        /// <summary>
        /// (required) Account number<br/>
        /// <br/>
        /// Code to identify an account; the attribute "type" determines the coding of the account.<br/>
        /// <br/>
        /// Caution:<br/>
        /// Many coding-standards do not allow that the credit institution or bank is stored in the account number. In those cases the credit institution is quoted via the BANK_CODEelement.
        /// </summary>
        [XmlElement("BANK_ACCOUNT")]
        public BankAccount BankAccount { get; set; } = new BankAccount();

        /// <summary>
        /// (optional) Bank code<br/>
        /// <br/>
        /// Bank identification number; the attribute "type" indicates the coding of this number.
        /// </summary>
        [XmlElement("BANK_CODE")]
        public BankCode? BankCode { get; set; }

        /// <summary>
        /// (optional) Bank name<br/>
        /// <br/>
        /// Name of the bank.
        /// </summary>
        [XmlElement("BANK_NAME")]
        public string? BankName { get; set; }

        /// <summary>
        /// (optional) Country<br/>
        /// <br/>
        /// Country in which the bank account is managed.
        /// </summary>
        [XmlElement("BANK_COUNTRY")]
        public CountryCode? BankCountry { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BankCountrySpecified => BankCountry.HasValue;
    }
}
