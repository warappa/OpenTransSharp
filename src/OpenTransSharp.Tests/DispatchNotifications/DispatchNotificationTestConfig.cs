namespace OpenTransSharp.Tests.DispatchNotifications;

internal class DispatchNotificationTestConfig
{
    private readonly TestConfig parent;

    public DispatchNotificationTestConfig(TestConfig parent)
    {
        this.parent = parent;
    }

    public DispatchNotification GetDispatchNotification()
    {
        var model = new DispatchNotification
        {
            Header = GetHeader()
        };

        model.Items.Add(GetDispatchNotificationItem());

        model.Summary = GetSummary();

        return model;
    }

    private DispatchNotificationSummary GetSummary()
    {
        var model = new DispatchNotificationSummary
        {
            TotalItemCount = 1
        };

        return model;
    }

    private DispatchNotificationItem GetDispatchNotificationItem()
    {
        var model = new DispatchNotificationItem
        {
            LineItemId = "1",
            OrderUnit = BMEcatSharp.PackageUnit.C62,
            Quantity = 2,
            OrderReference = parent.GetOrderReference(),
            ShipmentPartiesReference = new ShipmentPartiesReference
            {
                DeliveryIdRef = parent.GetDeliveryIdRef()
            },
            Remarks = parent.GetRemarks(),

            ProductId = parent.GetProductId()
        };

        return model;
    }

    internal DispatchNotification GetDispatchNotificationWithUdx()
    {
        var model = GetDispatchNotification();

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

    private DispatchNotificationHeader GetHeader()
    {
        var header = new DispatchNotificationHeader
        {
            ControlInformation = GetControlInformation(),

            Information = GetDispatchNotificationInformation()
        };

        return header;
    }

    private DispatchNotificationInformation GetDispatchNotificationInformation()
    {
        var model = new DispatchNotificationInformation
        {
            DeliveryDate = parent.GetDeliveryDate(),
            DocexchangePartiesReference = new DocexchangePartiesReference
            {
                DocumentIssuerIdRef = parent.GetDocumentIssuerIdRef(),
                DocumentRecipientIdRefs = new List<DocumentRecipientIdRef>
                {
                    parent.GetDocumentRecipientIdRef()
                }
            }
        };
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
        model.MimeInfo = parent.GetMimeInfo();
        model.MimeRoot = parent.BMEcats.GetMimeRoot();
        model.Date = DateTime.UtcNow;
        model.Id = "DispatchNotificationId";
        model.Parties = parent.GetParties();
        model.SupplierIdRef = parent.BMEcats.GetSupplierIdRef();
        model.BuyerIdRef = parent.BMEcats.GetBuyerIdRef();
        model.ShipmentPartiesReference = new ShipmentPartiesReference
        {
            DeliveryIdRef = parent.GetDeliveryIdRef()
        };
        model.Remarks = new List<Remark>
        {
            new Remark("Handle with care", global::BMEcatSharp.RemarkTypeValues.Transport),
            new Remark("Ring 4 times", global::BMEcatSharp.RemarkTypeValues.DeliveryNote)
        };

        return model;
    }

    private ControlInformation GetControlInformation()
    {
        var controlInformation = new ControlInformation
        {
            GenerationDate = DateTime.UtcNow,
            GeneratorInfo = "Testing",
            StopAutomaticProcessing = "For unit tests only"
        };

        return controlInformation;
    }
}
