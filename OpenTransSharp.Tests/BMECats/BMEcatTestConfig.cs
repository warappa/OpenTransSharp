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
            model.ProductPriceDetails.Add(GetProductPriceDetails());

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
            model.ProductDetails = GetProductDetails();
            model.ProductOrderDetails = GetProductOrderDetails();
            model.ProductPriceDetails.Add(GetProductPriceDetails());

            return model;
        }

        private Formula GetFormula()
        {
            var model = new Formula();
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
            model.CatalogId = parent.GetCatalogId();
            model.Version = new Version("1.1");

            return model;
        }

        private NewCatalog GetNewCatalog()
        {
            var model = new NewCatalog();

            model.Products.Add(GetProduct());
            model.ClassificationSystem.Add(GetClassificationSystem());

            return model;
        }

        private ClassificationSystem GetClassificationSystem()
        {
            var model = new ClassificationSystem();
            model.ClassificationSystemName = ClassificationSystemNameValues.EClass(new Version(2, 1));
            model.ClassificationSystemFullname = "Classification system full name";
            model.ClassificationSystemVersionDetails = GetClassificationSystemVersionDetails();
            model.ClassificationSystemDescripiton = "Classification system description";
            model.ClassificationSystemPartyIdref = GetClassificationSystemPartyIdref();
            model.ClassificationSystemLevels = 1;
            model.ClassificationSystemLevelNames.Add(GetClassificationSystemLevelName());
            model.ClassificationSystemType = GetClassificationSystemType();
            model.AllowedValues.Add(GetAllowedValue());
            model.Units.Add(GetUnit());
            model.FtGroups.Add(GetFeatureGroup());
            model.ClassificationSystemFeatureTemplates.Add(GetClassificationSystemFeatureTemplate());

            return model;
        }

        private ClassificationSystemFeatureTemplate GetClassificationSystemFeatureTemplate()
        {
            var model = new ClassificationSystemFeatureTemplate();
            model.FtId = "Feature id";
            model.FtName = "Feature name";
            model.FtShortame = "Feature group";
            model.FtDescription = "Feature description";
            model.FtVersion = GetFeatureVersion();
            model.FtGroupIdref = "Feature groupd id";
            model.FtDependencies.Add(GetFeatureDependency());
            model.FeatureContent = GetFeatureContent();

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
            model.FtGroupId = "Feature group id";
            model.FtGroupName = "Feature group name";
            model.FtGroupDescription = "Feature group description";
            model.FtGroupParentIds.Clear();

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
            model.AllowedValueId = "Allowed Value ID";
            model.AllowedValueName = new MultiLingualString("Allowed value", LanguageCodes.eng);
            model.AllowedValueVersion = GetAllowedValueVersion();
            model.AllowedValueShortname = "Allowed Value Short";
            model.AllowedValueDescription = "Allowed Value Description";
            model.AllowedValueSynonyms.Add(new MultiLingualString("Allowed Value long text", LanguageCodes.eng));
            model.AllowedValueSource = GetAllowedValueSource();

            return model;
        }

        private AllowedValueSource GetAllowedValueSource()
        {
            var model = new AllowedValueSource();
            model.SourceName = "External";
            model.SourceUri = "ftp://external/";
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
            model.ProductDetails = GetProductDetails();
            model.ProductOrderDetails = GetProductOrderDetails();
            model.ProductPriceDetails.Add(GetProductPriceDetails());

            return model;
        }

        private ProductPriceDetails GetProductPriceDetails()
        {
            var model = new ProductPriceDetails();

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