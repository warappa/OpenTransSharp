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

        public DeliveryReference GetDeliveryReference()
        {
            return new DeliveryReference
            {
                DeliveryIdref = GetDeliveryIdRef()
            };
        }

        public SpecialTreatmentClass GetSpecialTreatmentClass()
        {
            return new SpecialTreatmentClass("Attention", "GGVS");
        }

        public Transport GetTransport()
        {
            var model = new Transport
            {
                Incoterm = "EXW",
                Location = "Warehouse"
            };
            model.TransportRemarks.AddRange(new[]
            {
                new MultiLingualString("Zerbrechlich", LanguageCodes.deu),
                new MultiLingualString("fragile", LanguageCodes.eng)
            });

            return model;
        }

        public ProductPriceFix GetProductPriceFix()
        {
            var model = new ProductPriceFix
            {
                PriceAmount = 20,
                PriceQuantity = 4,
                PriceBaseFix = GetPriceBaseFix(),
                AllowOrChargesFix = GetAllowOrChargesFix()
            };

            model.PriceFlags.AddRange(new[]
            {
                new PriceFlag(PriceFlagTypes.IncludingPacking, true),
                new PriceFlag(PriceFlagTypes.IncludingAssurance, false)
            });
            model.TaxDetailsFixes.Add(GetTaxDetailsFix());

            return model;
        }

        public OrderTestConfig Orders { get; }
        public RfqTestConfig Rfqs { get; }
        public QuotationTestConfig Quotations { get; }
        public OrderChangeTestConfig OrderChanges { get; }

        public InvoiceReference GetInvoiceReference()
        {
            return new InvoiceReference
            {
                InvoiceId = "InvoiceId"
            };
        }

        public DeliveryIdref GetDeliveryIdRef()
        {
            return new DeliveryIdref("Delivery", PartyTypeValues.PartySpecific);
        }

        public AccountingPeriod GetAccountingPeriod()
        {
            return new AccountingPeriod
            {
                AccountingPeriodStartDate = DateTime.UtcNow.AddDays(2),
                AccountingPeriodEndDate = DateTime.UtcNow.AddDays(4),
            };
        }

        public RemitteeIdref GetRemitteeIdRef()
        {
            return new RemitteeIdref("Supplier", PartyTypeValues.PartySpecific);
        }

        public PayerIdref GetPayerIdRef()
        {
            return new PayerIdref("Buyer", PartyTypeValues.PartySpecific);
        }

        public ShipmentPartiesReference GetShipmentPartiesReference()
        {
            return new ShipmentPartiesReference
            {
                DeliveryIdref = GetDeliveryIdRef()
            };
        }

        public OrderResponseTestConfig OrderResponses { get; }

        public OrderPartiesReference GetOrderPartiesReference()
        {
            return new OrderPartiesReference
            {
                BuyerIdref = GetBuyerIdref(),
                SupplierIdref = GetSupplierIdRef()
            };
        }

        public DispatchNotificationTestConfig DispatchNotifications { get; }
        public ReceiptAcknowledgementTestConfig ReceiptAcknowledgements { get; }

        public PriceBaseFix GetPriceBaseFix()
        {
            var model = new PriceBaseFix
            {
                PriceUnit = "C62",
                PriceUnitFactor = 1,
                PriceUnitValue = 1
            };

            return model;
        }

        public InvoiceTestConfig Invoices { get; }
        public InvoiceListTestConfig InvoiceLists { get; }

        public RemittanceAdviceTestConfig RemittanceAdvices { get; }
        public BMEcatTestConfig BMEcats { get; }

        public TaxDetailsFix GetTaxDetailsFix()
        {
            var model = new TaxDetailsFix();
            model.TaxType = "vat";
            model.CalculationSequence = 1;
            model.Jurisdictions.AddRange(new[]
            {
                new MultiLingualString("Österreich", LanguageCodes.deu),
                new MultiLingualString("Austria", LanguageCodes.eng)
            });
            model.Tax = 0.20m;
            model.TaxAmount = 2;
            model.TaxCategory = TaxCategoryValues.StandardRate;

            return model;
        }

        public DocexchangePartiesReference GetDocexchangePartiesReference()
        {
            var model = new DocexchangePartiesReference
            {
                DocumentIssuerIdref = GetDocumentIssuerIdRef(),

            };
            model.DocumentRecipientIdrefs.Add(GetDocumentRecipientIdRef());

            return model;
        }

        public AllowOrCharge GetAllowOrCharge()
        {
            var model = new AllowOrCharge();
            model.Type = AllowOrChargeType.Allowance;
            model.AllowOrChargeNames.AddRange(new[]
            {
                new MultiLingualString("Kugelschreiber", LanguageCodes.deu),
                new MultiLingualString("pen", LanguageCodes.eng)
            });
            model.AllowOrChargeType = AllowOrChargeTypeValues.ProjectBonus;
            model.AllowOrChargeValue = AllowOrChargeValue.Units(GetAocOrderUnitsCount());

            return model;
        }

        public AllowOrChargesFix GetAllowOrChargesFix()
        {
            var model = new AllowOrChargesFix();
            model.AllowOrChargeList.Add(GetAllowOrCharge());

            return model;
        }

        public List<Party> GetParties()
        {
            return new List<Party>
            {
                GetBuyerParty(),
                GetSupplierParty()
            };
        }

        public TotalTax GetTotalTax()
        {
            var model = new TotalTax();
            model.TaxDetailsFixes.Add(GetTaxDetailsFix());

            return model;
        }

        public AocOrderUnitsCount GetAocOrderUnitsCount()
        {
            return new AocOrderUnitsCount(0, AocOrderUnitsCountType.Exclusive);
        }

        public string GetCatalogId()
        {
            return "Catalog Spring";
        }

        public CatalogReference GetCatalogReference()
        {
            return new CatalogReference
            {
                CatalogId = "2021-02",
                CatalogName = new MultiLingualString("Test Catalog 2021", LanguageCodes.eng),
                CatalogVersion = new Version(2, 1)
            };
        }

        public OrderReference GetOrderReference()
        {
            return new OrderReference
            {
                OrderId = "OrderId",
                LineItemId = "1"
            };
        }

        public SupplierPid GetSupplierPid()
        {
            return new SupplierPid("ProductId", SupplierPidTypeValues.SupplierSpecific);
        }

        public List<Remark> GetRemarks()
        {
            return new List<Remark>
            {
                GetRemark()
            };
        }

        public Remark GetRemark()
        {
            return new Remark("Be careful", RemarkTypeValues.DispatchNotification);
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

        public DeliveryIdref GetDeliveryIdref()
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

        public InvoiceRecipientIdref GetInvoiceRecipientIdRef()
        {
            return new InvoiceRecipientIdref("Buyer", PartyTypeValues.PartySpecific);
        }

        public InvoiceIssuerIdref GetInvoiceIssuerIdRef()
        {
            return new InvoiceIssuerIdref("Supplier", PartyTypeValues.PartySpecific);
        }

        public MimeInfo GetMimeInfo()
        {
            var model = new MimeInfo();

            model.Mimes.Add(GetMime());

            return model;
        }

        public MultiLingualString GetMimeRoot()
        {
            return new MultiLingualString("ftp://server/de", LanguageCodes.deu);
        }

        public BMEcatMimeInfo GetBMEcatMimeInfo()
        {
            var model = new BMEcatMimeInfo();

            model.Mimes.Add(GetBMEcatMime());

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

        public static BMEcatMime GetBMEcatMime()
        {
            return new BMEcatMime
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
                MimeSource = new MultiLingualString("ftp://server/de/", LanguageCodes.deu),
                MimeType = "text/plain"
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

        public SourcingInformation GetSourcingInformation()
        {
            var model = new SourcingInformation();

            model.CatalogReference = GetCatalogReference();

            return model;
        }
        public ControlInformation GetControlInformation()
        {
            var controlInformation = new ControlInformation();
            controlInformation.GenerationDate = DateTime.UtcNow;
            controlInformation.GeneratorInfo = "Testing";
            controlInformation.StopAutomaticProcessing = "For unit tests only";

            return controlInformation;
        }
    }
}