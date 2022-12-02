using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.OrderChanges
{
    internal class OrderChangeTestConfig
    {
        private readonly TestConfig parent;

        public OrderChangeTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public OrderChange GetOrderChange()
        {
            var model = new OrderChange();

            model.Header = GetHeader();

            model.Items.Add(GetOrderChangeItem());

            model.Summary = GetSummary();

            return model;
        }

        private OrderChangeSummary GetSummary()
        {
            var model = new OrderChangeSummary();

            model.TotalItemCount = 1;

            return model;
        }

        private OrderItem GetOrderChangeItem()
        {
            var model = new OrderItem();

            model.DeliveryDate = parent.GetDeliveryDate();
            model.LineItemId = "1";
            model.OrderUnit = BMEcatSharp.PackageUnit.C62;
            model.PartialShipmentAllowed = false;
            model.PriceLineAmount = 10;
            model.Quantity = 2;
            model.ProductPriceFix = parent.GetProductPriceFix();
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

        private OrderChangeHeader GetHeader()
        {
            var header = new OrderChangeHeader();

            header.ControlInformation = parent.GetControlInformation();

            header.Information = GetOrderChangeInformation();

            return header;
        }

        private OrderChangeInformation GetOrderChangeInformation()
        {
            var model = new OrderChangeInformation();

            model.Currency = "EUR";
            model.DeliveryDate = parent.GetDeliveryDate();
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
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
}
