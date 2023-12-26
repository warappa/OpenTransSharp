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
            var model = new Invoice
            {
                Header = GetHeader()
            };

            model.Items.Add(GetInvoiceItem());

            model.Summary = GetSummary();

            return model;
        }

        private InvoiceSummary GetSummary()
        {
            var model = new InvoiceSummary
            {
                TotalItemCount = 1,
                NetValueGoods = 1,
                TotalAmount = 1,
                TotalTax = parent.GetTotalTax()
            };

            return model;
        }

        private InvoiceItem GetInvoiceItem()
        {
            var model = new InvoiceItem
            {
                LineItemId = "1",
                OrderUnit = BMEcatSharp.PackageUnit.C62,
                PriceLineAmount = 10,
                Quantity = 2,
                ProductPriceFix = parent.GetProductPriceFix(),
                Remarks = parent.GetRemarks(),
                ProductId = parent.GetProductId()
            };

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
            var header = new InvoiceHeader
            {
                ControlInformation = parent.GetControlInformation(),

                Information = GetInvoiceInformation(),

                OrderHistory = GetOrderHistory()
            };

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
            var model = new InvoiceInformation
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
            model.Id = "InvoiceId";
            model.IssuerIdRef = parent.GetInvoiceIssuerIdRef();
            model.RecipientIdRef = parent.GetInvoiceRecipientIdRef();
            model.Parties = parent.GetParties();
            model.Remarks.Add(parent.GetRemark());

            return model;
        }
    }
}
