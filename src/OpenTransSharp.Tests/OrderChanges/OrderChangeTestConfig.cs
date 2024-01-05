namespace OpenTransSharp.Tests.OrderChanges;

internal class OrderChangeTestConfig
{
    private readonly TestConfig parent;

    public OrderChangeTestConfig(TestConfig parent)
    {
        this.parent = parent;
    }

    public OrderChange GetOrderChange()
    {
        var model = new OrderChange
        {
            Header = GetHeader()
        };

        model.Items.Add(GetOrderChangeItem());

        model.Summary = GetSummary();

        return model;
    }

    private OrderChangeSummary GetSummary()
    {
        var model = new OrderChangeSummary
        {
            TotalItemCount = 1
        };

        return model;
    }

    private OrderItem GetOrderChangeItem()
    {
        var model = new OrderItem
        {
            DeliveryDate = parent.GetDeliveryDate(),
            LineItemId = "1",
            OrderUnit = BMEcatSharp.PackageUnit.C62,
            PartialShipmentAllowed = false,
            PriceLineAmount = 10,
            Quantity = 2,
            ProductPriceFix = parent.GetProductPriceFix()
        };
        model.Remarks.AddRange(parent.GetRemarks());
        model.SpecialTreatmentClasses.Add(parent.BMEcats.GetSpecialTreatmentClass());
        model.Transport = parent.BMEcats.GetTransport();
        model.ProductId = parent.GetProductId();

        return model;
    }

    internal OrderChange GetOrderChangeWithUdx()
    {
        var model = GetOrderChange();

        model.Header.Information.HeaderUdx.Add(new CustomData()
        {
            Names =
            [
                "Name 1",
                "Name 2"
            ]
        });
        model.Header.Information.HeaderUdx.Add(new CustomData2()
        {
            Name = "Name 3"
        });

        model.Items[0].ItemUdx.Add(new CustomData()
        {
            Names =
            [
                "Name 1",
                "Name 2"
            ]
        });
        model.Items[0].ItemUdx.Add(new CustomData2()
        {
            Name = "Name 3"
        });

        return model;
    }

    private OrderChangeHeader GetHeader()
    {
        var header = new OrderChangeHeader
        {
            ControlInformation = parent.GetControlInformation(),

            Information = GetOrderChangeInformation()
        };

        return header;
    }

    private OrderChangeInformation GetOrderChangeInformation()
    {
        var model = new OrderChangeInformation
        {
            Currency = "EUR",
            DeliveryDate = parent.GetDeliveryDate(),
            DocexchangePartiesReference = parent.GetDocexchangePartiesReference()
        };
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
        model.MimeInfo = parent.GetMimeInfo();
        model.MimeRoot = parent.BMEcats.GetMimeRoot();
        model.Date = DateTime.UtcNow;
        model.OrderId = "OrderChangeId";
        model.SequenceId = 1;
        model.OrderPartiesReference = parent.GetOrderPartiesReference();
        model.Parties = parent.GetParties();
        model.Remarks.AddRange(parent.GetRemarks());

        return model;
    }
}
