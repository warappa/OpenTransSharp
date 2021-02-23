using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="CostCategoryId"/>.
    /// </summary>
    public enum CostCategoryIdType
    {
        /// <summary>
        /// Cost center<br/>
        /// <br/>
        /// The costs are charged to a cost center.
        /// </summary>
        [XmlEnum("cost_center")]
        CostCenter,
        /// <summary>
        /// Project<br/>
        /// <br/>
        /// The costs are charged to a project.
        /// </summary>
        [XmlEnum("project")]
        Project,
        /// <summary>
        /// Work order<br/>
        /// <br/>
        /// The costs are charged to a work order.
        /// </summary>
        [XmlEnum("work_order")]
        WorkOrder
    }
}
