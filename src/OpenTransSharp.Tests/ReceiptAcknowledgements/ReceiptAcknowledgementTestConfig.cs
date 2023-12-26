using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.ReceiptAcknowledgements;

internal class ReceiptAcknowledgementTestConfig
{
    private readonly TestConfig parent;

    public ReceiptAcknowledgementTestConfig(TestConfig parent)
    {
        this.parent = parent;
    }

    public ReceiptAcknowledgement GetReceiptAcknowledgement()
    {
        var model = new ReceiptAcknowledgement
        {
            Header = GetHeader()
        };

        model.Items.Add(GetReceiptAcknowledgementItem());

        model.Summary = GetSummary();

        return model;
    }

    private ReceiptAcknowledgementSummary GetSummary()
    {
        var model = new ReceiptAcknowledgementSummary
        {
            TotalItemCount = 1
        };

        return model;
    }

    private ReceiptAcknowledgementItem GetReceiptAcknowledgementItem()
    {
        var model = new ReceiptAcknowledgementItem
        {
            LineItemId = "1",
            ProductId = parent.GetProductId(),
            Quantity = 2,
            OrderUnit = BMEcatSharp.PackageUnit.C62,
            OrderReference = parent.GetOrderReference(),
            DeliveryReference = parent.GetDeliveryReference()
        };
        model.Remarks.AddRange(parent.GetRemarks());

        return model;
    }

    internal ReceiptAcknowledgement GetReceiptAcknowledgementWithUdx()
    {
        var model = GetReceiptAcknowledgement();

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

    private ReceiptAcknowledgementHeader GetHeader()
    {
        var header = new ReceiptAcknowledgementHeader
        {
            ControlInformation = parent.GetControlInformation(),

            Information = GetReceiptAcknowledgementInformation()
        };

        return header;
    }

    private ReceiptAcknowledgementInformation GetReceiptAcknowledgementInformation()
    {
        var model = new ReceiptAcknowledgementInformation
        {
            Id = "ReceiptAcknowledgementId",
            Date = DateTime.UtcNow,
            ReceiptDate = DateTime.UtcNow
        };
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
        model.MimeRoot = parent.BMEcats.GetMimeRoot();
        model.Parties.AddRange(parent.GetParties());
        model.SupplierIdRef = parent.BMEcats.GetSupplierIdRef();
        model.BuyerIdRef = parent.BMEcats.GetBuyerIdRef();
        model.ShipmentPartiesReference = parent.GetShipmentPartiesReference();
        model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
        model.MimeInfo = parent.GetMimeInfo();
        model.Remarks.AddRange(parent.GetRemarks());

        return model;
    }
}
