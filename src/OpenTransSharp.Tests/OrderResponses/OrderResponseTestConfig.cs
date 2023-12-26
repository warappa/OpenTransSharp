﻿using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.OrderResponses
{
    internal class OrderResponseTestConfig
    {
        private readonly TestConfig parent;

        public OrderResponseTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public OrderResponse GetOrderResponse()
        {
            var model = new OrderResponse
            {
                Header = GetHeader()
            };

            model.Items.Add(GetOrderResponseItem());

            model.Summary = GetSummary();

            return model;
        }

        private OrderResponseSummary GetSummary()
        {
            var model = new OrderResponseSummary
            {
                TotalItemCount = 1
            };

            return model;
        }

        private OrderResponseItem GetOrderResponseItem()
        {
            var model = new OrderResponseItem
            {
                LineItemId = "1",
                ProductId = parent.GetProductId(),
                Quantity = 2,
                OrderUnit = BMEcatSharp.PackageUnit.C62,
                ProductPriceFix = parent.GetProductPriceFix(),
                PriceLineAmount = 10,
                DeliveryDate = parent.GetDeliveryDate()
            };
            model.SpecialTreatmentClasses.Add(parent.BMEcats.GetSpecialTreatmentClass());
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }

        internal OrderResponse GetOrderResponseWithUdx()
        {
            var model = GetOrderResponse();

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

        private OrderResponseHeader GetHeader()
        {
            var header = new OrderResponseHeader
            {
                ControlInformation = parent.GetControlInformation(),

                Information = GetOrderResponseInformation()
            };

            return header;
        }

        private OrderResponseInformation GetOrderResponseInformation()
        {
            var model = new OrderResponseInformation
            {
                OrderId = "OrderResponseId",
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
    }
}
