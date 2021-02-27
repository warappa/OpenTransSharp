using System;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="ProductFeatures.ReferenceFeatureSystemName"/>.
    /// </summary>
    public class ReferenceFeatureSystemNameValues
    {
        /// <summary>
        /// CPV<br/>
        /// <br/>
        /// Reference to the classification system CPV (Common Procurement Vocabulary) with version date (e.g., CPV-2003-12-16); see siehe http://simap.eu.int.
        /// </summary>
        public static string CPV(DateTime date) => $"CPV-{date.ToString("yyyy-MM-dd")}";

        /// <summary>
        /// eCl@ss<br/>
        /// <br/>
        /// Reference to the classification system eCl@ss with major version x and minor version y (e.g., ECLASS-5.1); see http://www.eclass-online.com.
        /// </summary>
        public static string EClass(Version version) => $"ECLASS-{version.Major}.{version.Minor}";

        /// <summary>
        /// eOTD<br/>
        /// <br/>
        /// Reference to the classification system eOTD (ECCMA Open Technical Dictionary) with version date (e.g., EOTD-2004-08-01); see http://www.eccma.org.
        /// </summary>
        public static string EOTD(DateTime date) => $"EOTD-{date.ToString("yyyy-MM-dd")}";

        /// <summary>
        /// ETIM<br/>
        /// <br/>
        /// Reference to the classification system ETIM with major version x and minor version y (e.g., ETIM-2.0); see http://www.etim.de.
        /// </summary>
        public static string ETIM(Version version) => $"ETIM-{version.Major}.{version.Minor}";

        /// <summary>
        /// GPC<br/>
        /// <br/>
        /// Reference to the classification system EAN.UCC GPC (Global Product Classification) with major version x and minor version y (e.g., GPC-4.0); see http://www.gs1.org.
        /// </summary>
        public static string GPC(Version version) => $"GPC-{version.Major}.{version.Minor}";

        /// <summary>
        /// profiCl@ss<br/>
        /// <br/>
        /// Reference to the classification system profiCl@ss with major version x and minor version y (e.g., PROFICLASS-2.1); see http://www.proficlass.de.
        /// </summary>
        public static string ProfiClass(Version version) => $"PROFICLASS-{version.Major}.{version.Minor}";

        /// <summary>
        /// RNTD<br/>
        /// <br/>
        /// Reference to the classification system RNTD (RosettaNet Technical Dictionary) with major version x and minor version y (e.g., RNTD-4.0); see http://www.rosettanet.org.
        /// </summary>
        public static string RNTD(Version version) => $"RNTD-{version.Major}.{version.Minor}";

        /// <summary>
        /// RUS<br/>
        /// <br/>
        /// Reference to the classification system RUS (Requisite Unifying Structure) with major version x and minor version y (e.g., RUS-4.0); see http://rusportal.requisite.com.
        /// </summary>
        public static string RUS(Version version) => $"RUS-{version.Major}.{version.Minor}";

        /// <summary>
        /// UNSPSC<br/>
        /// <br/>
        /// Reference to the classification system UNSPSC with major version x and minor version y (e.g., UNSPSC-6.0801); see http://www.unspsc.org.
        /// </summary>
        public static string UNSPSC(Version version) => $"UNSPSC-{version.Major}.{version.Minor.ToString().PadLeft(4)}";

        /// <summary>
        /// Proprietary classification system.<br/>
        /// <br/>
        /// Reference to a proprietary (non-standard) classification system.<br/>
        /// The value has to start with 'udf_' followed by the classification system name in capital letters, hyphen, and version (major version x and minor version y).<br/>
        /// <br/>
        /// For example: udf_MYSYSTEM-3.0.<br/>
        /// <br/>
        /// The length of the name is limited to 72 characters; the version to 7 characters.
        /// </summary>
        public static string Proprietary(string name, Version version) => $"udf_{name.ToUpperInvariant()}-{version.Major}.{version.Minor}";
        /// <summary>
        /// Other standard classification system, which is not pre-defined in BMEcat, can be described in a similar way:<br/>
        /// The name of the system in capital, followed by a hyphen and the version information.<br/>
        /// <br/>
        /// For instance, NAME-3.4.<br/>
        /// <br/>
        /// The length of the name is limited to 72 characters.<br/>
        /// The version information, where major and minor version are separated by a dot, is limited to 7 characters.
        /// </summary>
        public static string OtherSystem(string classificationSystemName, Version version) => $"{classificationSystemName.ToUpperInvariant()}-{version.Major}.{version.Minor}";
    }
}
