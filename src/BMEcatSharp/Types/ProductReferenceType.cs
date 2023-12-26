using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// For <see cref="ProductReference.Type"/>.
/// </summary>
public enum ProductReferenceType
{
    /// <summary>
    /// Accessories<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is an accessory product of the source product.<br/>
    /// An accessory product is considered to extend the functionality of the source product.
    /// </summary>
    [XmlEnum("accessories")]
    Accessories,
    /// <summary>
    /// Base product<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is the base product of of the source product, thus the base product is an abstract, packing-independent description of the source product<br/>
    /// Example: Source product = six pack of beer; base product = beer without any packing information.
    /// </summary>
    [XmlEnum("base_product")]
    BaseProduct,
    /// <summary>
    /// Component part<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is a component part of this source product.<br/>
    /// This type of reference can be used to build up parts lists.<br/>
    /// Reference is always made from the parent part to the parts it consists of.<br/>
    /// In order to reference the number of reference parts contained, the attribute "quantity" can be added.<br/>
    /// Refer also to Example 3.
    /// </summary>
    [XmlEnum("consists_of")]
    ConsistsOf,
    /// <summary>
    /// Alternative packing unit<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO consists of the same basic product as the source product.<br/>
    /// The source product is available in different packaging, however.<br/>
    /// <br/>
    /// Example: Reference from a barrel of beer to a bottle of beer, or from a packet of paper to a pallet (containing many packets).
    /// </summary>
    [XmlEnum("diff_orderunit")]
    DiffOrderunit,
    /// <summary>
    /// Follow-up article<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is the follow-up product to this source product.<br/>
    /// A follow-up product is defined as a product which has the same purpose and functions as the source product and can be considered a more advanced version of it.
    /// </summary>
    [XmlEnum("followup")]
    Followup,
    /// <summary>
    /// Mandatory additional product<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is a mandatory additional product which must always be ordered at the same time as the product article.<br/>
    /// The source product described cannot be ordered alone.<br/>
    /// If several products are marked "mandatory" they must all be ordered together with the source product.
    /// </summary>
    [XmlEnum("mandatory")]
    Mandatory,
    /// <summary>
    /// Similar product<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is similar to this source product.<br/>
    /// A similar product is defined as a product which is similar in purpose and functions to the source product and can possibly be used in its place.
    /// </summary>
    [XmlEnum("similar")]
    Similar,
    /// <summary>
    /// Selectable mandatory product<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is a selectable additional product.<br/>
    /// The described reference product cannot be ordered alone.<br/>
    /// If several products are connected by "select" at least one of the additional products for the source product listed under PROD_ID_TO must be ordered.
    /// </summary>
    [XmlEnum("select")]
    Select,
    /// <summary>
    /// Spare part<br/>
    /// <br/>
    /// The reference product listed under PROD_ID_TO is a spare part for this source product.<br/>
    /// A spare part is defined as a part of the product that can be replaced separately in the course of maintenance and repair activities.
    /// </summary>
    [XmlEnum("sparepart")]
    Sparepart,
    /// <summary>
    /// Other reference type<br/>
    /// <br/>
    /// This reference type can be used if none of the other reference types adequately describes the relationship between the reference product and the source product.
    /// </summary>
    [XmlEnum("others")]
    Others
}
