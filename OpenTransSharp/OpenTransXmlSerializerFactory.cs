using OpenTransSharp.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class OpenTransXmlSerializerFactory : IOpenTransXmlSerializerFactory
    {
        // https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?redirectedfrom=MSDN&view=netframework-4.8#dynamically-generated-assemblies
        private readonly Hashtable cachedXmlSerializers = new Hashtable();
        private readonly OpenTransOptions options;
        private readonly IDictionary<string, Type> udxMappings;

        public OpenTransXmlSerializerFactory(OpenTransOptions options)
        {
            this.options = options;

            udxMappings = new Dictionary<string, Type>();

            if (options?.Serialization?.IncludeUdxTypes is object)
            {
                foreach (var type in options.Serialization.IncludeUdxTypes)
                {
                    var tagName = $"UDX.{type.Name.ToUpperInvariant()}";
                    var root = type.GetCustomAttribute<XmlRootAttribute>();
                    if (root is object)
                    {
                        tagName = root.ElementName;
                    }

                    udxMappings.Add(tagName, type);
                }
            }
        }

        public XmlSerializer Create<T>()
        {
            return Create(typeof(T));
        }

        public XmlSerializer Create(Type type)
        {
            var serializer = (XmlSerializer)cachedXmlSerializers[type];
            if (serializer == null)
            {
                serializer = CreateInternal(type);

                cachedXmlSerializers[type] = serializer;
            }

            return serializer;
        }

        private XmlSerializer CreateInternal(Type type)
        {
            var mappings = udxMappings;

            var overrides = new XmlAttributeOverrides();

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

            ConfigureHeaderUdx<RfqInformation>(x => x.HeaderUdx, mappings, overrides);
            ConfigureItemUdx<RfqItem>(x => x.ItemUdx, mappings, overrides);

            ConfigureUdx<BMEcatHeader>(x => x.UserDefinedExtensions, "USER_DEFINED_EXTENSIONS", mappings, overrides);

            if (options.Serialization.ConfigureOverrides is not null)
            {
                options.Serialization.ConfigureOverrides(overrides);
            }

            return new XmlSerializer(type, overrides);
        }

        private static void ConfigureUdx<T>(Expression<Func<T, object?>> udxProperty, string tagName, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
        {
            ConfigureUdx<T>(udxProperty.GetPropertyName(), tagName, userDefinedExtensionTypeMapping, overrides);
        }

        private static void ConfigureHeaderUdx<T>(Expression<Func<T, object?>> udxProperty, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
        {
            ConfigureUdx<T>(udxProperty.GetPropertyName(), "HEADER_UDX", userDefinedExtensionTypeMapping, overrides);
        }

        private static void ConfigureItemUdx<T>(Expression<Func<T, object?>> udxProperty, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
        {
            ConfigureUdx<T>(udxProperty.GetPropertyName(), "ITEM_UDX", userDefinedExtensionTypeMapping, overrides);
        }

        private static void ConfigureUdx<T>(string headerPropertyName, string headerElementName, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
        {
            var attributes = new XmlAttributes();
            attributes.XmlArray = new XmlArrayAttribute(headerElementName);

            foreach (var mapping in userDefinedExtensionTypeMapping)
            {
                attributes.XmlArrayItems.Add(new XmlArrayItemAttribute(mapping.Key, mapping.Value));
            }

            overrides.Add(typeof(T), headerPropertyName, attributes);
        }
    }
}
