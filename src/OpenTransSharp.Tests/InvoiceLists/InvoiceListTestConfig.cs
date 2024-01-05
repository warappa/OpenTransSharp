﻿namespace OpenTransSharp.Tests.InvoiceLists;

internal class InvoiceListTestConfig
{
    private readonly TestConfig parent;

    public InvoiceListTestConfig(TestConfig parent)
    {
        this.parent = parent;
    }

    public InvoiceList GetInvoiceList()
    {
        var model = new InvoiceList
        {
            Header = GetHeader()
        };

        model.Items.Add(GetInvoiceListItem());

        model.Summary = GetSummary();

        return model;
    }

    internal InvoiceList GetInvoiceListWithUdx()
    {
        var model = GetInvoiceList();

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

    private InvoiceListSummary GetSummary()
    {
        var model = new InvoiceListSummary
        {
            TotalItemCount = 1,
            TotalAmount = 1,
            TotalTax = parent.GetTotalTax()
        };

        return model;
    }

    private InvoiceListItem GetInvoiceListItem()
    {
        var model = new InvoiceListItem
        {
            LineItemId = "1"
        };
        model.InvoiceList.Add(GetILInvoiceListItem());
        model.NetValueGoods = 10;
        model.TotalAmount = 10;
        model.TotalTax = parent.GetTotalTax();
        model.Remarks.Add(parent.GetRemark());
        model.AccountingPeriod = parent.GetAccountingPeriod();
        model.DeliveryIdRef = parent.GetDeliveryIdRef();

        return model;
    }

    private ILInvoiceListItem GetILInvoiceListItem()
    {
        return new ILInvoiceListItem
        {
            InvoiceReference = parent.GetInvoiceReference(),
            NetValueGoods = 1,
            TotalTax = parent.GetTotalTax(),
            TotalAmount = 1
        };
    }

    private InvoiceListHeader GetHeader()
    {
        var header = new InvoiceListHeader
        {
            ControlInformation = parent.GetControlInformation(),

            Information = GetInvoiceListInformation()
        };

        return header;
    }

    private InvoiceListInformation GetInvoiceListInformation()
    {
        var model = new InvoiceListInformation
        {
            Currency = "EUR",
            DocexchangePartiesReference = parent.GetDocexchangePartiesReference(),
            AccountingPeriod = parent.GetAccountingPeriod()
        };
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
        model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
        model.MimeInfo = parent.GetMimeInfo();
        model.MimeRoot = parent.BMEcats.GetMimeRoot();
        model.Date = DateTime.UtcNow;
        model.Id = "InvoiceListId";
        model.Parties = parent.GetParties();
        model.InvoiceRecipientIdRef = GetInvoiceRecipientIdRef();
        model.InvoiceIssuerIdRef = GetInvoiceIssuerIdRef();
        model.Remarks.AddRange(parent.GetRemarks());

        return model;
    }

    private InvoiceIssuerIdRef GetInvoiceIssuerIdRef()
    {
        return new InvoiceIssuerIdRef("invoice issure", PartyTypeValues.PartySpecific);
    }

    private InvoiceRecipientIdRef GetInvoiceRecipientIdRef()
    {
        return new InvoiceRecipientIdRef("invoice recipient", PartyTypeValues.PartySpecific);
    }
}
