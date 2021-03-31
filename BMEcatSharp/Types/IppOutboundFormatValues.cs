using System;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="IppOutbound.Format"/>.
    /// </summary>
    public class IppOutboundFormatValues
    {
        /// <summary>
        /// BMEcat<br/>
        /// <br/>
        /// Use of the exchange format BMEcat 2005. Attention: The needed document types are not specified yet; they may be available in future versions.
        /// </summary>
        public const string BMEcat2005 = "BMECAT-2005";

        /// <summary>
        /// cXML<br/>
        /// <br/>
        /// Use of the exchange format cXML by Ariba (e.g., CXML-1.2.011; see also http://www.cxml.org).
        /// </summary>
        public static string CXML(Version version) => $"CXML-{version.Major}.{version.Minor}.{version.Revision.ToString().PadLeft(3)}";

        /// <summary>
        /// OCI<br/>
        /// <br/>
        /// Use of the exchange format OCI (Open Catalog Interface) by SAP (e.g., OCI-2.0B oder OCI-4.0; see also http://help.sap.com/saphelp_crm20c/helpdata/en/0F/F2573901F0FE7CE10000000A114084/frameset.htm).
        /// </summary>
        public static string OCI(Version version, string revisionLetter = "") => $"OCI-{version.Major}.{version.Minor}{revisionLetter}";

        /// <summary>
        /// openTRANS<br/>
        /// <br/>
        /// Use of the exchange openTRANS (e.g., OPENTRANS-1.0; see also www.opentrans.org) especially for the exchange of a quotation (see also IPP_TYPE=rfq)).
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static string OpenTrans(Version version) => $"OPENTRANS-{version.Major}.{version.Minor}";
    }
}
