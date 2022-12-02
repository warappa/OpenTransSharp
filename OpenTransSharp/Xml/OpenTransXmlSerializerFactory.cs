using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenTransSharp.Xml
{
    public class OpenTransXmlSerializerFactory : BMEcatSharp.Xml.BMEcatXmlSerializerFactory, IOpenTransXmlSerializerFactory
    {
        public OpenTransXmlSerializerFactory(OpenTransXmlSerializerOptions options)
            : base(options)
        {

        }

        protected override void ConfigureUdx(IDictionary<string, Type> mappings, XmlAttributeOverrides overrides)
        {
            base.ConfigureUdx(mappings, overrides);

            ConfigureHeaderUdx<DispatchNotificationInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<DispatchNotificationItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<InvoiceListInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<InvoiceListItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<InvoiceInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<InvoiceItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<OrderChangeInformation>(x => x.HeaderUdx, mappings, overrides);
            // OrderChange uses OrderItem

            ConfigureHeaderUdx<OrderResponseInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<OrderResponseItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<OrderInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<OrderItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<QuotationInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<QuotationItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<ReceiptAcknowledgementInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<ReceiptAcknowledgementItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<RemittanceAdviceInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<RemittanceAdviceItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureHeaderUdx<RequestForQuotationInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<RequestForQuotationItem>(x => x.ItemUdx, mappings, overrides);
        }
    }
}
