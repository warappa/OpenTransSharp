using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.InvoiceLists
{
    internal class InvoiceListTestConfig
    {
        private TestConfig parent;

        public InvoiceListTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public InvoiceList GetInvoiceList()
        {
            var model = new InvoiceList();

            model.Header = GetHeader();

            model.Items.Add(GetInvoiceListItem());

            model.Summary = GetSummary();

            return model;
        }

        internal InvoiceList GetInvoiceListWithUdx()
        {
            var model = GetInvoiceList();

            model.Header.Information.HeaderUdx.Add(new CustomData()
            {
                Names = new List<string>
                {
                    "Name 1",
                    "Name 2"
                }
            });
            model.Header.Information.HeaderUdx.Add(new CustomData2()
            {
                Name = "Name 3"
            });

            model.Items[0].ItemUdx.Add(new CustomData()
            {
                Names = new List<string>
                {
                    "Name 1",
                    "Name 2"
                }
            });
            model.Items[0].ItemUdx.Add(new CustomData2()
            {
                Name = "Name 3"
            });

            return model;
        }

        private InvoiceListSummary GetSummary()
        {
            var model = new InvoiceListSummary();

            model.TotalItemCount = 1;
            model.TotalAmount = 1;
            model.TotalTax = new TotalTax
            {
                TaxDetailsFixes = new List<TaxDetailsFix>
                {
                    new TaxDetailsFix
                    {

                    }
                }
            };

            return model;
        }

        private InvoiceListItem GetInvoiceListItem()
        {
            var model = new InvoiceListItem();

            model.LineItemId = "1";
            model.ILInvoiceList = new ILInvoiceList
            {
                Items = new List<ILInvoiceListItem>
                {
                    new ILInvoiceListItem
                    {
                        InvoiceReference = new InvoiceReference
                        {
                            InvoiceId = "InvoiceId"
                        },
                        NetValueGoods = 1,
                        TotalTax = new TotalTax
                        {
                            TaxDetailsFixes = new List<TaxDetailsFix>
                            {
                                new TaxDetailsFix
                                {

                                }
                            }
                        },
                        TotalAmount = 1
                    }
                }
            };

            model.NetValueGoods = 10;
            model.TotalAmount = 10;
            model.TotalTax = new TotalTax
            {
                TaxDetailsFixes = new List<TaxDetailsFix>
                {
                    new TaxDetailsFix
                    {

                    }
                }
            };

            model.Remarks = new List<Remark>
            {
                new Remark("Be careful", RemarkTypeValues.InvoiceList)
            };

            model.AccountingPeriod = new AccountingPeriod
            {
                AccountingPeriodStartDate = DateTime.UtcNow.AddDays(2),
                AccountingPeriodEndDate = DateTime.UtcNow.AddDays(4),
            };
            model.DeliveryIdref = GetDeliveryIdRef();

            return model;
        }

        private DeliveryIdref GetDeliveryIdRef()
        {
            return new DeliveryIdref("Delivery", PartyTypeValues.PartySpecific);
        }

        private InvoiceListHeader GetHeader()
        {
            var header = new InvoiceListHeader();

            header.ControlInformation = GetControlInformation();

            header.Information = GetInvoiceListInformation();

            return header;
        }

        private InvoiceListInformation GetInvoiceListInformation()
        {
            var model = new InvoiceListInformation();

            model.Currency = "EUR";
            model.DocexchangePartiesReference = new DocexchangePartiesReference
            {
                DocumentIssuerIdref = GetDocumentIssuerIdRef(),
                DocumentRecipientIdrefs = new List<DocumentRecipientIdref>{
                    GetDocumentRecipientIdRef()
                }
            };
            model.AccountingPeriod = new AccountingPeriod
            {
                AccountingPeriodStartDate = DateTime.UtcNow.AddDays(2),
                AccountingPeriodEndDate = DateTime.UtcNow.AddDays(4),
            };
            model.Languages.Add(new Language(LanguageCodes.deu, true));
            model.Languages.Add(new Language(LanguageCodes.eng));
            model.MimeInfo = GetMimeInfo();
            model.MimeRoot = new MultiLingualString("ftp://server/de", LanguageCodes.deu);
            model.InvoiceListDate = DateTime.UtcNow;
            model.InvoiceListId = "InvoiceListId";
            model.Parties = new List<Party>
            {
                GetBuyerParty(),
                GetSupplierParty()
            };
            model.Remarks = new List<Remark>
            {
                new Remark("Handle with care", RemarkTypeValues.Transport),
                new Remark("Ring 4 times", RemarkTypeValues.DeliveryNote)
            };

            return model;
        }

        private Party GetSupplierParty()
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

        private Party GetBuyerParty()
        {
            return new Party
            {
                Roles = new List<PartyRole> { PartyRole.Buyer },
                PartyIds = new List<PartyId>
                {
                    (PartyId)GetBuyerIdRef()
                }
            };
        }

        private SupplierIdref GetSupplierIdRef()
        {
            return new SupplierIdref("Supplier", PartyTypeValues.SupplierSpecific);
        }

        private BuyerIdref GetBuyerIdRef()
        {
            return new BuyerIdref("Buyer", PartyTypeValues.CustomerSpecific);
        }

        private MimeInfo GetMimeInfo()
        {
            var model = new MimeInfo();

            model.Mimes.Add(GetMime());

            return model;
        }

        private static Mime GetMime()
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

        private DocumentRecipientIdref GetDocumentRecipientIdRef()
        {
            return new DocumentRecipientIdref("Unit Test Recipient", PartyTypeValues.PartySpecific);
        }

        private DocumentIssuerIdref GetDocumentIssuerIdRef()
        {
            return new DocumentIssuerIdref("Unit Test Issuer", PartyTypeValues.PartySpecific);
        }

        private DeliveryDate GetDeliveryDate()
        {
            var model = new DeliveryDate();

            model.DeliveryStartDate = DateTime.UtcNow.AddDays(2);
            model.DeliveryEndDate = model.DeliveryStartDate.AddDays(3);
            model.Type = DeliveryDateType.Optional;

            return model;
        }

        private SourcingInformation GetSourcingInformation()
        {
            var model = new SourcingInformation();

            model.CatalogReference = GetCatalogReference();

            return model;
        }

        private static CatalogReference GetCatalogReference()
        {
            return new CatalogReference
            {
                CatalogId = "2021-02",
                CatalogName = new MultiLingualString("Test Catalog 2021", LanguageCodes.eng),
                CatalogVersion = new Version(2, 1)
            };
        }

        private ControlInformation GetControlInformation()
        {
            var controlInformation = new ControlInformation();
            controlInformation.GenerationDate = DateTime.UtcNow;
            controlInformation.GeneratorInfo = "Testing";
            controlInformation.StopAutomaticProcessing = "For unit tests only";

            return controlInformation;
        }
    }
}