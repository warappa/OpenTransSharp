using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
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
                Idref = GetDeliveryIdRef()
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
            model.Remarks.AddRange(new[]
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
                Amount = 20,
                Quantity = 4,
                BaseFix = GetPriceBaseFix(),
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
                Id = "InvoiceId"
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
                StartDate = DateTime.UtcNow.AddDays(2),
                EndDate = DateTime.UtcNow.AddDays(4),
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
                Unit = "C62",
                UnitFactor = 1,
                UnitValue = 1
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
            model.Type = "vat";
            model.CalculationSequence = 1;
            model.Jurisdiction.Add(new MultiLingualString("Austria", LanguageCodes.eng));
            model.Jurisdiction.Add(new MultiLingualString("Österreich", LanguageCodes.deu));
            model.Tax = 0.20m;
            model.Amount = 2;
            model.Category = TaxCategoryValues.StandardRate;

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
                new MultiLingualString("Kugelschreiber", LanguageCodes.deu),
                new MultiLingualString("pen", LanguageCodes.eng)
            });
            model.SpecificType = AllowOrChargeTypeValues.ProjectBonus;
            model.Value = AllowOrChargeValue.Units(GetAocOrderUnitsCount());

            return model;
        }

        public Authentification GetAuthentification()
        {
            return new Authentification("login", "password");
        }

        public AllowOrChargesFix GetAllowOrChargesFix()
        {
            var model = new AllowOrChargesFix();
            model.List.Add(GetAllowOrCharge());

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
            var model = new CatalogReference
            {
                Id = "2021-02",
                Version = new Version(2, 1)
            };
            model.Name = new MultiLingualString("Test Catalog 2021", LanguageCodes.eng);

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
                Ids = new List<PartyId>
                {
                    (PartyId)GetSupplierIdRef()
                }
            };
        }

        public Party GetBuyerParty()
        {
            var model = new Party
            {
                Ids = new List<PartyId>
                {
                    (PartyId)GetBuyerIdref()
                },
                Roles = new List<PartyRole> { PartyRole.Buyer }
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
            model.BankCountry = CountryCode.AT;

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
            model.Name.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Stefan", LanguageCodes.deu));
            model.Name2.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Name2.Add(new MultiLingualString("Stefan", LanguageCodes.deu));
            model.Name3.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Name3.Add(new MultiLingualString("Stefan", LanguageCodes.deu));
            model.Department.Add(new MultiLingualString("Department", LanguageCodes.eng));
            model.Department.Add(new MultiLingualString("Abteilung", LanguageCodes.deu));
            model.ContactDetails.Add(GetContactDetails());
            model.Street.Add(new MultiLingualString("Street", LanguageCodes.eng));
            model.Street.Add(new MultiLingualString("Straße", LanguageCodes.deu));
            model.Zip.Add(new MultiLingualString("Zip", LanguageCodes.eng));
            model.Zip.Add(new MultiLingualString("PLZ", LanguageCodes.deu));
            model.BoxNo.Add(new MultiLingualString("1", LanguageCodes.eng));
            model.BoxNo.Add(new MultiLingualString("1", LanguageCodes.deu));
            model.ZipBox.Add(new MultiLingualString("1", LanguageCodes.eng));
            model.ZipBox.Add(new MultiLingualString("1", LanguageCodes.deu));
            model.City.Add(new MultiLingualString("Vienna", LanguageCodes.eng));
            model.City.Add(new MultiLingualString("Wien", LanguageCodes.deu));
            model.State.Add(new MultiLingualString("Upper Austria", LanguageCodes.eng));
            model.State.Add(new MultiLingualString("Oberösterreich", LanguageCodes.deu));
            model.Country.Add(new MultiLingualString("Austria", LanguageCodes.eng));
            model.Country.Add(new MultiLingualString("Österreich", LanguageCodes.deu));
            model.CountryCoded = CountryCode.AT;
            model.VatId = "UID1234";
            model.TaxNumber = "ST1234";
            model.Phones.Add(GetPhone());
            model.Phones.Add(GetPhone(PhoneTypeValues.Office));
            model.Faxes.Add(GetFax());
            model.Faxes.Add(GetFax(FaxTypeValues.Private));
            model.Email = "mail@example.com";
            model.PublicKeys.Add(GetPublicKey());
            model.Url = "https://example.com";
            model.Remarks.Add(new MultiLingualString("Remark"));
            model.Remarks.Add(new MultiLingualString("Bemerkung", LanguageCodes.deu));

            return model;
        }



        private BMEcatAddress GetBMEcatAddress()
        {
            var model = new BMEcatAddress();
            model.Name.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Stefan", LanguageCodes.deu));
            model.Name2.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Name2.Add(new MultiLingualString("Stefan", LanguageCodes.deu));
            model.Name3.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Name3.Add(new MultiLingualString("Stefan", LanguageCodes.deu));
            model.Department.Add(new MultiLingualString("Department", LanguageCodes.eng));
            model.Department.Add(new MultiLingualString("Abteilung", LanguageCodes.deu));
            model.ContactDetails.Add(GetBMEcatContactDetails());
            model.Street.Add(new MultiLingualString("Street", LanguageCodes.eng));
            model.Street.Add(new MultiLingualString("Straße", LanguageCodes.deu));
            model.Zip.Add(new MultiLingualString("Zip", LanguageCodes.eng));
            model.Zip.Add(new MultiLingualString("PLZ", LanguageCodes.deu));
            model.BoxNo.Add(new MultiLingualString("1", LanguageCodes.eng));
            model.BoxNo.Add(new MultiLingualString("1", LanguageCodes.deu));
            model.ZipBox.Add(new MultiLingualString("1", LanguageCodes.eng));
            model.ZipBox.Add(new MultiLingualString("1", LanguageCodes.deu));
            model.City.Add(new MultiLingualString("Vienna", LanguageCodes.eng));
            model.City.Add(new MultiLingualString("Wien", LanguageCodes.deu));
            model.State.Add(new MultiLingualString("Upper Austria", LanguageCodes.eng));
            model.State.Add(new MultiLingualString("Oberösterreich", LanguageCodes.deu));
            model.Country.Add(new MultiLingualString("Austria", LanguageCodes.eng));
            model.Country.Add(new MultiLingualString("Österreich", LanguageCodes.deu));
            model.CountryCoded = CountryCode.AT;
            model.VatId = "UID1234";
            model.Phone = GetPhone();
            model.Fax = GetFax();
            model.Email = "mail@example.com";
            model.PublicKeys.Add(GetPublicKey());
            model.Url = "https://example.com";
            model.Remarks.Add(new MultiLingualString("Remark"));
            model.Remarks.Add(new MultiLingualString("Bemerkung", LanguageCodes.deu));

            return model;
        }

        private PublicKey GetPublicKey(string type = null)
        {
            return new PublicKey("1234", type ?? PublicKeyTypeValues.PGP(new Version(6, 5, 1)));
        }

        private Fax GetFax(string type = "office")
        {
            return new Fax("+43234567890", type);
        }

        private Phone GetPhone(string type = "mobile")
        {
            return new Phone("+43123456789", type);
        }

        private ContactDetails GetContactDetails()
        {
            var model = new ContactDetails();
            model.Id = "Contact id";
            model.Surname.Add(new MultiLingualString("Surname"));
            model.Surname.Add(new MultiLingualString("Nachname", LanguageCodes.deu));
            model.FirstName.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Title.Add(new MultiLingualString("Eng.", LanguageCodes.eng));
            model.Title.Add(new MultiLingualString("Ing.", LanguageCodes.deu));
            model.AcademicTitle.Add(new MultiLingualString("Dr.", LanguageCodes.eng));
            model.AcademicTitle.Add(new MultiLingualString("Dr.", LanguageCodes.deu));
            model.ContactRoles.Add(GetContactRole());
            model.Phones.Add(GetPhone());
            model.Phones.Add(GetPhone(PhoneTypeValues.Private));
            model.Faxes.Add(GetFax());
            model.Faxes.Add(GetFax(FaxTypeValues.Private));
            model.Url = "https://example.com";
            model.Email = GetEmail();
            model.Authentification = GetAuthentification();

            return model;
        }

        private BMEcatContactDetails GetBMEcatContactDetails()
        {
            var model = new BMEcatContactDetails();
            model.Id = "Contact id";
            model.Surname.Add(new MultiLingualString("Surname"));
            model.Surname.Add(new MultiLingualString("Nachname", LanguageCodes.deu));
            model.FirstName.Add(new MultiLingualString("Steve", LanguageCodes.eng));
            model.Title.Add(new MultiLingualString("Eng.", LanguageCodes.eng));
            model.Title.Add(new MultiLingualString("Ing.", LanguageCodes.deu));
            model.AcademicTitle.Add(new MultiLingualString("Dr.", LanguageCodes.eng));
            model.AcademicTitle.Add(new MultiLingualString("Dr.", LanguageCodes.deu));
            model.ContactRoles.Add(GetContactRole());
            model.Phone = GetPhone();
            model.Fax = GetFax();
            model.Url = "https://example.com";
            model.Email = GetEmail();
            
            return model;
        }

        private Email GetEmail()
        {
            var model = new Email();
            model.EmailAddress = "mail@example.com";
            model.PublicKeys.Add(GetPublicKey());
            model.PublicKeys.Add(GetPublicKey("etc"));

            return model;
        }

        private ContactRole GetContactRole()
        {
            return new ContactRole("Contact", ContactRoleType.Technical);
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
            return new MultiLingualString("ftp://server/en", LanguageCodes.eng);
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
                AlternativeTexts = new List<MultiLingualString>
                {
                    new MultiLingualString("Bitte Lesen", LanguageCodes.deu),
                    new MultiLingualString("Readme", LanguageCodes.eng)
                },
                Descriptions = new List<MultiLingualString>
                {
                    new MultiLingualString("Eine Text Datei", LanguageCodes.deu),
                    new MultiLingualString("A text file", LanguageCodes.eng)
                },
                Purpose = MimePurpose.Others,
                //MimeSource = new MultiLingualString("ftp://server/de/", LanguageCodes.deu),
                MimeType = "text/plain",
                Embeddeds = new List<MimeEmbedded>
                {
                    new MimeEmbedded
                    {
                        FileName = "Lies mich.txt",
                        Language = LanguageCodes.deu,
                        FileSize = 33,
                        Data = MimeData.FromText("Gut gemacht, Sie haben es gelesen")
                    },
                    new MimeEmbedded
                    {
                        FileName = "Readme.txt",
                        Language = LanguageCodes.eng,
                        FileSize = 22,
                        Data = MimeData.FromText("Well done, you read it")
                    }
                }
            };
        }

        public static BMEcatMime GetBMEcatMime()
        {
            var model = new BMEcatMime
            {
                Purpose = MimePurpose.Others,
                MimeType = "text/plain"
            };
            model.AlternativeTexts.Add(new MultiLingualString("Readme", LanguageCodes.eng));
            model.AlternativeTexts.Add(new MultiLingualString("Bitte Lesen", LanguageCodes.deu));
            model.Descriptions.Add(new MultiLingualString("A text file", LanguageCodes.eng));
            model.Descriptions.Add(new MultiLingualString("Eine Text Datei", LanguageCodes.deu));
            model.Source.Add(new MultiLingualString("ftp://server/en/", LanguageCodes.eng));
            model.Source.Add(new MultiLingualString("ftp://server/de/", LanguageCodes.deu));

            return model;
        }

        public InternationalPid GetInternationalPid()
        {
            var model = new InternationalPid("1234", "Organization");
            return model;
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

        public ProductPriceDetails GetProductPriceDetails()
        {
            var model = new ProductPriceDetails();
            model.ValidStartDate = DateTime.UtcNow;
            model.ValidEndDate = DateTime.UtcNow.AddDays(1);
            model.DailyPrice = false;
            model.ProductPrices.Add(GetProductPrice());
            return model;
        }

        public ProductPrice GetProductPrice()
        {
            var model = new ProductPrice();
            model.Type = ProductPriceValues.NetCustomer;
            model.Formula = GetPriceFormula();
            model.Currency = "EUR";
            model.TaxDetails.Add(GetTaxDetails());
            return model;
        }

        private TaxDetails GetTaxDetails()
        {
            var model = new TaxDetails();
            model.CalculationSequence = 1;
            model.Category = TaxCategoryValues.StandardRate;
            model.Type = "vat";
            model.Tax = 0.20m;
            model.Jurisdiction.Add(new MultiLingualString("Vienna", LanguageCodes.eng));
            model.Jurisdiction.Add(new MultiLingualString("Wien", LanguageCodes.deu));

            return model;
        }

        public PriceFormula GetPriceFormula()
        {
            var model = new PriceFormula();
            model.Idref = "Formula id";
            model.Parameters.Add(GetParameter());

            return model;
        }

        public Parameter GetParameter()
        {
            var model = new Parameter();
            model.SymbolRef = "$";
            model.Value = "10";

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