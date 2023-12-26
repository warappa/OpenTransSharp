namespace OpenTransSharp.Tests.Quotations;

internal class QuotationTestConfig
{
    private readonly TestConfig parent;

    public QuotationTestConfig(TestConfig parent)
    {
        this.parent = parent;
    }

    public Quotation GetQuotation()
    {
        var model = new Quotation
        {
            Header = GetHeader()
        };

        model.Items.Add(GetQuotationItem());

        model.Summary = GetSummary();

        return model;
    }

    private QuotationSummary GetSummary()
    {
        var model = new QuotationSummary
        {
            TotalItemCount = 1
        };

        return model;
    }

    private QuotationItem GetQuotationItem()
    {
        var model = new QuotationItem
        {
            LineItemId = "1",
            ProductId = parent.GetProductId(),
            Quantity = 2,
            OrderUnit = BMEcatSharp.PackageUnit.C62,
            ProductPriceFix = parent.GetProductPriceFix(),
            PriceLineAmount = 10,
            PartialShipmentAllowed = false,
            DeliveryDate = parent.GetDeliveryDate(),
            Transport = parent.BMEcats.GetTransport()
        };
        model.SpecialTreatmentClasses.Add(parent.BMEcats.GetSpecialTreatmentClass());
        model.Remarks.AddRange(parent.GetRemarks());

        return model;
    }

    internal Quotation GetQuotationWithUdx()
    {
        var model = GetQuotation();

        model.Header.Information.HeaderUdx.Add(new CustomData()
        {
            Names = new List<string>
            {
                "Name 1",
                "Name 2"
            }
        });
        model.Header.Information.HeaderUdx.Add(new CustomData2()
        {
            Name = "Name 3"
        });

        model.Items[0].ItemUdx.Add(new CustomData()
        {
            Names = new List<string>
            {
                "Name 1",
                "Name 2"
            }
        });
        model.Items[0].ItemUdx.Add(new CustomData2()
        {
            Name = "Name 3"
        });

        return model;
    }

    private QuotationHeader GetHeader()
    {
        var header = new QuotationHeader
        {
            ControlInformation = parent.GetControlInformation(),

            Information = GetQuotationInformation()
        };

        return header;
    }

    private QuotationInformation GetQuotationInformation()
    {
        var model = new QuotationInformation
        {
            Id = "QuotationId",
            Date = DateTime.UtcNow,
            DeliveryDate = parent.GetDeliveryDate()
        };
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
        model.MimeRoot = parent.BMEcats.GetMimeRoot();
        model.Parties.AddRange(parent.GetParties());
        model.OrderPartiesReference = parent.GetOrderPartiesReference();
        model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
        model.Currency = "EUR";
        model.MimeInfo = parent.GetMimeInfo();
        model.Remarks.AddRange(parent.GetRemarks());

        return model;
    }
}
