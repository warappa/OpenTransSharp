using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.Quotations
{
    internal class QuotationTestConfig
    {
        private TestConfig parent;

        public QuotationTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public Quotation GetQuotation()
        {
            var model = new Quotation();

            model.Header = GetHeader();

            model.Items.Add(GetQuotationItem());

            model.Summary = GetSummary();

            return model;
        }

        private QuotationSummary GetSummary()
        {
            var model = new QuotationSummary();

            model.TotalItemCount = 1;

            return model;
        }

        private QuotationItem GetQuotationItem()
        {
            var model = new QuotationItem();

            model.LineItemId = "1";
            model.ProductId = parent.GetProductId();
            model.Quantity = 2;
            model.OrderUnit = "C62";
            model.ProductPriceFix = parent.GetProductPriceFix();
            model.PriceLineAmount = 10;
            model.PartialShipmentAllowed = false;
            model.DeliveryDate = parent.GetDeliveryDate();
            model.Transport = parent.GetTransport();
            model.SpecialTreatmentClasses.Add(parent.GetSpecialTreatmentClass());
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
            var header = new QuotationHeader();

            header.ControlInformation = parent.GetControlInformation();

            header.Information = GetQuotationInformation();

            return header;
        }

        private QuotationInformation GetQuotationInformation()
        {
            var model = new QuotationInformation();
            model.Id = "QuotationId";
            model.Date = DateTime.UtcNow;
            model.DeliveryDate = parent.GetDeliveryDate();
            model.Languages.Add(new Language(LanguageCodes.deu, true));
            model.Languages.Add(new Language(LanguageCodes.eng));
            model.MimeRoot = parent.GetMimeRoot();
            model.Parties.AddRange(parent.GetParties());
            model.OrderPartiesReference = parent.GetOrderPartiesReference();
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
            model.Currency = "EUR";
            model.MimeInfo = parent.GetMimeInfo();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }
    }
}