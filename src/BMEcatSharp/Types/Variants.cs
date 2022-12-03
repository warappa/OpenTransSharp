using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
{
    /// <summary>
    /// (Variants)<br/>
    /// <br/>
    /// This element describes variants of products.<br/>
    /// The product variants have no effect on the price of the product.<br/>
    /// The variants are described using the element VARIANT.<br/>
    /// These variants expand the basic product number (SUPPLIER_PID) of the product by a suffix.<br/>
    /// VARIANTS is used to link together different products of the same price and with only a few different feature values by expanding the basic product number by a few positions depending on the variant chosen in order to achieve unique identification of the variant.<br/>
    /// <br/>
    /// The basic product number must already be unique when used alone even if it is to be used with variants.<br/>
    /// <br/>
    /// This element will not be used in the future.
    /// </summary>
    public class Variants
    {
        /// <summary>
        /// <inheritdoc cref="Variants"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Variants() { }

        /// <summary>
        /// <inheritdoc cref="Variants"/>
        /// </summary>
        /// <param name="variantOrder"></param>
        /// <param name="featureVariants"></param>
        public Variants(int variantOrder, IEnumerable<Variant> featureVariants)
        {
            if (featureVariants is null)
            {
                throw new ArgumentNullException(nameof(featureVariants));
            }

            VariantOrder = variantOrder;
            FeatureVariants = featureVariants.ToList();
        }

        /// <summary>
        /// (required) Variant<br/>
        /// <br/>
        /// Description of a variant (feature value and product number supplement).
        /// </summary>
        [BMEXmlElement("VARIANT")]
        public List<Variant> FeatureVariants { get; set; } = new List<Variant>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureVariantsSpecified => FeatureVariants?.Count > 0;

        /// <summary>
        /// (required) Variant Order<br/>
        /// <br/>
        /// Defines which order is to be used to link the product number supplement (SUPPLIER_AID_SUPPLEMENT) with the basic product number (SUPPLIER_PID); the product number expansions are linked to the value VORDER in ascending order.
        /// </summary>
        [BMEXmlElement("VORDER")]
        public int VariantOrder { get; set; }
    }
}
