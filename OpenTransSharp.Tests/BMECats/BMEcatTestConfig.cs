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