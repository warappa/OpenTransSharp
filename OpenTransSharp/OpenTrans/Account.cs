﻿using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    //public enum CountryCode  { }
    //public enum LanguageCodes
    //{
    //    Undefined,
    //    deu,
    //    eng
    //}
    //public class MultiLingualString : global::BMEcatSharp.MultiLingualString
    //{
    //    public MultiLingualString()
    //    {
    //    }

    //    public MultiLingualString(string value) : base(value)
    //    {
    //    }

    //    public MultiLingualString(string value, BMEcatSharp.LanguageCodes language) : base(value, language)
    //    {
    //    }
    //}
    public interface IValidatable : global::BMEcatSharp.IValidatable
    {

    }
    //public class AccountingInformation : global::BMEcatSharp.AccountingInformation { }
    //public class CustomsTariffNumber : global::BMEcatSharp.CustomsTariffNumber { }
    //public class ProductDimensions : global::BMEcatSharp.ProductDimensions { }
    //public class Transport : global::BMEcatSharp.Transport { }
    //public class MeansOfTransport : global::BMEcatSharp.MeansOfTransport { }
    //public class BMEcatDatetime : global::BMEcatSharp.BMEcatDatetime { }
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
        public global::BMEcatSharp.CountryCode? BankCountry { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BankCountrySpecified => BankCountry.HasValue;
    }
}
