namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="BankAccount.Type"/>.
    /// </summary>
    public static class BankAccountTypeValues
    {
        /// <summary>
        /// Bank Account Number<br/>
        /// <br/>
        /// Bank account number, in opposite to the IBAN-Coding without informations to the credit institution.<br/>
        /// In case of the value "standard" of the attribute "type", for unique identification the element BANK_CODE must be specified.
        /// </summary>
        public const string Standard = "standard";
        /// <summary>
        /// International Bank Account Number<br/>
        /// <br/>
        /// Global unique identifier of an account including coding of the credit institution (ISO 13616:2003); http://www.swift.com/index.cfm?item_id=61731.
        /// </summary>
        public const string Iban = "iban";
    }
}
