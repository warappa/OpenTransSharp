using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.Orders
{
    internal class OrderTestConfig
    {
        private TestConfig parent;

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
            model.Languages.Add(new Language(LanguageCodes.deu, true));
            model.Languages.Add(new Language(LanguageCodes.eng));
            model.MimeRoot = parent.GetMimeRoot();
            model.Parties.AddRange(parent.GetParties());
            model.OrderPartiesReference = parent.GetOrderPartiesReference();
            model.DocexchangePartiesReference =parent.GetDocexchangePartiesReference();
            model.Currency = "EUR";
            model.MimeInfo = parent.GetMimeInfo();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }
    }
}