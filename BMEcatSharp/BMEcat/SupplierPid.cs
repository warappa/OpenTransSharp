﻿using BMEcatSharp.Xml;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Supplier's product ID)<br/>
    /// <br/>
    /// This element contains the product number issued by the supplier.<br/>
    /// It is determining for ordering the product; it identifies the product in the supplier catalog.<br/>
    /// In multi-supplier catalogs, however, only the combination of SUPPLIER_PID and SUPPLIER_IDREF identifies a product.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Some target systems are not able to accept all 32 characters (e.g., SAP max. 18 characters).<br/>
    /// It is therefore advisable to keep product identifications as short as possible.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class SupplierPid
    {
        public SupplierPid()
        {
        }

        public SupplierPid(string value)
        {
            Value = value;
        }

        /// <summary>        
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">For predefined values see <see cref="SupplierPidTypeValues"/>. Custom values can be used.</param>
        public SupplierPid(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) This attribute specifies the type of ID, i.e. indicates the organization that has issued the ID.<br/>
        /// <br/>
        /// For predefined values see <see cref="SupplierPidTypeValues"/>. Custom values can be used.<br/>
        /// </summary>
        [BMEXmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Caution:<br/>
        /// Some target systems are not able to accept all 32 characters (e.g., SAP max. 18 characters).<br/>
        /// It is therefore advisable to keep product identifications as short as possible.
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}