using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="CostCategoryId"/>.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public enum CostCategoryIdType
    {
        Undefined,
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
