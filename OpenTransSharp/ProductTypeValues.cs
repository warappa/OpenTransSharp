using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// Predefined values for <see cref="ProductId.ProductType"/>
    /// </summary>
    public enum ProductTypeValues
    {
        /// <summary>
        /// Product bundle<br/>
        /// <br/>
        /// The product is part of a product bundle.
        /// </summary>
        [XmlEnum("bundle")]
        Bundle,
        /// <summary>
        /// Component<br/>
        /// <br/>
        /// The product is component of another product.
        /// </summary>
        [XmlEnum("component")]
        Component,
        /// <summary>
        /// Optionally configurable<br/>
        /// <br/>
        /// The product can be configured.<br/>
        /// If the product is not configured by the user, it is determined by its default values.<br/>
        /// See also PRODUCT_TYPE =must_be_configured.
        /// </summary>
        [XmlEnum("configurable")]
        Configurable,
        /// <summary>
        /// Contract<br/>
        /// <br/>
        /// The product is a contract.
        /// </summary>
        [XmlEnum("contract")]
        Contract,
        /// <summary>
        /// License<br/>
        /// <br/>
        /// The product is a licence.
        /// </summary>
        [XmlEnum("license")]
        License,
        /// <summary>
        /// Orderable product<br/>
        /// <br/>
        /// The product can be ordered (see minor).
        /// </summary>
        [XmlEnum("major")]
        Major,
        /// <summary>
        /// Product part<br/>
        /// <br/>
        /// The product can only be ordered in conjunction with another product.
        /// </summary>
        [XmlEnum("minor")]
        Minor,
        /// <summary>
        /// Configurable<br/>
        /// <br/>
        /// The product has to be configured, unless it can not be ordered.<br/>
        /// See also PRODUCT_TYPE =configurable.
        /// </summary>
        [XmlEnum("must_be_configured")]
        MustBeConfigured,
        /// <summary>
        /// Physical product<br/>
        /// <br/>
        /// The product is physical, thus tangible.
        /// </summary>
        [XmlEnum("physical")]
        Physical,
        /// <summary>
        /// Professional service<br/>
        /// <br/>
        /// The product is a professional service being provided by one or more individuals.<br/>
        /// The indivials are professionals in their field (e.g., accounting, educational, legal, medical, or architectural services).
        /// </summary>
        [XmlEnum("professional_services")]
        ProfessionalServices,
        /// <summary>
        /// Service<br/>
        /// <br/>
        /// The product is a service.
        /// </summary>
        [XmlEnum("ervice")]
        Service
    }
}
