namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="PaymentTerm.Type"/>.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public static class PaymentTermTypeValues
    {
        /// <summary>
        /// UN/ECE<br/>
        /// <br/>
        /// Description of the term of payment according to UN/ECE convention 4279. (see http://www.unece.org/trade/untdid/d00b/tred/tred4279.htm).
        /// </summary>
        public const string UnEce = "unece";
        /// <summary>
        /// Other<br/>
        /// <br/>
        /// Means that there is no descriptive procedure to be used for the term of payment but a free text instead.
        /// </summary>
        public const string Other = "other";
    }
}
