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

        public BMEcat GetBMEcat()
        {
            var model = new BMEcat();

            model.Header = GetHeader();
            model.NewCatalog = GetNewCatalog();


            return model;
        }

        public BMEcat GetBMEcatWithUdx()
        {
            var model = GetBMEcat();

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

            return model;
        }
    }
}