using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.Invoices
{
    internal class InvoiceTestConfig
    {
        private readonly TestConfig parent;

        public InvoiceTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public Invoice GetInvoice()
        {
            var model = new Invoice();

            model.Header = GetHeader();

            model.Items.Add(GetInvoiceItem());

            model.Summary = GetSummary();

            return model;
        }

        private InvoiceSummary GetSummary()
        {
            var model = new InvoiceSummary();

            model.TotalItemCount = 1;
            model.NetValueGoods = 1;
            model.TotalAmount = 1;
            model.TotalTax = parent.GetTotalTax();

            return model;
        }

        private InvoiceItem GetInvoiceItem()
        {
            var model = new InvoiceItem();

            model.LineItemId = "1";
            model.OrderUnit = BMEcatSharp.PackageUnit.C62;
            model.PriceLineAmount = 10;
            model.Quantity = 2;
            model.ProductPriceFix = parent.GetProductPriceFix();
            model.Remarks = parent.GetRemarks();
            model.ProductId = parent.GetProductId();

            return model;
        }

        internal Invoice GetInvoiceWithUdx()
        {
            var model = GetInvoice();

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

        private InvoiceHeader GetHeader()
        {
            var header = new InvoiceHeader();

            header.ControlInformation = parent.GetControlInformation();

            header.Information = GetInvoiceInformation();

            header.OrderHistory = GetOrderHistory();

            return header;
        }

        private OrderHistory GetOrderHistory()
        {
            return new OrderHistory
            {
                OrderId = "OrderId"
            };
        }

        private InvoiceInformation GetInvoiceInformation()
        {
            var model = new InvoiceInformation();

            model.Currency = "EUR";
            model.DeliveryDate = parent.GetDeliveryDate();
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
            model.MimeInfo = parent.GetMimeInfo();
            model.MimeRoot = parent.BMEcats.GetMimeRoot();
            model.Date = DateTime.UtcNow;
            model.Id = "InvoiceId";
            model.IssuerIdRef = parent.GetInvoiceIssuerIdRef();
            model.RecipientIdRef = parent.GetInvoiceRecipientIdRef();
            model.Parties = parent.GetParties();
            model.Remarks.Add(parent.GetRemark());

            return model;
        }
    }
}
