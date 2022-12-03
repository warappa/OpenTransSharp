namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="ProductPrice.Type"/>.
    /// </summary>
    public static class ProductPriceTypeValues
    {
        /// <summary>
        /// List price<br/>
        /// <br/>
        /// (Purchasing) list price including sales tax.
        /// </summary>
        public const string GrosList = "gros_list";

        /// <summary>
        /// Customer price<br/>
        /// <br/>
        /// Customer-specific end price excluding sales tax.
        /// </summary>
        public const string NetCustomer = "net_customer";

        /// <summary>
        /// Price for express delivery<br/>
        /// <br/>
        /// Customer-specific end price for express delivery excluding sales tax.<br/>
        /// <br/>
        /// Caution:<br/>
        /// This price type is not clearly defined enough. <br/>
        /// If it is to be used regardless, the supplier and the customer must clarify the exact meaning of the price and fix it.
        /// </summary>
        public const string NetCustomerExpress = "net_customer_exp";

        /// <summary>
        /// List price<br/>
        /// <br/>
        /// (Purchasing) list price excluding sales tax.
        /// </summary>
        public const string NetList = "net_list";

        /// <summary>
        /// Nonbinding recommended price<br/>
        /// <br/>
        /// Nonbinding recommended (retail) price.
        /// </summary>
        public const string NonbindingRecommendedPrice = "nrp";
        /// <summary>
        /// Price on request<br/>
        /// <br/>
        /// The price is not given and has to be requested.
        /// </summary>
        public const string OnRequest = "on_request";
    }
}
