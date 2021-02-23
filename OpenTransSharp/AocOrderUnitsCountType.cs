using System.Xml.Serialization;

namespace OpenTransSharp
{
    public enum AocOrderUnitsCountType
    {
        /// <summary>
        /// Bonus (bonus included in order)<br/>
        /// <br/>
        /// The specified units are give-aways and are subtracted from the ordered quantity (QUANTITY) while the total amount is being calculated. 
        /// </summary>
        [XmlEnum("inclusive")]
        Inclusive,

        /// <summary>
        /// Extra Bonus (bonus excluded from order)<br/>
        /// <br/>
        /// The specified units are an extra bonus in addition to the ordered QUANTITY.
        /// </summary>
        [XmlEnum("exclusive")]
        Exclusive
    }
}
