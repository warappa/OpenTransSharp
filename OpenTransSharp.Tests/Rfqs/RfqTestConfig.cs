using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.Rfqs
{
    internal class RfqTestConfig
    {
        private TestConfig parent;

        public RfqTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public Rfq GetRfq()
        {
            var model = new Rfq();

            model.Type = OrderType.Express;

            model.Header = GetHeader();

            model.Items.Add(GetRfqItem());

            model.Summary = GetSummary();

            return model;
        }

        private RfqSummary GetSummary()
        {
            var model = new RfqSummary();

            model.TotalItemCount = 1;

            return model;
        }

        private RfqItem GetRfqItem()
        {
            var model = new RfqItem();
            model.LineItemId = "1";
            model.ProductId = parent.GetProductId();
            model.Quantity = 2;
            model.OrderUnit = "C62";
            model.ProductPriceFix =parent.GetProductPriceFix();
            model.PriceLineAmount = 10;
            model.PartialShipmentAllowed = false;
            model.DeliveryDate = parent.GetDeliveryDate();
            model.Transport = parent.GetTransport();
            model.SpecialTreatmentClasses.Add(parent.GetSpecialTreatmentClass());
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }

        internal Rfq GetRfqWithUdx()
        {
            var model = GetRfq();

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

        private RfqHeader GetHeader()
        {
            var header = new RfqHeader();

            header.ControlInformation = parent.GetControlInformation();

            header.Information = GetRfqInformation();

            return header;
        }

        private RfqInformation GetRfqInformation()
        {
            var model = new RfqInformation();
            model.Id = "RfqId";
            model.Date = DateTime.UtcNow;
            model.DeliveryDate = parent.GetDeliveryDate();
            model.Languages.Add(new Language(LanguageCodes.deu, true));
            model.Languages.Add(new Language(LanguageCodes.eng));
            model.MimeRoot = parent.GetMimeRoot();
            model.Parties.AddRange(parent.GetParties());
            model.OrderPartiesReference = parent.GetOrderPartiesReference();;
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
            model.Currency = "EUR";
            model.MimeInfo = parent.GetMimeInfo();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }
    }
}