using System;
using System.Collections.Generic;

namespace OpenTransSharp.Tests.RemittanceAdvices
{
    internal class RemittanceAdviceTestConfig
    {
        private readonly TestConfig parent;

        public RemittanceAdviceTestConfig(TestConfig parent)
        {
            this.parent = parent;
        }

        public RemittanceAdvice GetRemittanceAdvice()
        {
            var model = new RemittanceAdvice
            {
                Header = GetHeader()
            };

            model.Items.Add(GetRemittanceAdviceItem());

            model.Summary = GetSummary();

            return model;
        }

        private RemittanceAdviceSummary GetSummary()
        {
            var model = new RemittanceAdviceSummary
            {
                TotalItemCount = 1
            };

            return model;
        }

        private RemittanceAdviceItem GetRemittanceAdviceItem()
        {
            var model = new RemittanceAdviceItem
            {
                LineItemId = "1"
            };
            model.InvoiceList.Add(GetRaInvoiceListItem());
            model.TotalAmount = 1;
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }

        private RaInvoiceListItem GetRaInvoiceListItem()
        {
            return new RaInvoiceListItem
            {
                InvoiceReference = parent.GetInvoiceReference(),
                OriginalInvoiceSummary = GetOriginalInvoiceSummary()
            };
        }

        private OriginalInvoiceSummary GetOriginalInvoiceSummary()
        {
            return new OriginalInvoiceSummary
            {
                NetValueGoods = 1,
                TotalAmount = 1,
                TotalTax = parent.GetTotalTax()
            };
        }

        internal RemittanceAdvice GetRemittanceAdviceWithUdx()
        {
            var model = GetRemittanceAdvice();

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

        private RemittanceAdviceHeader GetHeader()
        {
            var header = new RemittanceAdviceHeader
            {
                ControlInformation = parent.GetControlInformation(),

                Information = GetRemittanceAdviceInformation()
            };

            return header;
        }

        private RemittanceAdviceInformation GetRemittanceAdviceInformation()
        {
            var model = new RemittanceAdviceInformation
            {
                Id = "RemittanceAdviceId",
                Date = DateTime.UtcNow
            };
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.deu, true));
            model.Languages.Add(new global::BMEcatSharp.Language(global::BMEcatSharp.LanguageCodes.eng));
            model.MimeRoot = parent.BMEcats.GetMimeRoot();
            model.Parties.AddRange(parent.GetParties());
            model.PayerIdRef = parent.GetPayerIdRef();
            model.RemitteeIdRef = parent.GetRemitteeIdRef();
            model.DocexchangePartiesReference = parent.GetDocexchangePartiesReference();
            model.Currency = "EUR";
            model.MimeInfo = parent.GetMimeInfo();
            model.Remarks.AddRange(parent.GetRemarks());

            return model;
        }
    }
}
