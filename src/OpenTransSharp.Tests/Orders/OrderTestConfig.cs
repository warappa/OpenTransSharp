using BMEcatSharp;
using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.Orders
{
    internal class OrderTestConfig
    {
        private readonly TestConfig parent;

        public OrderTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public Order GetOrder()
        {
            var model = new Order();

            model.Type = OrderType.Express;

            model.Header = GetHeader();

            model.Items.Add(GetOrderItem());

            model.Summary = GetSummary();

            return model;
        }

        private OrderSummary GetSummary()
        {
            var model = new OrderSummary();

            model.TotalAmount = 10;
            model.TotalItemCount = 1;

            return model;
        }

        private OrderItem GetOrderItem()
        {
            var model = new OrderItem();
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

        internal Order GetOrderWithUdx()
        {
            var order = GetOrder();

            order.Header.Information.HeaderUdx.Add(new CustomData()
            {
                Names = new List<string>
                {
                    "Name 1",
                    "Name 2"
                }
            });
            order.Header.Information.HeaderUdx.Add(new CustomData2()
            {
                Name = "Name 3"
            });

            order.Items[0].ItemUdx.Add(new CustomData()
            {
                Names = new List<string>
                {
                    "Name 1",
                    "Name 2"
                }
            });
            order.Items[0].ItemUdx.Add(new CustomData2()
            {
                Name = "Name 3"
            });

            return order;
        }

        private OrderHeader GetHeader()
        {
            var header = new OrderHeader();

            header.ControlInformation = parent.GetControlInformation();

            header.SourcingInformation = parent.GetSourcingInformation();

            header.Information = GetOrderInformation();

            return header;
        }

        private OrderInformation GetOrderInformation()
        {
            var model = new OrderInformation();

            model.Id = "OrderId";
            model.Date = DateTime.UtcNow;
            model.DeliveryDate = parent.GetDeliveryDate();
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
            model.MimeRoot = parent.BMEcats.GetMimeRoot();
            model.Parties.AddRange(parent.GetParties());
            model.OrderPartiesReference = parent.GetOrderPartiesReference();
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
            model.Currency = "EUR";
            model.MimeInfo = parent.GetMimeInfo();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }

        internal Order GetMinimalValidOrder()
        {
            var model = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem("1", new ProductId(), PackageUnit.C62)
                }
            };
            model.Header.Information.Id = "test";
            model.Header.Information.Parties.Add(new OpenTransParty { Ids = new List<PartyId> { new PartyId("a") } });
            model.Header.Information.OrderPartiesReference.BuyerIdRef = new BuyerIdRef("a");
            model.Header.Information.OrderPartiesReference.SupplierIdRef = new SupplierIdRef("a");

            return model;
        }
    }
}
