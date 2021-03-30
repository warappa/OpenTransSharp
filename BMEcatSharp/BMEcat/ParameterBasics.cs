﻿using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Basic parameter information)<br/>
    /// <br/>
    /// This element provides basic information on the paraemter; it is not necessary, if the parameter has been derived from a property of a classification system (then, it is described there).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ParameterBasics
    {
        /// <summary>
        /// (required) Parameter name<br/>
        /// <br/>
        /// Name of the parameter.<br/>
        /// The name is shown in the GUI when listing the values for a product, e.g., Metal weight: 0.5 kg.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_NAME")]
        public List<MultiLingualString> Name { get; set; } = new List<MultiLingualString>();

        /// <summary>
        /// (optional) Parameter description<br/>
        /// <br/>
        /// This element is used to describe the parameter.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_DESCR")]
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

        /// <summary>
        /// (optional) Parameter description<br/>
        /// <br/>
        /// Unit of measurement of the parameter.<br/>
        /// The unit is shown in the GUI when listing the values for a product, e.g., Metal weight: 0.5 kg.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARAMETER_UNIT")]
        public List<MultiLingualString>? Unit { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UnitSpecified => Unit?.Count > 0;

    }
}
