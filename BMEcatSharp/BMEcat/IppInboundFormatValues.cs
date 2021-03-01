using System;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="IppInbound.InboundFormat"/>.
    /// </summary>
    public static class IppInboundFormatValues
    {
        /// <summary>
        /// Nutzung des Austauschformates BMEcat 2005. Hinweis: Die entsprechenden Dokumenttypen sind in der vorliegenden BMEcat-Version nicht definiert; die Bereitstellung der Dokumente erfolgt ggf. in einer zukünftigen Version.
        /// </summary>
        public const string BMEcat2005 = "BMECAT-2005";

        /// <summary>
        /// Nutzung des Austauschformates cXML von Ariba (z.B. CXML-1.2.011; siehe auch http://www.cxml.org) .
        /// </summary>
        public static string CXML(Version version) => $"CXML-{version.Major}.{version.Minor}.{version.Revision.ToString().PadLeft(3)}";

        /// <summary>
        /// Nutzung des Austauschformates OCI (Open Catalog Interface) von SAP (z.B. OCI-2.0B oder OCI-4.0; siehe auch http://help.sap.com/saphelp_crm20c/helpdata/en/0F/F2573901F0FE7CE10000000A114084/frameset.htm)
        /// </summary>
        public static string OCI(Version version, string revisionLetter = "") => $"OCI-{version.Major}.{version.Minor}{revisionLetter}";

        /// <summary>
        /// Nutzung des Austauschformates openTRANS (z.B. OPENTRANS-1.0; siehe auch www.opentrans.org) insbesondere für die Rückübermittlung eines Angebots (siehe auch IPP_TYPE=rfq).
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static string OpenTrans(Version version) => $"OPENTRANS-{version.Major}.{version.Minor}";

        /// <summary>
        /// Nutzung von E-Mail-Übertragung für die IPP-Rückgabe; die zu verwendende E-Mail-Adresse ist bilateral abzusprechen.
        /// </summary>
        public const string Email = "email";

        /// <summary>
        /// Nutzung von Fax für die IPP-Rückgabe; die zu verwendende Fax-Nummer ist bilateral abzusprechen.
        /// </summary>
        public const string Fax = "fax";

        /// <summary>
        /// Nutzung von Post/Brief für die IPP-Rückgabe; die Postadresse ist bilateral abzusprechen.
        /// </summary>
        public const string Mail = "mail";
    }
}
