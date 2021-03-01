using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.BMEcats
{
    internal class BMEcatTestConfig
    {
        private TestConfig parent;

        public BMEcatTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public BMEcat GetBMEcatNewCatalog()
        {
            var model = new BMEcat();

            model.Header = GetHeader();
            model.NewCatalog = GetNewCatalog();

            return model;
        }

        public BMEcat GetBMEcatUpdateProducts()
        {
            var model = new BMEcat();

            model.Header = GetHeader();
            model.UpdateProducts = GetUpdateProducts();

            return model;
        }

        public BMEcat GetBMEcatUpdatePrices()
        {
            var model = new BMEcat();

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
            model.SupplierPid = parent.GetSupplierPid();
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
            model.SupplierPid = parent.GetSupplierPid();
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
            model.Name = new MultiLingualString("Formula name", LanguageCodes.eng);
            model.Description = new MultiLingualString("Formula description", LanguageCodes.eng);
            model.Source = GetFormulaSource();
            model.MimeInfo = parent.GetBMEcatMimeInfo();
            model.Function = GetFormulaFunction();
            model.ParameterDefinitions.Add(GetParameterDefinintion());

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
            model.Name = new MultiLingualString("Parameter name", LanguageCodes.eng);
            model.Description = new MultiLingualString("Parameter description", LanguageCodes.eng);
            model.Unit = new MultiLingualString("Parameter unit", LanguageCodes.eng);

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
            model.Name = new MultiLingualString("Source name", LanguageCodes.eng);
            model.Uri = "https://fake-uri/";
            model.PartyIdref = (PartyId)parent.GetSupplierIdRef();

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

        public BMEcat GetBMEcatNewCatalogWithUdx()
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
            model.SupplierIdref = parent.GetSupplierIdRef();

            return model;
        }

        private Catalog GetCatalog()
        {
            var model = new Catalog();

            model.Language = new Language(LanguageCodes.deu);
            model.Id = parent.GetCatalogId();
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
            model.Description = new MultiLingualString("Ipp description", LanguageCodes.eng);
            model.Operations.Add(GetIppOperation());

            return model;
        }

        private IppOperation GetIppOperation()
        {
            var model = new IppOperation();
            model.Id = "Ipp operation id";
            model.Type = IppOperationType.Show;
            model.Description = new MultiLingualString("Ipp operation description");
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
            model.Uris.Add("https://someuri/");

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
            model.Description = new MultiLingualString("Ipp param description");

            return model;
        }

        private IppAuthentificationInfo GetIppAuthentificationInfo()
        {
            var model = new IppAuthentificationInfo();
            model.Occurrence = IppOccurrence.Optional;
            model.Authentifications.Add(parent.GetAuthentification());

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
            model.PriceTypes.Add(ProductPriceValues.NetCustomer);

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
            model.FtGroups.Add(GetFeatureGroup());
            model.FeatureTemplates.Add(GetClassificationSystemFeatureTemplate());

            return model;
        }

        private ClassificationSystemFeatureTemplate GetClassificationSystemFeatureTemplate()
        {
            var model = new ClassificationSystemFeatureTemplate();
            model.Id = "Feature id";
            model.Name = "Feature name";
            model.Shortame = "Feature group";
            model.Description = "Feature description";
            model.Version = GetFeatureVersion();
            model.GroupIdref = "Feature groupd id";
            model.Dependencies.Add(GetFeatureDependency());
            model.Content = GetFeatureContent();

            return model;
        }

        private FeatureContent GetFeatureContent()
        {
            var model = new FeatureContent();
            model.FeatureTemplateDataType = FeatureTemplateDataTypeValues.DateTime;
            model.FeatureTemplateFacets.Add(GetFeatureTemplateFacet());
            model.FeatureTemplateValues.Add(GetFeatureTemplateValue());

            return model;
        }

        private FeatureTemplateValue GetFeatureTemplateValue()
        {
            var model = new FeatureTemplateValue();
            model.ValueSimple = "10";
            model.MimeInfo = parent.GetBMEcatMimeInfo();
            model.ConfigInfo = GetConfigInfo();
            model.ValueOrder = 1;
            model.DefaultFlag = true;

            return model;
        }

        private ConfigInfo GetConfigInfo()
        {
            var model = new ConfigInfo();
            model.ConfigCode = "-red";
            model.ProductPriceDetails = GetProductPriceDetails();

            return model;
        }

        private FeatureTemplateFacet GetFeatureTemplateFacet()
        {
            return new FeatureTemplateFacet("10", FeatureTemplateFacetType.TotalDigits);
        }

        private FtIdref GetFeatureDependency()
        {
            return new FtIdref("Other feature id");
        }

        private FtVersion GetFeatureVersion()
        {
            var model = new FtVersion();
            model.Version = new Version(2, 1);
            model.VersionDate = DateTime.UtcNow;
            model.Revision = "1";
            model.RevisionDate = DateTime.UtcNow.AddDays(1);
            model.OriginalDate = DateTime.UtcNow.AddDays(-1);

            return model;
        }

        private FtGroup GetFeatureGroup()
        {
            var model = new FtGroup();
            model.Id = "Feature group id";
            model.Name = "Feature group name";
            model.Description = "Feature group description";
            model.ParentIds.Clear();

            return model;
        }

        private Unit GetUnit()
        {
            var model = new Unit();
            model.System = UnitSystemValues.SI;
            model.UnitId = "Unit id";
            model.UnitName = new MultiLingualString("Piece", LanguageCodes.eng);
            model.UnitShortname = new MultiLingualString("pcs", LanguageCodes.eng);
            model.UnitDescription = new MultiLingualString("Whole pieces", LanguageCodes.eng);
            model.UnitCode = "piece";
            model.UnitUri = "https://example/specification";

            return model;
        }

        private AllowedValue GetAllowedValue()
        {
            var model = new AllowedValue();
            model.Id = "Allowed Value ID";
            model.Name = new MultiLingualString("Allowed value", LanguageCodes.eng);
            model.Version = GetAllowedValueVersion();
            model.Shortname = "Allowed Value Short";
            model.Description = "Allowed Value Description";
            model.Synonyms.Add(new MultiLingualString("Allowed Value long text", LanguageCodes.eng));
            model.Source = GetAllowedValueSource();

            return model;
        }

        private AllowedValueSource GetAllowedValueSource()
        {
            var model = new AllowedValueSource();
            model.Name = "External";
            model.Uri = "ftp://external/";
            model.PartyIdref = (PartyId)parent.GetSupplierIdRef();

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

            model.SupplierPid = parent.GetSupplierPid();
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
            model.Description = "-red";
            model.Name = new MultiLingualString("Predefined configuration");
            model.Description = new MultiLingualString("Predefined configuration description");
            model.Order = 1;
            model.ProductPriceDetails = GetProductPriceDetails();
            model.SupplierPid = parent.GetSupplierPid();
            model.InternationalPids.Add(parent.GetInternationalPid());

            return model;
        }

        private ConfigurationFormula GetConfigurationFormula()
        {
            var model = new ConfigurationFormula();
            model.Idref = "Configuraton formula id";
            model.Parameters.Add(parent.GetParameter());
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
            model.StepHeader = "This is a step";
            model.DescriptionShort = new MultiLingualString("A short description", LanguageCodes.eng);
            model.DescriptionLong = new MultiLingualString("A long description", LanguageCodes.eng);
            model.Order = 1;
            model.InteractionType = StepInteractionType.ForceUserinput;
            model.ConfigurationCode = "-red";
            model.ProductPriceDetails = parent.GetProductPriceDetails();
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
            model.MimeInfo = parent.GetBMEcatMimeInfo();

            return model;
        }

        private FeatureTemplate GetFeatureTemplate()
        {
            var model = new FeatureTemplate();
            model.FeatureTemplateId = "Feature id";
            model.FeatureTemplateName = new MultiLingualString("Feature");
            model.FeatureTemplateShortName = new MultiLingualString("Feature short");
            model.FeatureTemplateDescription = new MultiLingualString("Feature description");
            model.FeatureTemplateVersion = GetFeatureTemplateVersion();
            model.FeatureTemplateGroupName = new MultiLingualString("Feature group");
            model.FeatureContent = GetFeatureContent();

            return model;
        }

        private FeatureTemplateVersion GetFeatureTemplateVersion()
        {
            var model = new FeatureTemplateVersion();
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
            model.PriceType = ProductPriceValues.NetCustomer;
            model.PriceAmount = 5;
            model.PriceCurrency = "EUR";
            model.TaxDetails.Add(GetTaxDetails());
            model.PriceFactor = 1;
            model.LowerBound = 2;
            model.AreaRefs.Add("Area ref");
            model.PriceBase = GetPriceBase();
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
            model.PriceUnit = "C62";
            model.PriceUnitFactor = 2;

            return model;
        }

        private TaxDetails GetTaxDetails()
        {
            var model = new TaxDetails();
            model.TaxCategory = TaxCategoryValues.StandardRate;
            model.Tax = 1;
            model.Jurisdiction = "Vienna";

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

            model.DescriptionShort = "Product description";

            return model;
        }
    }
}