using OpenTransSharp.Tests.BMEcats;
using OpenTransSharp.Tests.DispatchNotifications;
using OpenTransSharp.Tests.InvoiceLists;
using OpenTransSharp.Tests.Invoices;
using OpenTransSharp.Tests.OrderChanges;
using OpenTransSharp.Tests.OrderResponses;
using OpenTransSharp.Tests.Orders;
using OpenTransSharp.Tests.Quotations;
using OpenTransSharp.Tests.ReceiptAcknowledgements;
using OpenTransSharp.Tests.RemittanceAdvices;
using OpenTransSharp.Tests.Rfqs;
using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests
{
    internal class TestConfig
    {
        public TestConfig()
        {
            Orders = new OrderTestConfig(this);
            Rfqs = new RfqTestConfig(this);
            Quotations = new QuotationTestConfig(this);
            OrderChanges = new OrderChangeTestConfig(this);
            OrderResponses = new OrderResponseTestConfig(this);
            DispatchNotifications = new DispatchNotificationTestConfig(this);
            ReceiptAcknowledgements = new ReceiptAcknowledgementTestConfig(this);
            Invoices = new InvoiceTestConfig(this);
            InvoiceLists = new InvoiceListTestConfig(this);
            RemittanceAdvices = new RemittanceAdviceTestConfig(this);
            BMEcats = new BMEcatTestConfig(this);
        }

        public OrderTestConfig Orders { get; }
        public RfqTestConfig Rfqs { get; }
        public QuotationTestConfig Quotations { get; }
        public OrderChangeTestConfig OrderChanges { get; }
        public OrderResponseTestConfig OrderResponses { get; }
        public DispatchNotificationTestConfig DispatchNotifications { get; }
        public ReceiptAcknowledgementTestConfig ReceiptAcknowledgements { get; }
        public InvoiceTestConfig Invoices { get; }
        public InvoiceListTestConfig InvoiceLists { get; }

        public RemittanceAdviceTestConfig RemittanceAdvices { get; }
        public BMEcatTestConfig BMEcats { get; }

        public string GetCatalogId()
        {
            return "Catalog Spring";
        }

        public OrderReference GetOrderReference()
        {
            return new OrderReference
            {
                OrderId = "OrderId",
                LineItemId = "1"
            };
        }

        public List<Remark> GetRemarks()
        {
            return new List<Remark>
            {
                new Remark("Be careful", RemarkTypeValues.DispatchNotification)
            };
        }

        public ProductId GetProductId()
        {
            return new ProductId
            {
                SupplierPid = new SupplierPid("Supplier ProductId", SupplierPidTypeValues.SupplierSpecific),
                ProductType = ProductType.Physical,
                SupplierIdref = GetSupplierIdRef()
            };
        }

        public DeliveryIdref GetDeliveryRef()
        {
            return new DeliveryIdref("Buyer", PartyTypeValues.PartySpecific);
        }

        public Party GetSupplierParty()
        {
            return new Party
            {
                Roles = new List<PartyRole> { PartyRole.Supplier },
                PartyIds = new List<PartyId>
                {
                    (PartyId)GetSupplierIdRef()
                }
            };
        }

        public Party GetBuyerParty()
        {
            return new Party
            {
                Roles = new List<PartyRole> { PartyRole.Buyer },
                PartyIds = new List<PartyId>
                {
                    (PartyId)GetBuyerIdref()
                }
            };
        }

        public SupplierIdref GetSupplierIdRef()
        {
            return new SupplierIdref("Supplier", PartyTypeValues.SupplierSpecific);
        }

        public BuyerIdref GetBuyerIdref()
        {
            return new BuyerIdref("Buyer", PartyTypeValues.CustomerSpecific);
        }

        public MimeInfo GetMimeInfo()
        {
            var model = new MimeInfo();

            model.Mimes.Add(GetMime());

            return model;
        }

        public static Mime GetMime()
        {
            return new Mime
            {
                MimeAlternativeTexts = new List<MultiLingualString>
                {
                    new MultiLingualString("Bitte Lesen", LanguageCodes.deu),
                    new MultiLingualString("Readme", LanguageCodes.eng)
                },
                MimeDescriptions = new List<MultiLingualString>
                {
                    new MultiLingualString("Eine Text Datei", LanguageCodes.deu),
                    new MultiLingualString("A text file", LanguageCodes.eng)
                },
                MimePurpose = MimePurpose.Others,
                //MimeSource = new MultiLingualString("ftp://server/de/", LanguageCodes.deu),
                MimeType = "text/plain",
                MimeEmbeddeds = new List<MimeEmbedded>
                {
                    new MimeEmbedded
                    {
                        FileName = "Lies mich.txt",
                        Language = LanguageCodes.deu,
                        FileSize = 33,
                        MimeData = MimeData.FromText("Gut gemacht, Sie haben es gelesen")
                    },
                    new MimeEmbedded
                    {
                        FileName = "Readme.txt",
                        Language = LanguageCodes.eng,
                        FileSize = 22,
                        MimeData = MimeData.FromText("Well done, you read it")
                    }
                }
            };
        }

        public DocumentRecipientIdref GetDocumentRecipientIdRef()
        {
            return new DocumentRecipientIdref("Buyer", PartyTypeValues.PartySpecific);
        }

        public DocumentIssuerIdref GetDocumentIssuerIdRef()
        {
            return new DocumentIssuerIdref("Supplier", PartyTypeValues.PartySpecific);
        }

        public DeliveryDate GetDeliveryDate()
        {
            var model = new DeliveryDate();

            model.DeliveryStartDate = DateTime.UtcNow.AddDays(2);
            model.DeliveryEndDate = model.DeliveryStartDate.AddDays(3);
            model.Type = DeliveryDateType.Optional;

            return model;
        }
    }
}