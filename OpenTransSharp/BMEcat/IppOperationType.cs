using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="IppOperation.Type"/>.
    /// </summary>
    public enum IppOperationType
    {
        /// <summary>
        /// Create<br/>
        /// <br/>
        /// <list type="bullet">
        ///     <item>IPP application "external catalog": jumps to the external website of the IPP provider to build up a product list vie user interaction (e.g. product search or product configuration).</item>
        ///     <item>a</item>
        /// </list>
        /// </summary>
        [XmlEnum("create")]
        Create,
        /// <summary>
        /// Process<br/>
        /// <br/>
        /// The meaning depends on the type of the IPP application (see IPP_TYPE).<br/>
        /// <list type="bullet">
        ///     <item>IPP application "product inquiry": starts a product inquiry for a list of products.</item>
        ///     <item>IPP application "price inquiry": starts a price inquiry for a list of products.</item>
        ///     <item>IPP application "availability inquiry": starts an availability inquiry for a list of products.</item>
        ///     <item>IPP application "request for quotation": starts a request for quotation for a list of products.</item>
        /// </list>
        /// </summary>
        [XmlEnum("process")]
        Process,
        /// <summary>
        /// Recreate<br/>
        /// <br/>
        /// The meaning depends on the type of the IPP application (see IPP_TYPE).<br/>
        /// <list type="bullet">
        ///     <item>IPP application "external catalog": makes a copy of the (old) product list and creates out of that a new changeble product list on the external website.</item>
        /// </list>
        /// </summary>
        [XmlEnum("recreate")]
        Recreate,
        /// <summary>
        /// Show<br/>
        /// <br/>
        /// The meaning depends on the type of the IPP application (see IPP_TYPE).<br/>
        /// <br/>
        /// <list type="bullet">
        ///     <item>IPP application "external catalog": shows a shopping basket on the exsternal system (may include status information).</item>
        ///     <item>IPP application "request for quotation": shows the status of a started request for quotation on the external system.</item>
        /// </list>
        /// </summary>
        [XmlEnum("show")]
        Show
    }
}
