﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace BMEcatSharp.Tests
{
    [XmlRoot("UDX.CUSTOM_DATA")]
    public class CustomData
    {
        [XmlElement("UDX.CUSTOM_DATA.NAME")]
        public List<string> Names { get; set; } = new List<string>();
    }
}