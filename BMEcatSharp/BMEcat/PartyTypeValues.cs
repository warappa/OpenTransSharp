namespace OpenTransSharp
{
    /// <summary>
    /// Predefined values for <see cref="PartyId.Type"/>.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class PartyTypeValues
    {
        /// <summary>
        /// Buyer-specific number<br/>
        /// <br/>
        /// Identification number defined by the buyer.
        /// </summary>
        public const string BuyerSpecific = "buyer_specific";
        /// <summary>
        /// Customer specific number<br/>
        /// <br/>
        /// Identification number defined by the customer.
        /// </summary>
        public const string CustomerSpecific = "customer_specific";
        /// <summary>
        /// Dun & Bradstreet<br/>
        /// <br/>
        /// DUNS-Number (see also http://dbuk.dnb.com/english/DataBase/duns.html).
        /// </summary>
        public const string Duns = "duns";
        /// <summary>
        /// Global location number<br/>
        /// <br/>
        /// Internationally called GLN (see GLN below).
        /// </summary>
        public const string Iln = "iln";
        /// <summary>
        /// Global location number<br/>
        /// <br/>
        /// Global Location Number GLN (see also http://www.ean-int.org/locations.html).
        /// </summary>
        public const string Gln = "gln";
        /// <summary>
        /// Party-specific number<br/>
        /// <br/>
        /// Identification number defined by the respective party.
        /// </summary>
        public const string PartySpecific = "party_specific";
        /// <summary>
        /// Supplier-specific number<br/>
        /// <br/>
        /// Identification number defined by the supplier.
        /// </summary>
        public const string SupplierSpecific = "supplier_specific";
    }
}
