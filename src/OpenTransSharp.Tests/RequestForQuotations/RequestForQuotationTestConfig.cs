using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.RequestForQuotations
{
    internal class RequestForQuotationTestConfig
    {
        private readonly TestConfig parent;

        public RequestForQuotationTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public RequestForQuotation GetRequestForQuotation()
        {
            var model = new RequestForQuotation();

            model.Type = OrderType.Express;

            model.Header = GetHeader();

            model.Items.Add(GetRequestForQuotationItem());

            model.Summary = GetSummary();

            return model;
        }

        private RequestForQuotationSummary GetSummary()
        {
            var model = new RequestForQuotationSummary();

            model.TotalItemCount = 1;

            return model;
        }

        private RequestForQuotationItem GetRequestForQuotationItem()
        {
            var model = new RequestForQuotationItem();
            model.LineItemId = "1";
            model.ProductId = parent.GetProductId();
            model.Quantity = 2;
            model.OrderUnit = BMEcatSharp.PackageUnit.C62;
            model.ProductPriceFix = parent.GetProductPriceFix();
            model.PriceLineAmount = 10;
            model.PartialShipmentAllowed = false;
            model.DeliveryDate = parent.GetDeliveryDate();
            model.Transport = parent.BMEcats.GetTransport();
            model.SpecialTreatmentClasses.Add(parent.BMEcats.GetSpecialTreatmentClass());
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }

        internal RequestForQuotation GetRequestForQuotationWithUdx()
        {
            var model = GetRequestForQuotation();

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

        private RequestForQuotationHeader GetHeader()
        {
            var header = new RequestForQuotationHeader();

            header.ControlInformation = parent.GetControlInformation();

            header.Information = GetRequestForQuotationInformation();

            return header;
        }

        private RequestForQuotationInformation GetRequestForQuotationInformation()
        {
            var model = new RequestForQuotationInformation();
            model.Id = "RequestForQuotationId";
            model.Date = DateTime.UtcNow;
            model.DeliveryDate = parent.GetDeliveryDate();
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
            model.MimeRoot = parent.BMEcats.GetMimeRoot();
            model.Parties.AddRange(parent.GetParties());
            model.OrderPartiesReference = parent.GetOrderPartiesReference(); ;
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
            model.Currency = "EUR";
            model.MimeInfo = parent.GetMimeInfo();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }
    }
}
