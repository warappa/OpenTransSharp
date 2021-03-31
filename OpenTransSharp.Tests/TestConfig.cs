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
    internal class TestConfig : BMEcatSharp.Tests.TestConfig
    {
        public TestConfig()
            : base()
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
        }

        public DeliveryReference GetDeliveryReference()
        {
            return new DeliveryReference
            {
                Idref = GetDeliveryIdRef()
            };
        }

        public ProductPriceFix GetProductPriceFix()
        {
            var model = new ProductPriceFix
            {
                Amount = 20,
                Quantity = 4,
                BaseFix = GetPriceBaseFix(),
                AllowOrChargesFix = GetAllowOrChargesFix()
            };

            model.PriceFlags.AddRange(new[]
            {
                BMEcats.GetPriceFlag(global::BMEcatSharp.PriceFlagTypes.IncludingPacking, true),
                BMEcats.GetPriceFlag(global::BMEcatSharp.PriceFlagTypes.IncludingAssurance, false)
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
                Id = "InvoiceId"
            };
        }

        public DeliveryIdref GetDeliveryIdRef()
        {
            return new DeliveryIdref("Delivery", global::BMEcatSharp.PartyTypeValues.PartySpecific);
        }

        public AccountingPeriod GetAccountingPeriod()
        {
            return new AccountingPeriod
            {
                StartDate = DateTime.UtcNow.AddDays(2),
                EndDate = DateTime.UtcNow.AddDays(4),
            };
        }

        public RemitteeIdref GetRemitteeIdRef()
        {
            return new RemitteeIdref("Supplier", global::BMEcatSharp.PartyTypeValues.PartySpecific);
        }

        public PayerIdref GetPayerIdRef()
        {
            return new PayerIdref("Buyer", global::BMEcatSharp.PartyTypeValues.PartySpecific);
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
                BuyerIdref = BMEcats.GetBuyerIdref(),
                SupplierIdref = BMEcats.GetSupplierIdRef()
            };
        }

        public DispatchNotificationTestConfig DispatchNotifications { get; }
        public ReceiptAcknowledgementTestConfig ReceiptAcknowledgements { get; }

        public PriceBaseFix GetPriceBaseFix()
        {
            var model = new PriceBaseFix
            {
                Unit = "C62",
                UnitFactor = 1,
                UnitValue = 1
            };

            return model;
        }

        public InvoiceTestConfig Invoices { get; }
        public InvoiceListTestConfig InvoiceLists { get; }

        public RemittanceAdviceTestConfig RemittanceAdvices { get; }
        
        public TaxDetailsFix GetTaxDetailsFix()
        {
            var model = new TaxDetailsFix();
            model.Type = "vat";
            model.CalculationSequence = 1;
            model.Jurisdiction.Add(new global::BMEcatSharp.MultiLingualString("Austria", global::BMEcatSharp.LanguageCodes.eng));
            model.Jurisdiction.Add(new global::BMEcatSharp.MultiLingualString("Österreich", global::BMEcatSharp.LanguageCodes.deu));
            model.Tax = 0.20m;
            model.Amount = 2;
            model.Category = BMEcatSharp.TaxCategoryValues.StandardRate;

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
            model.Names.AddRange(new[]
            {
                new global::BMEcatSharp.MultiLingualString("Kugelschreiber", global::BMEcatSharp.LanguageCodes.deu),
                new global::BMEcatSharp.MultiLingualString("pen", global::BMEcatSharp.LanguageCodes.eng)
            });
            model.SpecificType = AllowOrChargeTypeValues.ProjectBonus;
            model.Value = AllowOrChargeValue.Units(GetAocOrderUnitsCount());

            return model;
        }

        public AllowOrChargesFix GetAllowOrChargesFix()
        {
            var model = new AllowOrChargesFix();
            model.List.Add(GetAllowOrCharge());

            return model;
        }

        public List<OpenTransParty> GetParties()
        {
            return new List<OpenTransParty>
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

        public CatalogReference GetCatalogReference()
        {
            var model = new CatalogReference
            {
                Id = "2021-02",
                Version = new Version(2, 1)
            };
            model.Name = new global::BMEcatSharp.MultiLingualString("Test Catalog 2021", global::BMEcatSharp.LanguageCodes.eng);

            return model;
        }

        public OrderReference GetOrderReference()
        {
            return new OrderReference
            {
                Id = "OrderId",
                LineItemId = "1"
            };
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
            return new Remark("Be careful", global::BMEcatSharp.RemarkTypeValues.DispatchNotification);
        }

        public ProductId GetProductId()
        {
            return new ProductId
            {
                SupplierPid = BMEcats.GetSupplierPid("Supplier ProductId", global::BMEcatSharp.SupplierPidTypeValues.SupplierSpecific),
                ProductType = global::BMEcatSharp.ProductType.Physical,
                SupplierIdref = BMEcats.GetSupplierIdRef()
            };
        }

        public DeliveryIdref GetDeliveryIdref()
        {
            return new DeliveryIdref("Buyer", global::BMEcatSharp.PartyTypeValues.PartySpecific);
        }

        public OpenTransParty GetSupplierParty()
        {
            return new OpenTransParty
            {
                Roles = new List<global::BMEcatSharp.PartyRole> { global::BMEcatSharp.PartyRole.Supplier },
                Ids = new List<global::BMEcatSharp.PartyId>
                {
                    (global::BMEcatSharp.PartyId)BMEcats.GetSupplierIdRef()
                }
            };
        }

        public OpenTransParty GetBuyerParty()
        {
            var model = new OpenTransParty
            {
                Ids = new List<global::BMEcatSharp.PartyId>
                {
                    (global::BMEcatSharp.PartyId)BMEcats.GetBuyerIdref()
                },
                Roles = new List<global::BMEcatSharp.PartyRole> { global::BMEcatSharp.PartyRole.Buyer }
            };
            
            model.Addresses.Add(GetAddress());
            model.Addresses.Add(GetAddress());
            model.Accounts.Add(GetAccount());
            model.Accounts.Add(GetAccount());
            model.MimeInfo = GetMimeInfo();

            return model;
        }

        private Account GetAccount()
        {
            var model = new Account();
            model.Holder = "Holder";
            model.BankAccount = GetBankAccount();
            model.BankCode = GetBankCode();
            model.BankName = "Reiffeisen";
            model.BankCountry = global::BMEcatSharp.CountryCode.AT;

            return model;
        }

        private BankCode GetBankCode()
        {
            return new BankCode("RZOOAT2L", BankCodeTypeValues.Bic);
        }

        private BankAccount GetBankAccount()
        {
            return new BankAccount("Bank account", BankAccountTypeValues.Iban);
        }

        private Address GetAddress()
        {
            var model = new Address();
            model.Name.Add(new global::BMEcatSharp.MultiLingualString("Steve", global::BMEcatSharp.LanguageCodes.eng));
            model.Name.Add(new global::BMEcatSharp.MultiLingualString("Stefan", global::BMEcatSharp.LanguageCodes.deu));
            model.Name2.Add(new global::BMEcatSharp.MultiLingualString("Steve", global::BMEcatSharp.LanguageCodes.eng));
            model.Name2.Add(new global::BMEcatSharp.MultiLingualString("Stefan", global::BMEcatSharp.LanguageCodes.deu));
            model.Name3.Add(new global::BMEcatSharp.MultiLingualString("Steve", global::BMEcatSharp.LanguageCodes.eng));
            model.Name3.Add(new global::BMEcatSharp.MultiLingualString("Stefan", global::BMEcatSharp.LanguageCodes.deu));
            model.Department.Add(new global::BMEcatSharp.MultiLingualString("Department", global::BMEcatSharp.LanguageCodes.eng));
            model.Department.Add(new global::BMEcatSharp.MultiLingualString("Abteilung", global::BMEcatSharp.LanguageCodes.deu));
            model.ContactDetails.Add(GetContactDetails());
            model.Street.Add(new global::BMEcatSharp.MultiLingualString("Street", global::BMEcatSharp.LanguageCodes.eng));
            model.Street.Add(new global::BMEcatSharp.MultiLingualString("Straße", global::BMEcatSharp.LanguageCodes.deu));
            model.Zip.Add(new global::BMEcatSharp.MultiLingualString("Zip", global::BMEcatSharp.LanguageCodes.eng));
            model.Zip.Add(new global::BMEcatSharp.MultiLingualString("PLZ", global::BMEcatSharp.LanguageCodes.deu));
            model.BoxNo.Add(new global::BMEcatSharp.MultiLingualString("1", global::BMEcatSharp.LanguageCodes.eng));
            model.BoxNo.Add(new global::BMEcatSharp.MultiLingualString("1", global::BMEcatSharp.LanguageCodes.deu));
            model.ZipBox.Add(new global::BMEcatSharp.MultiLingualString("1", global::BMEcatSharp.LanguageCodes.eng));
            model.ZipBox.Add(new global::BMEcatSharp.MultiLingualString("1", global::BMEcatSharp.LanguageCodes.deu));
            model.City.Add(new global::BMEcatSharp.MultiLingualString("Vienna", global::BMEcatSharp.LanguageCodes.eng));
            model.City.Add(new global::BMEcatSharp.MultiLingualString("Wien", global::BMEcatSharp.LanguageCodes.deu));
            model.State.Add(new global::BMEcatSharp.MultiLingualString("Upper Austria", global::BMEcatSharp.LanguageCodes.eng));
            model.State.Add(new global::BMEcatSharp.MultiLingualString("Oberösterreich", global::BMEcatSharp.LanguageCodes.deu));
            model.Country.Add(new global::BMEcatSharp.MultiLingualString("Austria", global::BMEcatSharp.LanguageCodes.eng));
            model.Country.Add(new global::BMEcatSharp.MultiLingualString("Österreich", global::BMEcatSharp.LanguageCodes.deu));
            model.CountryCoded = global::BMEcatSharp.CountryCode.AT;
            model.VatId = "UID1234";
            model.TaxNumber = "ST1234";
            model.Phones.Add(BMEcats.GetPhone());
            model.Phones.Add(BMEcats.GetPhone(global::BMEcatSharp.PhoneTypeValues.Office));
            model.Faxes.Add(BMEcats.GetFax());
            model.Faxes.Add(BMEcats.GetFax(global::BMEcatSharp.FaxTypeValues.Private));
            model.Email = "mail@example.com";
            model.PublicKeys.Add(BMEcats.GetPublicKey());
            model.Url = "https://example.com";
            model.Remarks.Add(new global::BMEcatSharp.MultiLingualString("Remark"));
            model.Remarks.Add(new global::BMEcatSharp.MultiLingualString("Bemerkung", global::BMEcatSharp.LanguageCodes.deu));

            return model;
        }

        private OpenTransContactDetails GetContactDetails()
        {
            var model = new OpenTransContactDetails();
            model.Id = "Contact id";
            model.Surname.Add(new global::BMEcatSharp.MultiLingualString("Surname"));
            model.Surname.Add(new global::BMEcatSharp.MultiLingualString("Nachname", global::BMEcatSharp.LanguageCodes.deu));
            model.FirstName.Add(new global::BMEcatSharp.MultiLingualString("Steve", global::BMEcatSharp.LanguageCodes.eng));
            model.Title.Add(new global::BMEcatSharp.MultiLingualString("Eng.", global::BMEcatSharp.LanguageCodes.eng));
            model.Title.Add(new global::BMEcatSharp.MultiLingualString("Ing.", global::BMEcatSharp.LanguageCodes.deu));
            model.AcademicTitle.Add(new global::BMEcatSharp.MultiLingualString("Dr.", global::BMEcatSharp.LanguageCodes.eng));
            model.AcademicTitle.Add(new global::BMEcatSharp.MultiLingualString("Dr.", global::BMEcatSharp.LanguageCodes.deu));
            model.ContactRoles.Add(BMEcats.GetContactRole());
            model.Phones.Add(BMEcats.GetPhone());
            model.Phones.Add(BMEcats.GetPhone(global::BMEcatSharp.PhoneTypeValues.Private));
            model.Faxes.Add(BMEcats.GetFax());
            model.Faxes.Add(BMEcats.GetFax(global::BMEcatSharp.FaxTypeValues.Private));
            model.Url = "https://example.com";
            model.Email = BMEcats.GetEmail();
            model.Authentification = BMEcats.GetAuthentification();

            return model;
        }

        public InvoiceRecipientIdref GetInvoiceRecipientIdRef()
        {
            return new InvoiceRecipientIdref("Buyer", global::BMEcatSharp.PartyTypeValues.PartySpecific);
        }

        public InvoiceIssuerIdref GetInvoiceIssuerIdRef()
        {
            return new InvoiceIssuerIdref("Supplier", global::BMEcatSharp.PartyTypeValues.PartySpecific);
        }

        public OpenTransMimeInfo GetMimeInfo()
        {
            var model = new OpenTransMimeInfo();

            model.Mimes.Add(GetMime());

            return model;
        }

        public static OpenTransMime GetMime()
        {
            return new OpenTransMime
            {
                AlternativeTexts = new List<global::BMEcatSharp.MultiLingualString>
                {
                    new global::BMEcatSharp.MultiLingualString("Bitte Lesen", global::BMEcatSharp.LanguageCodes.deu),
                    new global::BMEcatSharp.MultiLingualString("Readme", global::BMEcatSharp.LanguageCodes.eng)
                },
                Descriptions = new List<global::BMEcatSharp.MultiLingualString>
                {
                    new global::BMEcatSharp.MultiLingualString("Eine Text Datei", global::BMEcatSharp.LanguageCodes.deu),
                    new global::BMEcatSharp.MultiLingualString("A text file", global::BMEcatSharp.LanguageCodes.eng)
                },
                Purpose = global::BMEcatSharp.MimePurpose.Others,
                //MimeSource = new global::BMEcatSharp.MultiLingualString("ftp://server/de/", global::BMEcatSharp.LanguageCodes.deu),
                MimeType = "text/plain",
                Embeddeds = new List<MimeEmbedded>
                {
                    new MimeEmbedded
                    {
                        FileName = "Lies mich.txt",
                        Language = global::BMEcatSharp.LanguageCodes.deu,
                        FileSize = 33,
                        Data = MimeData.FromText("Gut gemacht, Sie haben es gelesen")
                    },
                    new MimeEmbedded
                    {
                        FileName = "Readme.txt",
                        Language = global::BMEcatSharp.LanguageCodes.eng,
                        FileSize = 22,
                        Data = MimeData.FromText("Well done, you read it")
                    }
                }
            };
        }

        public DocumentRecipientIdref GetDocumentRecipientIdRef()
        {
            return new DocumentRecipientIdref("Buyer", global::BMEcatSharp.PartyTypeValues.PartySpecific);
        }

        public DocumentIssuerIdref GetDocumentIssuerIdRef()
        {
            return new DocumentIssuerIdref("Supplier", global::BMEcatSharp.PartyTypeValues.PartySpecific);
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