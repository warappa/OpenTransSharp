using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.DispatchNotifications
{
    internal class DispatchNotificationTestConfig
    {
        private TestConfig parent;

        public DispatchNotificationTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public DispatchNotification GetDispatchNotification()
        {
            var model = new DispatchNotification();

            model.Header = GetHeader();

            model.Items.Add(GetDispatchNotificationItem());

            model.Summary = GetSummary();

            return model;
        }

        private DispatchNotificationSummary GetSummary()
        {
            var model = new DispatchNotificationSummary();

            model.TotalItemCount = 1;

            return model;
        }

        private DispatchNotificationItem GetDispatchNotificationItem()
        {
            var model = new DispatchNotificationItem();

            model.LineItemId = "1";
            model.OrderUnit = "C62";
            model.Quantity = 2;
            model.OrderReference = parent.GetOrderReference();
            model.ShipmentPartiesReference = new ShipmentPartiesReference
            {
                DeliveryIdref = parent.GetDeliveryIdref()
            };
            model.Remarks = parent.GetRemarks();

            model.ProductId = parent.GetProductId();

            return model;
        }

        internal DispatchNotification GetDispatchNotificationWithUdx()
        {
            var model = GetDispatchNotification();

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

        private DispatchNotificationHeader GetHeader()
        {
            var header = new DispatchNotificationHeader();

            header.ControlInformation = GetControlInformation();

            header.Information = GetDispatchNotificationInformation();

            return header;
        }

        private DispatchNotificationInformation GetDispatchNotificationInformation()
        {
            var model = new DispatchNotificationInformation();

            model.DeliveryDate = parent.GetDeliveryDate();
            model.DocexchangePartiesReference = new DocexchangePartiesReference
            {
                DocumentIssuerIdref = parent.GetDocumentIssuerIdRef(),
                DocumentRecipientIdrefs = new List<DocumentRecipientIdref>{
                    parent.GetDocumentRecipientIdRef()
                }
            };
            model.Languages.Add(new Language(LanguageCodes.deu, true));
            model.Languages.Add(new Language(LanguageCodes.eng));
            model.MimeInfo = parent.GetMimeInfo();
            model.MimeRoot = parent.GetMimeRoot();
            model.Date = DateTime.UtcNow;
            model.Id = "DispatchNotificationId";
            model.Parties = new List<Party>
            {
                parent.GetBuyerParty(),
                parent.GetSupplierParty()
            };
            model.SupplierIdref = parent.GetSupplierIdRef();
            model.BuyerIdref = parent.GetBuyerIdref();
            model.ShipmentPartiesReference = new ShipmentPartiesReference
            {
                DeliveryIdref = parent.GetDeliveryIdref()
            };
            model.Remarks = new List<Remark>
            {
                new Remark("Handle with care", RemarkTypeValues.Transport),
                new Remark("Ring 4 times", RemarkTypeValues.DeliveryNote)
            };

            return model;
        }

        private ControlInformation GetControlInformation()
        {
            var controlInformation = new ControlInformation();
            controlInformation.GenerationDate = DateTime.UtcNow;
            controlInformation.GeneratorInfo = "Testing";
            controlInformation.StopAutomaticProcessing = "For unit tests only";

            return controlInformation;
        }
    }
}