namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="SupplierPid"/>.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public static class SupplierPidTypeValues
    {
        /// <summary>
        /// Identification number defined by the buyer.<br/>
        /// </summary>
        public const string BuyerSpecific = "buyer_specific";

        /// <summary>
        /// European article number (14 characters), s. http://www.ean-int.org.
        /// </summary>
        public const string Ean = "ean";

        /// <summary>
        /// Global Trade Item Number, see http://www.uc-council.org/2005sunrise/global_trade_item_number.html.
        /// </summary>
        public const string Gtin = "gtin";

        /// <summary>
        /// Identification number defined by the supplier.
        /// </summary>
        public const string SupplierSpecific = "supplier_specific";

        /// <summary>
        /// Universal Product Code; see http://www.uc-council.org.
        /// </summary>
        public const string Upc = "upc";
    }
}
