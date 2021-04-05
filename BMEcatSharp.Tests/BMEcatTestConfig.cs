using System;
using System.Collections.Generic;

namespace BMEcatSharp.Tests
{
    internal class BMEcatTestConfig
    {
        private readonly TestConfig parent;

        public BMEcatTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public string GetCatalogId()
        {
            return "Catalog Spring";
        }

        public BMEcatDocument GetBMEcatNewCatalog()
        {
            var model = new BMEcatDocument();

            model.Header = GetHeader();
            model.NewCatalog = GetNewCatalog();

            return model;
        }

        public BMEcatDocument GetBMEcatUpdateProducts()
        {
            var model = new BMEcatDocument();

            model.Header = GetHeader();
            model.UpdateProducts = GetUpdateProducts();

            return model;
        }

        public BMEcatDocument GetBMEcatUpdatePrices()
        {
            var model = new BMEcatDocument();

            model.Header = GetHeader();
            model.UpdatePrices = GetUpdatePrices();


            return model;
        }

        private UpdatePrices GetUpdatePrices()
        {
            var model = new UpdatePrices();
            model.PreviousVersion = 1;
            //model.Formulas.Add(GetFormula());
            model.Products.Add(GetUpdatePricesProduct());
            return model;
        }

        private UpdatePricesProduct GetUpdatePricesProduct()
        {
            var model = new UpdatePricesProduct();
            model.SupplierPid = GetSupplierPid();
            model.PriceDetails.Add(GetProductPriceDetails());

            return model;
        }

        private UpdateProducts GetUpdateProducts()
        {
            var model = new UpdateProducts();
            model.PreviousVersion = 1;
            //model.Formulas.Add(GetFormula());
            model.Products.Add(GetUpdateProductsProduct());
            return model;
        }

        private UpdateProductsProduct GetUpdateProductsProduct()
        {
            var model = new UpdateProductsProduct();
            model.Mode = UpdateProductsProductMode.Update;
            model.SupplierPid = GetSupplierPid();
            model.Details = GetProductDetails();
            model.OrderDetails = GetProductOrderDetails();
            model.PriceDetails.Add(GetProductPriceDetails());

            return model;
        }

        private Formula GetFormula()
        {
            var model = new Formula();
            model.Id = "Formula id";
            model.Version = GetFormulaVersion();
            model.Name.Add(new MultiLingualString("Formula name", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Formel Name", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Formula description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Formel Beschreibung", LanguageCodes.deu));
            model.Source = GetFormulaSource();
            model.MimeInfo = GetBMEcatMimeInfo();
            model.Function = GetFormulaFunction();
            model.ParameterDefinitions.Add(GetParameterDefinintion());

            return model;
        }

        public PriceFlag GetPriceFlag(string includingPacking, bool value)
        {
            return new PriceFlag(includingPacking, value);
        }

        public BuyerIdref GetBuyerIdref()
        {
            return new BuyerIdref("Buyer", PartyTypeValues.CustomerSpecific);
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
                new MultiLingualString("Zerbrechlich", global::BMEcatSharp.LanguageCodes.deu),
                new MultiLingualString("fragile", global::BMEcatSharp.LanguageCodes.eng)
            });

            return model;
        }

        private ParameterDefinition GetParameterDefinintion()
        {
            var model = new ParameterDefinition();
            model.Symbol = "$";
            model.Basics = GetParameterBasics();
            model.Origin = GetParameterOrigin();
            model.DefaultValue = "false";
            model.Meaning = ParameterMeaning.AllowOrCharge;
            model.Order = 1;

            return model;
        }

        private ParameterOrigin GetParameterOrigin()
        {
            return new ParameterOrigin("Formula id", ParameterOriginType.Formula);
        }

        private ParameterBasics GetParameterBasics()
        {
            var model = new ParameterBasics();
            model.Name.Add(new MultiLingualString("Parameter name", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Parameter Name", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Parameter description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Parameter Beschreibung", LanguageCodes.deu));
            model.Unit.Add(new MultiLingualString("Parameter unit", LanguageCodes.eng));
            model.Unit.Add(new MultiLingualString("Parameter Einheit", LanguageCodes.deu));

            return model;
        }

        private FormulaFunction GetFormulaFunction()
        {
            var model = new FormulaFunction();
            model.Terms.Add(GetTerm());

            return model;
        }

        private Term GetTerm()
        {
            var model = new Term();
            model.Type = TermType.Constraint;
            model.Id = "Term id";
            model.Condition = "$ > 5";
            model.Expression = "true";

            return model;
        }

        private FormulaSource GetFormulaSource()
        {
            var model = new FormulaSource();
            model.Name.Add(new MultiLingualString("Source name", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Quellen-Name", LanguageCodes.deu));
            model.Uri = "https://fake-uri/";
            model.PartyIdref = (PartyId)parent.BMEcats.GetSupplierIdRef();

            return model;
        }

        private FormulaVersion GetFormulaVersion()
        {
            var model = new FormulaVersion();
            model.Version = new Version(2, 1);
            model.VersionDate = DateTime.UtcNow;
            model.Revision = "2";
            model.RevisionDate = DateTime.UtcNow.AddDays(-1);
            model.OriginalDate = DateTime.UtcNow.AddDays(-2);

            return model;
        }

        public BMEcatDocument GetBMEcatNewCatalogWithUdx()
        {
            var model = GetBMEcatNewCatalog();

            model.Header.UserDefinedExtensions.Add(new CustomData()
            {
                Names = new List<string>
                {
                    "Name 1",
                    "Name 2"
                }
            });
            model.Header.UserDefinedExtensions.Add(new CustomData2()
            {
                Name = "Name 3"
            });

            //model.Items[0].ItemUdx.Add(new CustomData()
            //{
            //    Names = new List<string>
            //    {
            //        "Name 1",
            //        "Name 2"
            //    }
            //});
            //model.Items[0].ItemUdx.Add(new CustomData2()
            //{
            //    Name = "Name 3"
            //});

            return model;
        }

        private BMEcatHeader GetHeader()
        {
            var model = new BMEcatHeader();

            model.Catalog = GetCatalog();
            model.SupplierIdref = parent.BMEcats.GetSupplierIdRef();

            return model;
        }

        private Catalog GetCatalog()
        {
            var model = new Catalog();

            model.Language = new Language(LanguageCodes.deu);
            model.Id = GetCatalogId();
            model.Version = new Version("1.1");

            return model;
        }

        private NewCatalog GetNewCatalog()
        {
            var model = new NewCatalog();

            model.Products.Add(GetProduct());
            model.ClassificationSystem.Add(GetClassificationSystem());
            model.IppDefinitions.Add(GetIppDefinition());
            model.Formulas.Add(GetFormula());
            
            return model;
        }

        private IppDefinition GetIppDefinition()
        {
            var model = new IppDefinition();
            model.Id = "Ipp id";
            model.Type = IppType.ProductRequest;
            model.OperatorIdref = GetIppOperatorIdref();
            model.Description.Add(new MultiLingualString("Ipp description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Ipp Beschreibung", LanguageCodes.deu));
            model.Operations.Add(GetIppOperation());

            return model;
        }

        private IppOperation GetIppOperation()
        {
            var model = new IppOperation();
            model.Id = "Ipp operation id";
            model.Type = IppOperationType.Show;
            model.Description.Add(new MultiLingualString("Ipp operation description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Ipp Operation Beschreibung", LanguageCodes.deu));
            model.Outbounds.Add(GetIppOutbound());
            model.Inbounds.Add(GetIppInbound());
            
            return model;
        }

        private IppInbound GetIppInbound()
        {
            var model = new IppInbound();
            model.InboundFormat = IppInboundFormatValues.Mail;
            model.InboundParams = GetIppInboundParams();
            model.ResponseTime = TimeSpan.FromMinutes(1);

            return model;
        }

        public SupplierPid GetSupplierPid(string value, string supplierSpecific)
        {
            return new SupplierPid(value, supplierSpecific);
        }

        public SpecialTreatmentClass GetSpecialTreatmentClass()
        {
            return new SpecialTreatmentClass("Attention", "GGVS");
        }

        public InternationalPid GetInternationalPid()
        {
            var model = new InternationalPid("1234", "Organization");
            return model;
        }

        private IppInboundParams GetIppInboundParams()
        {
            var model = new IppInboundParams();
            model.Definitions.Add(GetIppParamDefinition());

            return model;
        }

        private IppOutbound GetIppOutbound()
        {
            var model = new IppOutbound();
            model.Format = IppOutboundFormatValues.BMEcat2005;
            model.Params = GetIppOutboundParams();
            model.Uri.Add("https://someuri/");

            return model;
        }

        private IppOutboundParams GetIppOutboundParams()
        {
            var model = new IppOutboundParams();
            model.Languages = GetIppLanguages();
            model.Territories = GetIppTerritories();
            model.PriceCurrencies = GetIppPriceCurrencies();
            model.PriceTypes = GetIppPriceTypes();
            model.SupplierPid = GetIppSupplierPid();
            model.ProductconfigIdref = GetIppProductconfigIdref();
            model.ProductlistIdref = GetIppProductlistIdref();
            model.UserInfo = GetIppUserInfo();
            model.AuthentificationInfo = GetIppAuthentificationInfo();
            model.Definitions.Add(GetIppParamDefinition());

            return model;
        }

        private IppParamDefinition GetIppParamDefinition()
        {
            var model = new IppParamDefinition();
            model.Occurrence = IppOccurrence.Mandatory;
            model.Name = "Param name";
            model.Description.Add(new MultiLingualString("Ipp param description"));
            model.Description.Add(new MultiLingualString("Ipp Parameter Beschreibung", LanguageCodes.deu));

            return model;
        }

        private IppAuthentificationInfo GetIppAuthentificationInfo()
        {
            var model = new IppAuthentificationInfo();
            model.Occurrence = IppOccurrence.Optional;
            model.Authentifications.Add(GetAuthentification());

            return model;
        }

        private IppUserInfo GetIppUserInfo()
        {
            return new IppUserInfo("User info", IppOccurrence.Optional);
        }

        private IppProductlistIdref GetIppProductlistIdref()
        {
            return new IppProductlistIdref("Product list id", IppOccurrence.Optional);
        }

        private IppProductconfigIdref GetIppProductconfigIdref()
        {
            return new IppProductconfigIdref("Product configuration id", IppOccurrence.Optional);
        }

        private IppSupplierPid GetIppSupplierPid()
        {
            return new IppSupplierPid("Supplier pid", IppOccurrence.Optional);
        }

        private IppPriceTypes GetIppPriceTypes()
        {
            var model = new IppPriceTypes();
            model.Occurrence = IppOccurrence.Optional;
            model.PriceTypes.Add(ProductPriceTypeValues.NetCustomer);

            return model;
        }

        private IppPriceCurrencies GetIppPriceCurrencies()
        {
            var model = new IppPriceCurrencies();
            model.Occurrence = IppOccurrence.Mandatory;
            model.PriceCurrencies.Add("EUR");

            return model;
        }

        private IppTerritories GetIppTerritories()
        {
            var model = new IppTerritories();
            model.Occurrence = IppOccurrence.Optional;
            model.Territories.Add(CountryCode.AT);

            return model;
        }

        private IppLanguages GetIppLanguages()
        {
            var model = new IppLanguages();
            model.Occurrence = IppOccurrence.Optional;
            model.Languages.Add(new Language(LanguageCodes.eng));

            return model;
        }

        private IppOperatorIdref GetIppOperatorIdref()
        {
            return new IppOperatorIdref("Ipp operator id", PartyTypeValues.PartySpecific);
        }

        private ClassificationSystem GetClassificationSystem()
        {
            var model = new ClassificationSystem();
            model.Name = ClassificationSystemNameValues.EClass(new Version(2, 1));
            model.Fullname = "Classification system full name";
            model.VersionDetails = GetClassificationSystemVersionDetails();
            model.Descripiton = "Classification system description";
            model.ClassificationSystemPartyIdref = GetClassificationSystemPartyIdref();
            model.Levels = 1;
            model.LevelNames.Add(GetClassificationSystemLevelName());
            model.Type = GetClassificationSystemType();
            model.AllowedValues.Add(GetAllowedValue());
            model.Units.Add(GetUnit());
            model.FeatureGroups.Add(GetFeatureGroup());
            model.FeatureTemplates.Add(GetClassificationSystemFeatureTemplate());

            return model;
        }

        private ClassificationSystemFeatureTemplate GetClassificationSystemFeatureTemplate()
        {
            var model = new ClassificationSystemFeatureTemplate();
            model.Id = "Feature id";
            model.Name.Add(new MultiLingualString("Feature name", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Feature Name", LanguageCodes.deu));
            model.Shortname.Add(new MultiLingualString("Feature group", LanguageCodes.eng));
            model.Shortname.Add(new MultiLingualString("Feature Gruppe", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Feature description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Feature Beschreibung", LanguageCodes.deu));
            model.Version = GetFeatureVersion();
            model.GroupIdref = "Feature groupd id";
            model.Dependencies.Add(GetFeatureDependency());
            model.Content = GetFeatureContent();

            return model;
        }

        private FeatureContent GetFeatureContent()
        {
            var model = new FeatureContent();
            model.DataType = FeatureDataTypeValues.DateTime;
            model.Facets.Add(GetFeatureTemplateFacet());
            model.Values.Add(GetFeatureTemplateValue());

            return model;
        }

        private FeatureValue GetFeatureTemplateValue()
        {
            var model = new FeatureValue();
            model.Simple = "10";
            model.MimeInfo = GetBMEcatMimeInfo();
            model.ConfigurationInformation = GetConfigInfo();
            model.Order = 1;
            model.DefaultFlag = true;

            return model;
        }

        private ConfigurationInformation GetConfigInfo()
        {
            var model = new ConfigurationInformation();
            model.ConfigurationCode = "-red";
            model.ProductPriceDetails = GetProductPriceDetails();

            return model;
        }

        private FeatureFacet GetFeatureTemplateFacet()
        {
            return new FeatureFacet("10", FeatureFacetType.TotalDigits);
        }

        private FeatureIdref GetFeatureDependency()
        {
            return new FeatureIdref("Other feature id");
        }

        private FeatureVersion GetFeatureVersion()
        {
            var model = new FeatureVersion();
            model.Version = new Version(2, 1);
            model.VersionDate = DateTime.UtcNow;
            model.Revision = "1";
            model.RevisionDate = DateTime.UtcNow.AddDays(1);
            model.OriginalDate = DateTime.UtcNow.AddDays(-1);

            return model;
        }

        private FeatureGroup GetFeatureGroup()
        {
            var model = new FeatureGroup();
            model.Id = "Feature group id";
            model.Name.Add(new MultiLingualString("Feature group name", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Feature Gruppenname", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Feature group description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Feature Gruppenbeschreibung", LanguageCodes.deu));
            model.ParentIds.Clear();

            return model;
        }

        private Unit GetUnit()
        {
            var model = new Unit();
            model.System = UnitSystemValues.SI;
            model.Id = "Unit id";
            model.Name.Add(new MultiLingualString("Piece", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Stück", LanguageCodes.deu));
            model.Shortname.Add(new MultiLingualString("pcs", LanguageCodes.eng));
            model.Shortname.Add(new MultiLingualString("stk", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Whole pieces", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Ganze Stücke", LanguageCodes.deu));
            model.Code = "piece";
            model.Uri = "https://example/specification";

            return model;
        }

        private AllowedValue GetAllowedValue()
        {
            var model = new AllowedValue();
            model.Id = "Allowed Value ID";
            model.Name.Add(new MultiLingualString("Allowed value", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Erlaubter Wert", LanguageCodes.deu));
            model.Version = GetAllowedValueVersion();
            model.Shortname.Add(new MultiLingualString("Allowed value short", LanguageCodes.eng));
            model.Shortname.Add(new MultiLingualString("Erlaubter Wert Kurz", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Allowed value description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Erlaubter Wert Beschreibung", LanguageCodes.deu));
            model.Synonyms.Add(new MultiLingualString("Allowed value synonym", LanguageCodes.eng));
            model.Synonyms.Add(new MultiLingualString("Erlaubter Wert Synonym", LanguageCodes.deu));
            model.Source = GetAllowedValueSource();

            return model;
        }

        private AllowedValueSource GetAllowedValueSource()
        {
            var model = new AllowedValueSource();
            model.Name.Add(new MultiLingualString("External", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Extern", LanguageCodes.deu));
            model.Uri = "ftp://external/";
            model.PartyIdref = (PartyId)parent.BMEcats.GetSupplierIdRef();

            return model;
        }

        private AllowedValueVersion GetAllowedValueVersion()
        {
            var model = new AllowedValueVersion();
            model.Version = new Version(2, 1);
            model.VersionDate = DateTime.UtcNow;
            model.Revision = "1";
            model.RevisionDate = DateTime.UtcNow.AddDays(1);
            model.OriginalDate = DateTime.UtcNow.AddDays(-1);

            return model;
        }

        private ClassificationSystemType GetClassificationSystemType()
        {
            var model = new ClassificationSystemType();
            model.GroupidHierarchy = true;
            model.MappingType = MappingType.Multiple;
            model.MappingLevel = MappingLevel.Leaf;
            model.Balancedtree = true;
            model.Inheritance = true;

            return model;
        }

        private ClassificationSystemLevelName GetClassificationSystemLevelName()
        {
            var model = new ClassificationSystemLevelName(1, "Color level");
            return model;
        }

        private ClassificationSystemPartyIdref GetClassificationSystemPartyIdref()
        {
            var model = new ClassificationSystemPartyIdref("Supplier", PartyTypeValues.SupplierSpecific);
            return model;
        }

        private ClassificationSystemVersionDetails GetClassificationSystemVersionDetails()
        {
            var model = new ClassificationSystemVersionDetails();
            model.Version = new Version("2.1");
            model.VersionDate = DateTime.UtcNow;
            model.Revision = "3";
            model.RevisionDate = DateTime.UtcNow.AddDays(-1);
            model.OriginalDate = DateTime.UtcNow.AddDays(-2);
            return model;
        }

        private NewCatalogProduct GetProduct()
        {
            var model = new NewCatalogProduct();

            model.SupplierPid = GetSupplierPid();
            model.Details = GetProductDetails();
            model.OrderDetails = GetProductOrderDetails();
            model.PriceDetails.Add(GetProductPriceDetails());
            model.ConfigDetails = GetProductConfigDetails();

            return model;
        }

        private ProductConfigurationDetails GetProductConfigDetails()
        {
            var model = new ProductConfigurationDetails();
            model.Steps.Add(GetConfigurationStep());
            model.PredefinedConfigurations = GetPredefinedConfigurations();
            model.Rules.Add(GetConfigurationRule());
            model.Formulas.Add(GetConfigurationFormula());

            return model;
        }

        private PredefinedConfigurations GetPredefinedConfigurations()
        {
            var model = new PredefinedConfigurations();
            model.Coverage = PredefinedConfigurationCoverage.Partial;
            model.Configurations.Add(GetPredefinedConfiguration());
            return model;
        }

        private PredefinedConfiguration GetPredefinedConfiguration()
        {
            var model = new PredefinedConfiguration();
            model.Description.Add(new MultiLingualString("-red", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("-rot", LanguageCodes.deu));
            model.Name.Add(new MultiLingualString("Predefined configuration", LanguageCodes.eng));
            model.Name.Add(new MultiLingualString("Vordefinierte Konfiguration", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Predefined configuration description", LanguageCodes.eng));
            model.Description.Add(new MultiLingualString("Vordefinierte Konfiguration Beschreibung", LanguageCodes.deu));
            model.Order = 1;
            model.ProductPriceDetails = GetProductPriceDetails();
            model.SupplierPid = GetSupplierPid();
            model.InternationalPids.Add(parent.BMEcats.GetInternationalPid());

            return model;
        }

        private ConfigurationFormula GetConfigurationFormula()
        {
            var model = new ConfigurationFormula();
            model.Idref = "Configuraton formula id";
            model.Parameters.Add(GetParameter());
            return model;
        }

        private Term GetConfigurationRule()
        {
            var model = new Term();
            model.Type = TermType.Constraint;
            model.Id = "Rule id";
            model.Condition = "$ < 5";
            model.Expression = "true";

            return model;
        }

        private ConfigurationStep GetConfigurationStep()
        {
            var model = new ConfigurationStep();
            model.Id = "Step id";
            model.Header.Add(new MultiLingualString("This is a step"));
            model.Header.Add(new MultiLingualString("Das ist ein Schritt", LanguageCodes.deu));
            model.DescriptionShort.Add(new MultiLingualString("A short description", LanguageCodes.eng));
            model.DescriptionShort.Add(new MultiLingualString("Eine kurze Beschreibung", LanguageCodes.deu));
            model.DescriptionLong.Add(new MultiLingualString("A short description", LanguageCodes.eng));
            model.DescriptionLong.Add(new MultiLingualString("Eine lange Beschreibung", LanguageCodes.deu));
            model.Order = 1;
            model.InteractionType = StepInteractionType.ForceUserinput;
            model.ConfigurationCode = "-red";
            model.ProductPriceDetails = GetProductPriceDetails();
            model.ConfigurationFeature = GetConfigurationFeature();
            model.MinimumOccurance = 1;
            model.MaximumOccurance = 2;

            return model;
        }

        private ConfigurationFeature GetConfigurationFeature()
        {
            var model = new ConfigurationFeature();
            //model.FeatureReference = GetFeatureReference();
            model.FeatureTemplate = GetFeatureTemplate();
            model.MimeInfo = GetBMEcatMimeInfo();

            return model;
        }

        private FeatureTemplate GetFeatureTemplate()
        {
            var model = new FeatureTemplate();
            model.Id = "Feature id";
            model.Name.Add(new MultiLingualString("Feature"));
            model.Name.Add(new MultiLingualString("Feature", LanguageCodes.deu));
            model.Shortname.Add(new MultiLingualString("Feature short name"));
            model.Shortname.Add(new MultiLingualString("Feature Kurzname", LanguageCodes.deu));
            model.Description.Add(new MultiLingualString("Feature description"));
            model.Description.Add(new MultiLingualString("Feature Beschreibung", LanguageCodes.deu));
            model.Version = GetFeatureTemplateVersion();
            model.GroupName.Add(new MultiLingualString("Feature group name"));
            model.GroupName.Add(new MultiLingualString("Feature Gruppenname", LanguageCodes.deu));
            model.Content = GetFeatureContent();

            return model;
        }

        private FeatureVersion GetFeatureTemplateVersion()
        {
            var model = new FeatureVersion();
            model.Version = new Version(2, 1);
            model.VersionDate = DateTime.UtcNow;
            model.Revision = "2";
            model.RevisionDate = DateTime.UtcNow;
            model.OriginalDate = DateTime.UtcNow.AddDays(-1);

            return model;
        }

        private FeatureReference GetFeatureReference()
        {
            var model = new FeatureReference();
            model.SystemName = ReferenceFeatureSystemNameValues.EClass(new Version(4, 1));
            model.Idref = "Feature id";

            return model;
        }

        private ProductPriceDetails GetProductPriceDetails()
        {
            var model = new ProductPriceDetails();
            model.ValidStartDate = DateTime.UtcNow;
            model.DailyPrice = false;
            model.ProductPrices.Add(GetProductPrice());

            return model;
        }

        private ProductPrice GetProductPrice()
        {
            var model = new ProductPrice();
            model.Type = ProductPriceTypeValues.NetCustomer;
            model.Amount = 5;
            model.Currency = "EUR";
            model.TaxDetails.Add(GetTaxDetails());
            model.Factor = 1;
            model.LowerBound = 2;
            model.AreaRefs.Add("Area ref");
            model.Base = GetPriceBase();
            model.PriceFlags.Add(GetPriceFlag());

            return model;
        }

        private PriceFlag GetPriceFlag()
        {
            var model = new PriceFlag();
            model.Type = PriceFlagTypes.IncludingPacking;
            model.Value = true;

            return model;
        }

        private PriceBase GetPriceBase()
        {
            var model = new PriceBase();
            model.Unit = "C62";
            model.UnitFactor = 2;

            return model;
        }

        private TaxDetails GetTaxDetails()
        {
            var model = new TaxDetails();
            model.Category = TaxCategoryValues.StandardRate;
            model.Tax = 1;
            model.Jurisdiction.Add(new MultiLingualString("Vienna"));
            model.Jurisdiction.Add(new MultiLingualString("Wien", LanguageCodes.deu));

            return model;
        }

        private ProductOrderDetails GetProductOrderDetails()
        {
            var model = new ProductOrderDetails();
            model.OrderUnit = "C62";
            model.ContentUnit = "C62";

            return model;
        }

        private ProductDetails GetProductDetails()
        {
            var model = new ProductDetails();

            model.DescriptionShort.Add(new MultiLingualString("Product description short"));
            model.DescriptionShort.Add(new MultiLingualString("Produktbeschreibung kurz", LanguageCodes.deu));

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

        public ContactRole GetContactRole()
        {
            return new ContactRole("Contact", global::BMEcatSharp.ContactRoleType.Technical);
        }

        public PublicKey GetPublicKey(string type = null)
        {
            return new PublicKey("1234", type ?? global::BMEcatSharp.PublicKeyTypeValues.PGP(new Version(6, 5, 1)));
        }

        public Fax GetFax(string type = "office")
        {
            return new Fax("+43234567890", type);
        }

        public Phone GetPhone(string type = "mobile")
        {
            return new Phone("+43123456789", type);
        }

        public Email GetEmail()
        {
            var model = new Email();
            model.EmailAddress = "mail@example.com";
            model.PublicKeys.Add(GetPublicKey());
            model.PublicKeys.Add(GetPublicKey("etc"));

            return model;
        }

        public SupplierIdref GetSupplierIdRef()
        {
            return new SupplierIdref("Supplier", PartyTypeValues.SupplierSpecific);
        }

        private Address GetBMEcatAddress()
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

        public BMEcatMimeInfo GetBMEcatMimeInfo()
        {
            var model = new BMEcatMimeInfo();

            model.Mimes.Add(GetBMEcatMime());

            return model;
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

        //public ProductPriceDetails GetProductPriceDetails()
        //{
        //    var model = new ProductPriceDetails();
        //    model.ValidStartDate = DateTime.UtcNow;
        //    model.ValidEndDate = DateTime.UtcNow.AddDays(1);
        //    model.DailyPrice = false;
        //    model.ProductPrices.Add(GetProductPrice());
        //    return model;
        //}

        //public ProductPrice GetProductPrice()
        //{
        //    var model = new ProductPrice();
        //    model.Type = ProductPriceValues.NetCustomer;
        //    model.Formula = GetPriceFormula();
        //    model.Currency = "EUR";
        //    model.TaxDetails.Add(GetTaxDetails());
        //    return model;
        //}

        //private TaxDetails GetTaxDetails()
        //{
        //    var model = new TaxDetails();
        //    model.CalculationSequence = 1;
        //    model.Category = TaxCategoryValues.StandardRate;
        //    model.Type = "vat";
        //    model.Tax = 0.20m;
        //    model.Jurisdiction.Add(new MultiLingualString("Vienna", LanguageCodes.eng));
        //    model.Jurisdiction.Add(new MultiLingualString("Wien", LanguageCodes.deu));

        //    return model;
        //}

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

        public SupplierPid GetSupplierPid()
        {
            return new SupplierPid("ProductId", SupplierPidTypeValues.SupplierSpecific);
        }

        public Authentification GetAuthentification()
        {
            return new Authentification("login", "password");
        }

        public MultiLingualString GetMimeRoot()
        {
            return new MultiLingualString("ftp://server/en", global::BMEcatSharp.LanguageCodes.eng);
        }
    }
}