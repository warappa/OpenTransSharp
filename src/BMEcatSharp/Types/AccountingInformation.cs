namespace BMEcatSharp;

/// <summary>
/// (Accounting information)<br/>
/// <br/>
/// This element contains information about accounting processes which occur at the buying company as a result of the order.<br/>
/// This information includes the number of the identification of the cost category concerned, the type of cost as well as the actual account.<br/>
/// The accounting information is given by the buying company so that the supplier can indicate it on the invoice, which in turn facilitates checking and auditing invoices at the buying company.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class AccountingInformation
{
    /// <summary>
    /// <inheritdoc cref="AccountingInformation"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AccountingInformation() { }

    /// <summary>
    /// <inheritdoc cref="AccountingInformation"/>
    /// </summary>
    /// <param name="costCategoryId"></param>
    public AccountingInformation(CostCategoryId costCategoryId)
    {
        CostCategoryId = costCategoryId ?? throw new System.ArgumentNullException(nameof(costCategoryId));
    }

    /// <summary>
    /// (required) Cost category<br/>
    /// <br/>
    /// Number of the cost center to be charged or the project or work order to which the charge must be made.<br/>
    /// The type of cost category is fixed by the attribute "type".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("COST_CATEGORY_ID")]
    public CostCategoryId CostCategoryId { get; set; } = new CostCategoryId();

    /// <summary>
    /// (optional) Type of cost <br/>
    /// <br/>
    /// Information about the type of cost, e.g. investment, service, consumption, etc.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("COST_TYPE")]
    public string? CostType { get; set; }

    /// <summary>
    /// (optional) Cost account<br/>
    /// <br/>
    /// Number of the main account to be charged.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("COST_ACCOUNT")]
    public string? CostAccount { get; set; }
}
