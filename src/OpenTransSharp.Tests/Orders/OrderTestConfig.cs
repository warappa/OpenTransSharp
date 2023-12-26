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
            var model = new Order
            {
                Type = OrderType.Express,

                Header = GetHeader()
            };

            model.Items.Add(GetOrderItem());

            model.Summary = GetSummary();

            return model;
        }

        private OrderSummary GetSummary()
        {
            var model = new OrderSummary
            {
                TotalAmount = 10,
                TotalItemCount = 1
            };

            return model;
        }

        private OrderItem GetOrderItem()
        {
            var model = new OrderItem
            {
                LineItemId = "1",
                ProductId = parent.GetProductId(),
                Quantity = 2,
                OrderUnit = BMEcatSharp.PackageUnit.C62,
                ProductPriceFix = parent.GetProductPriceFix(),
                PriceLineAmount = 10,
                PartialShipmentAllowed = false,
                DeliveryDate = parent.GetDeliveryDate(),
                Transport = parent.BMEcats.GetTransport()
            };
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
            var header = new OrderHeader
            {
                ControlInformation = parent.GetControlInformation(),

                SourcingInformation = parent.GetSourcingInformation(),

                Information = GetOrderInformation()
            };

            return header;
        }

        private OrderInformation GetOrderInformation()
        {
            var model = new OrderInformation
            {
                Id = "OrderId",
                Date = DateTime.UtcNow,
                DeliveryDate = parent.GetDeliveryDate()
            };
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
