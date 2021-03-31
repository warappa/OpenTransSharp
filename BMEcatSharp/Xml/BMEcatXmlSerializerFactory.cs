﻿using BMEcatSharp.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Serialization;

namespace BMEcatSharp.Xml
{
    public class BMEcatXmlSerializerFactory : IBMEcatXmlSerializerFactory
    {
        // https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?redirectedfrom=MSDN&view=netframework-4.8#dynamically-generated-assemblies
        protected readonly Hashtable cachedXmlSerializers = new Hashtable();
        protected readonly BMEcatOptions options;
        protected readonly IDictionary<string, Type> udxMappings;

        public BMEcatXmlSerializerFactory(BMEcatOptions options)
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
            ConfigureUdx(mappings, overrides);

            if (options.Serialization.ConfigureXmlAttributeOverrides is not null)
            {
                options.Serialization.ConfigureXmlAttributeOverrides(overrides);
            }

            return new XmlSerializer(type, overrides);
        }

        protected virtual void ConfigureUdx(IDictionary<string, Type> mappings, XmlAttributeOverrides overrides)
        {
            ConfigureUdx<BMEcatHeader>(x => x.UserDefinedExtensions, "USER_DEFINED_EXTENSIONS", mappings, overrides);
            ConfigureUdx<NewCatalogProduct>(x => x.UserDefinedExtensions, "USER_DEFINED_EXTENSIONS", mappings, overrides);
            ConfigureUdx<UpdatePricesProduct>(x => x.UserDefinedExtensions, "USER_DEFINED_EXTENSIONS", mappings, overrides);
            ConfigureUdx<UpdateProductsProduct>(x => x.UserDefinedExtensions, "USER_DEFINED_EXTENSIONS", mappings, overrides);
            ConfigureUdx<CatalogStructure>(x => x.UserDefinedExtensions, "USER_DEFINED_EXTENSIONS", mappings, overrides);
        }

        protected static void ConfigureUdx<T>(Expression<Func<T, object?>> udxProperty, string tagName, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
        {
            ConfigureUdx<T>(udxProperty.GetPropertyName(), tagName, userDefinedExtensionTypeMapping, overrides);
        }

        protected static void ConfigureHeaderUdx<T>(Expression<Func<T, object?>> udxProperty, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
        {
            ConfigureUdx<T>(udxProperty.GetPropertyName(), "HEADER_UDX", userDefinedExtensionTypeMapping, overrides);
        }

        protected static void ConfigureItemUdx<T>(Expression<Func<T, object?>> udxProperty, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
        {
            ConfigureUdx<T>(udxProperty.GetPropertyName(), "ITEM_UDX", userDefinedExtensionTypeMapping, overrides);
        }

        protected static void ConfigureUdx<T>(string headerPropertyName, string headerElementName, IDictionary<string, Type> userDefinedExtensionTypeMapping, XmlAttributeOverrides overrides)
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
