using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
{
    /// <summary>
    /// (Area references)<br/>
    /// <br/>
    /// This element contains a list of area.The areas are not defined here, but referenced by their identifier.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class AreaRef
    {
        /// <summary>
        /// <inheritdoc cref="AreaRef"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AreaRef() { }

        /// <summary>
        /// <inheritdoc cref="AreaRef"/>
        /// </summary>
        /// <param name="idrefs"></param>
        public AreaRef(IEnumerable<string> idrefs)
        {
            if (idrefs is null)
            {
                throw new System.ArgumentNullException(nameof(idrefs));
            }

            Idrefs = idrefs.ToList();
        }

        /// <summary>
        /// (required) Reference to an area<br/>
        /// <br/>
        /// Reference to the unique identifier of an area.<br/>
        /// The reference must point to an area defined in the document(element AREA identified by AREA_ID).<br/>
        /// <br/>
        /// Max length: 60<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AREA_IDREF")]
        public List<string> Idrefs { get; set; } = new List<string>();
    }
}
