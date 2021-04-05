using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.ReceiptAcknowledgements
{
    internal class ReceiptAcknowledgementTestConfig
    {
        private TestConfig parent;

        public ReceiptAcknowledgementTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public ReceiptAcknowledgement GetReceiptAcknowledgement()
        {
            var model = new ReceiptAcknowledgement();

            model.Header = GetHeader();

            model.Items.Add(GetReceiptAcknowledgementItem());

            model.Summary = GetSummary();

            return model;
        }

        private ReceiptAcknowledgementSummary GetSummary()
        {
            var model = new ReceiptAcknowledgementSummary();

            model.TotalItemCount = 1;

            return model;
        }

        private ReceiptAcknowledgementItem GetReceiptAcknowledgementItem()
        {
            var model = new ReceiptAcknowledgementItem();

            model.LineItemId = "1";
            model.ProductId = parent.GetProductId();
            model.Quantity = 2;
            model.OrderUnit = "C62";
            model.OrderReference = parent.GetOrderReference();
            model.DeliveryReference = parent.GetDeliveryReference();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }

        internal ReceiptAcknowledgement GetReceiptAcknowledgementWithUdx()
        {
            var model = GetReceiptAcknowledgement();

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

        private ReceiptAcknowledgementHeader GetHeader()
        {
            var header = new ReceiptAcknowledgementHeader();

            header.ControlInformation = parent.GetControlInformation();

            header.Information = GetReceiptAcknowledgementInformation();

            return header;
        }

        private ReceiptAcknowledgementInformation GetReceiptAcknowledgementInformation()
        {
            var model = new ReceiptAcknowledgementInformation();
            model.Id = "ReceiptAcknowledgementId";
            model.Date = DateTime.UtcNow;
            model.ReceiptDate = DateTime.UtcNow;
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
            model.MimeRoot = parent.BMEcats.GetMimeRoot();
            model.Parties.AddRange(parent.GetParties());
            model.SupplierIdRef = parent.BMEcats.GetSupplierIdRef();
            model.BuyerIdRef = parent.BMEcats.GetBuyerIdRef();
            model.ShipmentPartiesReference = parent.GetShipmentPartiesReference();
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
            model.MimeInfo = parent.GetMimeInfo();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }
    }
}