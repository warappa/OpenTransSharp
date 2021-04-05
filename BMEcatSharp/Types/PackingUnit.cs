using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Packing unit)<br/>
    /// <br/>
    /// Information on the packing unit and its validity for one order unit respectively an order unit interval.<br/>
    /// By its sub elements SUPPLIER_PIDREF and SUPPLIER_IDREF it is possible to reference another product, if the bigger packing unit can be ordered directly by this other product ID and its order conditions.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class PackingUnit
    {
        /// <summary>
        /// <inheritdoc cref="PackingUnit"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PackingUnit()
        {
            Code = null!;
        }

        /// <summary>
        /// <inheritdoc cref="PackingUnit"/>
        /// </summary>
        /// <param name="minimumQuantity"></param>
        /// <param name="maximumQuantity"></param>
        /// <param name="code"></param>
        /// <param name="supplierPid"></param>
        public PackingUnit(decimal minimumQuantity, decimal maximumQuantity, string code, SupplierPid supplierPid)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException($"'{nameof(code)}' cannot be null or whitespace.", nameof(code));
            }

            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Code = code;
            SupplierPid = supplierPid ?? throw new ArgumentNullException(nameof(supplierPid));
        }

        /// <summary>
        /// <inheritdoc cref="PackingUnit"/>
        /// </summary>
        /// <param name="minimumQuantity"></param>
        /// <param name="maximumQuantity"></param>
        /// <param name="code"></param>
        /// <param name="supplierPIdref"></param>
        public PackingUnit(decimal minimumQuantity, decimal maximumQuantity, string code, string supplierPIdref)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException($"'{nameof(code)}' cannot be null or whitespace.", nameof(code));
            }

            if (string.IsNullOrWhiteSpace(supplierPIdref))
            {
                throw new ArgumentException($"'{nameof(supplierPIdref)}' cannot be null or whitespace.", nameof(supplierPIdref));
            }

            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Code = code;
            SupplierPIdref = supplierPIdref;
        }

        /// <summary>
        /// (required) Minimum quantity<br/>
        /// <br/>
        /// Minimum order quantity with respect to the order unit (ORDER_UNIT); if not specified, the minimum order quantity is 1.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("QUANTITY_MIN")]
        public decimal MinimumQuantity { get; set; } = 1;

        /// <summary>
        /// (required) Maximum quantity<br/>
        /// <br/>
        /// Maximum order quantity with respect to the order unit (ORDER_UNIT); if not specified, the order quantity is not limited.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("QUANTITY_MAX")]
        public decimal MaximumQuantity { get; set; }

        /// <summary>
        /// (required) Packing unit code<br/>
        /// <br/>
        /// Code for the packing unit; has to be selected from the list of predefined values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PACKING_UNIT_CODE")]
        public string Code { get; set; }

        /// <summary>
        /// (optional) Packing unit description <br/>
        /// <br/>
        /// Description of the packing unit, i.e. explaination, additional information, hints etc.
        /// </summary>
        [XmlElement("PACKING_UNIT_DESCR")]
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

        /// <summary>
        /// (required - choice SupplierPid/SupplierPidref with SupplierIdref) Supplier's product ID<br/>
        /// <br/>
        /// This element contains the product number issued by the supplier.<br/>
        /// It is determining for ordering the product; it identifies the product in the supplier catalog.<br/>
        /// In multi-supplier catalogs, however, only the combination of SUPPLIER_PID and SUPPLIER_IDREF identifies a product.<br/>
        /// <br/>
        /// Caution:<br/>
        /// Some target systems are not able to accept all 32 characters (e.g., SAP max. 18 characters).<br/>
        /// It is therefore advisable to keep product identifications as short as possible.<br/>
        /// <br/>
        /// Are there different product variants (VARIANTS) the final product number is built via the concatenation of the (base) product number (SUPPLIER_PID) with the related product numbers supplements (SUPPLIER_AID_SUPPLEMENT).<br/>
        /// <br/>
        /// Caution:<br/>
        /// The (base) product number has to be distinct on its own even when variants or configurations are used.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_PID")]
        public SupplierPid? SupplierPid { get; set; }

        /// <summary>
        /// (required - choice SupplierPid/SupplierPidref with SupplierIdref) Reference to a product number<br/>
        /// <br/>
        /// This element provides a reference to a product number of the supplier.<br/>
        /// It contains the unique identifier (SUPPLIER_PID) that is defined in the document.<br/>
        /// In this context the element is used to reference the product number of the content.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_PIDREF")]
        public string? SupplierPIdref { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref? SupplierIdref { get; set; }
    }
}
