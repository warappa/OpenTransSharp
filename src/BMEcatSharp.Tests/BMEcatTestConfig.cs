namespace BMEcatSharp.Tests;

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
        var model = new BMEcatDocument
        {
            Header = GetHeader(),
            NewCatalog = GetNewCatalog()
        };

        return model;
    }

    public BMEcatDocument GetBMEcatUpdateProducts()
    {
        var model = new BMEcatDocument
        {
            Header = GetHeader(),
            UpdateProducts = GetUpdateProducts()
        };

        return model;
    }

    public BMEcatDocument GetBMEcatUpdatePrices()
    {
        var model = new BMEcatDocument
        {
            Header = GetHeader(),
            UpdatePrices = GetUpdatePrices()
        };


        return model;
    }

    private UpdatePrices GetUpdatePrices()
    {
        var model = new UpdatePrices
        {
            PreviousVersion = 1
        };
        //model.Formulas.Add(GetFormula());
        model.Products.Add(GetUpdatePricesProduct());
        return model;
    }

    private UpdatePricesProduct GetUpdatePricesProduct()
    {
        var model = new UpdatePricesProduct
        {
            SupplierPid = GetSupplierPid()
        };
        model.PriceDetails.Add(GetProductPriceDetails());

        return model;
    }

    private UpdateProducts GetUpdateProducts()
    {
        var model = new UpdateProducts
        {
            PreviousVersion = 1
        };
        //model.Formulas.Add(GetFormula());
        model.Products.Add(GetUpdateProductsProduct());
        return model;
    }

    private UpdateProductsProduct GetUpdateProductsProduct()
    {
        var model = new UpdateProductsProduct
        {
            Mode = UpdateProductsProductMode.Update,
            SupplierPid = GetSupplierPid(),
            Details = GetProductDetails(),
            OrderDetails = GetProductOrderDetails()
        };
        model.PriceDetails.Add(GetProductPriceDetails());

        return model;
    }

    private Formula GetFormula()
    {
        var model = new Formula
        {
            Id = "Formula id",
            Version = GetFormulaVersion()
        };
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

    public BuyerIdRef GetBuyerIdRef()
    {
        return new BuyerIdRef("Buyer", PartyTypeValues.CustomerSpecific);
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
        var model = new ParameterDefinition
        {
            Symbol = "$",
            Basics = GetParameterBasics(),
            Origin = GetParameterOrigin(),
            DefaultValue = "false",
            Meaning = ParameterMeaning.AllowOrCharge,
            Order = 1
        };

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
        var model = new Term
        {
            Type = TermType.Constraint,
            Id = "Term id",
            Condition = "$ > 5",
            Expression = "true"
        };

        return model;
    }

    private FormulaSource GetFormulaSource()
    {
        var model = new FormulaSource();
        model.Name.Add(new MultiLingualString("Source name", LanguageCodes.eng));
        model.Name.Add(new MultiLingualString("Quellen-Name", LanguageCodes.deu));
        model.Uri = "https://fake-uri/";
        model.PartyIdRef = (PartyId)parent.BMEcats.GetSupplierIdRef();

        return model;
    }

    private FormulaVersion GetFormulaVersion()
    {
        var model = new FormulaVersion
        {
            Version = new Version(2, 1),
            VersionDate = DateTime.UtcNow,
            Revision = "2",
            RevisionDate = DateTime.UtcNow.AddDays(-1),
            OriginalDate = DateTime.UtcNow.AddDays(-2)
        };

        return model;
    }

    public BMEcatDocument GetBMEcatNewCatalogWithUdx()
    {
        var model = GetBMEcatNewCatalog();

        model.Header.UserDefinedExtensions.Add(new CustomData()
        {
            Names =
            [
                "Name 1",
                "Name 2"
            ]
        });
        model.Header.UserDefinedExtensions.Add(new CustomData2()
        {
            Name = "Name 3"
        });

        return model;
    }

    private BMEcatHeader GetHeader()
    {
        var model = new BMEcatHeader
        {
            Catalog = GetCatalog(),
            SupplierIdRef = parent.BMEcats.GetSupplierIdRef()
        };

        return model;
    }

    private Catalog GetCatalog()
    {
        var model = new Catalog();

        model.Languages.Add(new Language(LanguageCodes.deu));
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
        var model = new IppDefinition
        {
            Id = "Ipp id",
            Type = IppType.ProductRequest,
            OperatorIdRef = GetIppOperatorIdRef()
        };
        model.Description.Add(new MultiLingualString("Ipp description", LanguageCodes.eng));
        model.Description.Add(new MultiLingualString("Ipp Beschreibung", LanguageCodes.deu));
        model.Operations.Add(GetIppOperation());

        return model;
    }

    private IppOperation GetIppOperation()
    {
        var model = new IppOperation
        {
            Id = "Ipp operation id",
            Type = IppOperationType.Show
        };
        model.Description.Add(new MultiLingualString("Ipp operation description", LanguageCodes.eng));
        model.Description.Add(new MultiLingualString("Ipp Operation Beschreibung", LanguageCodes.deu));
        model.Outbounds.Add(GetIppOutbound());
        model.Inbounds.Add(GetIppInbound());

        return model;
    }

    private IppInbound GetIppInbound()
    {
        var model = new IppInbound
        {
            InboundFormat = IppInboundFormatValues.Mail,
            InboundParams = GetIppInboundParams(),
            ResponseTime = TimeSpan.FromMinutes(1)
        };

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
        var model = new IppOutbound
        {
            Format = IppOutboundFormatValues.BMEcat2005,
            Params = GetIppOutboundParams()
        };
        model.Uri.Add("https://someuri/");

        return model;
    }

    private IppOutboundParams GetIppOutboundParams()
    {
        var model = new IppOutboundParams
        {
            Languages = GetIppLanguages(),
            Territories = GetIppTerritories(),
            PriceCurrencies = GetIppPriceCurrencies(),
            PriceTypes = GetIppPriceTypes(),
            SupplierPid = GetIppSupplierPid(),
            ProductconfigIdRef = GetIppProductconfigIdRef(),
            ProductlistIdRef = GetIppProductlistIdRef(),
            UserInfo = GetIppUserInfo(),
            AuthentificationInfo = GetIppAuthentificationInfo()
        };
        model.Definitions.Add(GetIppParamDefinition());

        return model;
    }

    private IppParamDefinition GetIppParamDefinition()
    {
        var model = new IppParamDefinition
        {
            Occurrence = IppOccurrence.Mandatory,
            Name = "Param name"
        };
        model.Description.Add(new MultiLingualString("Ipp param description"));
        model.Description.Add(new MultiLingualString("Ipp Parameter Beschreibung", LanguageCodes.deu));

        return model;
    }

    private IppAuthentificationInfo GetIppAuthentificationInfo()
    {
        var model = new IppAuthentificationInfo
        {
            Occurrence = IppOccurrence.Optional
        };
        model.Authentifications.Add(GetAuthentification());

        return model;
    }

    private IppUserInfo GetIppUserInfo()
    {
        return new IppUserInfo(IppOccurrence.Optional);
    }

    private IppProductlistIdRef GetIppProductlistIdRef()
    {
        return new IppProductlistIdRef(IppOccurrence.Optional);
    }

    private IppProductconfigIdRef GetIppProductconfigIdRef()
    {
        return new IppProductconfigIdRef(IppOccurrence.Optional);
    }

    private IppSupplierPid GetIppSupplierPid()
    {
        return new IppSupplierPid(IppOccurrence.Optional);
    }

    private IppPriceTypes GetIppPriceTypes()
    {
        var model = new IppPriceTypes
        {
            Occurrence = IppOccurrence.Optional
        };
        model.PriceTypes.Add(ProductPriceTypeValues.NetCustomer);

        return model;
    }

    private IppPriceCurrencies GetIppPriceCurrencies()
    {
        var model = new IppPriceCurrencies
        {
            Occurrence = IppOccurrence.Mandatory
        };
        model.PriceCurrencies.Add("EUR");

        return model;
    }

    private IppTerritories GetIppTerritories()
    {
        var model = new IppTerritories
        {
            Occurrence = IppOccurrence.Optional
        };
        model.Territories.Add(CountryCode.AT);

        return model;
    }

    private IppLanguages GetIppLanguages()
    {
        var model = new IppLanguages
        {
            Occurrence = IppOccurrence.Optional
        };
        model.Languages.Add(new Language(LanguageCodes.eng));

        return model;
    }

    private IppOperatorIdRef GetIppOperatorIdRef()
    {
        return new IppOperatorIdRef("Ipp operator id", PartyTypeValues.PartySpecific);
    }

    private ClassificationSystem GetClassificationSystem()
    {
        var model = new ClassificationSystem
        {
            Name = ClassificationSystemNameValues.EClass(new Version(2, 1)),
            Fullname = "Classification system full name",
            VersionDetails = GetClassificationSystemVersionDetails(),
            Descripiton = "Classification system description",
            ClassificationSystemPartyIdRef = GetClassificationSystemPartyIdRef(),
            Levels = 1
        };
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
        var model = new ClassificationSystemFeatureTemplate
        {
            Id = "Feature id"
        };
        model.Name.Add(new MultiLingualString("Feature name", LanguageCodes.eng));
        model.Name.Add(new MultiLingualString("Feature Name", LanguageCodes.deu));
        model.Shortname.Add(new MultiLingualString("Feature group", LanguageCodes.eng));
        model.Shortname.Add(new MultiLingualString("Feature Gruppe", LanguageCodes.deu));
        model.Description.Add(new MultiLingualString("Feature description", LanguageCodes.eng));
        model.Description.Add(new MultiLingualString("Feature Beschreibung", LanguageCodes.deu));
        model.Version = GetFeatureVersion();
        model.GroupIdRef = "Feature groupd id";
        model.Dependencies.Add(GetFeatureDependency());
        model.Content = GetFeatureContent();

        return model;
    }

    private FeatureContent GetFeatureContent()
    {
        var model = new FeatureContent
        {
            DataType = FeatureDataTypeValues.DateTime
        };
        model.Facets.Add(GetFeatureTemplateFacet());
        model.Values.Add(GetFeatureTemplateValue());

        return model;
    }

    private FeatureValue GetFeatureTemplateValue()
    {
        var model = new FeatureValue
        {
            Simple = "10",
            MimeInfo = GetBMEcatMimeInfo(),
            ConfigurationInformation = GetConfigInfo(),
            Order = 1,
            DefaultFlag = true
        };

        return model;
    }

    private ConfigurationInformation GetConfigInfo()
    {
        var model = new ConfigurationInformation
        {
            ConfigurationCode = "-red",
            ProductPriceDetails = GetProductPriceDetails()
        };

        return model;
    }

    private FeatureFacet GetFeatureTemplateFacet()
    {
        return new FeatureFacet("10", FeatureFacetType.TotalDigits);
    }

    private FeatureIdRef GetFeatureDependency()
    {
        return new FeatureIdRef("Other feature id");
    }

    private FeatureVersion GetFeatureVersion()
    {
        var model = new FeatureVersion
        {
            Version = new Version(2, 1),
            VersionDate = DateTime.UtcNow,
            Revision = "1",
            RevisionDate = DateTime.UtcNow.AddDays(1),
            OriginalDate = DateTime.UtcNow.AddDays(-1)
        };

        return model;
    }

    private FeatureGroup GetFeatureGroup()
    {
        var model = new FeatureGroup
        {
            Id = "Feature group id"
        };
        model.Name.Add(new MultiLingualString("Feature group name", LanguageCodes.eng));
        model.Name.Add(new MultiLingualString("Feature Gruppenname", LanguageCodes.deu));
        model.Description.Add(new MultiLingualString("Feature group description", LanguageCodes.eng));
        model.Description.Add(new MultiLingualString("Feature Gruppenbeschreibung", LanguageCodes.deu));
        model.ParentIds.Clear();

        return model;
    }

    private ClassificationUnit GetUnit()
    {
        var model = new ClassificationUnit
        {
            System = UnitSystemValues.SI,
            Id = "Unit id"
        };
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
        var model = new AllowedValue
        {
            Id = "Allowed Value ID"
        };
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
        model.PartyIdRef = (PartyId)parent.BMEcats.GetSupplierIdRef();

        return model;
    }

    private AllowedValueVersion GetAllowedValueVersion()
    {
        var model = new AllowedValueVersion
        {
            Version = new Version(2, 1),
            VersionDate = DateTime.UtcNow,
            Revision = "1",
            RevisionDate = DateTime.UtcNow.AddDays(1),
            OriginalDate = DateTime.UtcNow.AddDays(-1)
        };

        return model;
    }

    private ClassificationSystemType GetClassificationSystemType()
    {
        var model = new ClassificationSystemType
        {
            GroupidHierarchy = true,
            MappingType = MappingType.Multiple,
            MappingLevel = MappingLevel.Leaf,
            Balancedtree = true,
            Inheritance = true
        };

        return model;
    }

    private ClassificationSystemLevelName GetClassificationSystemLevelName()
    {
        var model = new ClassificationSystemLevelName(1, "Color level");
        return model;
    }

    private ClassificationSystemPartyIdRef GetClassificationSystemPartyIdRef()
    {
        var model = new ClassificationSystemPartyIdRef("Supplier", PartyTypeValues.SupplierSpecific);
        return model;
    }

    private ClassificationSystemVersionDetails GetClassificationSystemVersionDetails()
    {
        var model = new ClassificationSystemVersionDetails
        {
            Version = new Version("2.1"),
            VersionDate = DateTime.UtcNow,
            Revision = "3",
            RevisionDate = DateTime.UtcNow.AddDays(-1),
            OriginalDate = DateTime.UtcNow.AddDays(-2)
        };
        return model;
    }

    private NewCatalogProduct GetProduct()
    {
        var model = new NewCatalogProduct
        {
            SupplierPid = GetSupplierPid(),
            Details = GetProductDetails(),
            OrderDetails = GetProductOrderDetails()
        };
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
        var model = new PredefinedConfigurations
        {
            Coverage = PredefinedConfigurationCoverage.Partial
        };
        model.Configurations.Add(GetPredefinedConfiguration());
        return model;
    }

    private PredefinedConfiguration GetPredefinedConfiguration()
    {
        var model = new PredefinedConfiguration
        {
            //model.Code = null!; // for validation debugging purposes
            Code = "ConfigCode"
        };
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
        var model = new ConfigurationFormula
        {
            IdRef = "Configuraton formula id"
        };
        model.Parameters.Add(GetParameter());
        return model;
    }

    private Term GetConfigurationRule()
    {
        var model = new Term
        {
            Type = TermType.Constraint,
            Id = "Rule id",
            Condition = "$ < 5",
            Expression = "true"
        };

        return model;
    }

    private ConfigurationStep GetConfigurationStep()
    {
        var model = new ConfigurationStep
        {
            Id = "Step id"
        };
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
        var model = new ConfigurationFeature
        {
            //model.FeatureReference = GetFeatureReference();
            FeatureTemplate = GetFeatureTemplate(),
            MimeInfo = GetBMEcatMimeInfo()
        };

        return model;
    }

    private FeatureTemplate GetFeatureTemplate()
    {
        var model = new FeatureTemplate
        {
            Id = "Feature id"
        };
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
        var model = new FeatureVersion
        {
            Version = new Version(2, 1),
            VersionDate = DateTime.UtcNow,
            Revision = "2",
            RevisionDate = DateTime.UtcNow,
            OriginalDate = DateTime.UtcNow.AddDays(-1)
        };

        return model;
    }

    private FeatureReference GetFeatureReference()
    {
        var model = new FeatureReference
        {
            SystemName = ReferenceFeatureSystemNameValues.EClass(new Version(4, 1)),
            IdRef = "Feature id"
        };

        return model;
    }

    private ProductPriceDetails GetProductPriceDetails()
    {
        var model = new ProductPriceDetails
        {
            ValidStartDate = DateTime.UtcNow,
            DailyPrice = false
        };
        model.ProductPrices.Add(GetProductPrice());

        return model;
    }

    private ProductPrice GetProductPrice()
    {
        var model = new ProductPrice
        {
            Type = ProductPriceTypeValues.NetCustomer,
            Amount = 5,
            Currency = "EUR"
        };
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
        var model = new PriceFlag
        {
            Type = PriceFlagTypes.IncludingPacking,
            Value = true
        };

        return model;
    }

    private PriceBase GetPriceBase()
    {
        var model = new PriceBase
        {
            Unit = PackageUnit.C62,
            UnitFactor = 2
        };

        return model;
    }

    private TaxDetails GetTaxDetails()
    {
        var model = new TaxDetails
        {
            Category = TaxCategoryValues.StandardRate,
            Tax = 1
        };
        model.Jurisdiction.Add(new MultiLingualString("Vienna"));
        model.Jurisdiction.Add(new MultiLingualString("Wien", LanguageCodes.deu));

        return model;
    }

    private ProductOrderDetails GetProductOrderDetails()
    {
        var model = new ProductOrderDetails
        {
            OrderUnit = PackageUnit.C62,
            ContentUnit = PackageUnit.C62
        };

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
        var model = new BMEcatContactDetails
        {
            Id = "Contact id"
        };
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
        model.Emails = GetEmails();

        return model;
    }

    public ContactRole GetContactRole()
    {
        return new ContactRole("Contact", global::BMEcatSharp.ContactRoleType.Technical);
    }

    public PublicKey GetPublicKey(string? type = null)
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

    public List<Email> GetEmails()
    {
        return [GetEmail()];
    }

    public Email GetEmail()
    {
        var model = new Email
        {
            EmailAddress = "mail@example.com"
        };
        model.PublicKeys.Add(GetPublicKey());
        model.PublicKeys.Add(GetPublicKey("etc"));

        return model;
    }

    public SupplierIdRef GetSupplierIdRef()
    {
        return new SupplierIdRef("Supplier", PartyTypeValues.SupplierSpecific);
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
        model.Emails = GetEmails();
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
        var model = new PriceFormula
        {
            IdRef = "Formula id"
        };
        model.Parameters.Add(GetParameter());

        return model;
    }

    public Parameter GetParameter()
    {
        var model = new Parameter
        {
            SymbolRef = "$",
            Value = "10"
        };

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
