﻿using System.Collections.Generic;

namespace OpenTransSharp
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
        /// (required) Reference to an area<br/>
        /// <br/>
        /// Reference to the unique identifier of an area.<br/>
        /// The reference must point to an area defined in the document(element AREA identified by AREA_ID).<br/>
        /// <br/>
        /// Max length: 60
        /// </summary>
        public List<string> AreaIdrefs { get; set; } = new List<string>();
    }
}
