﻿using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace OpenTransSharp.Internal
{
    internal static class XmlUtils
    {
        public static EmbeddedXmlUrlResolver XmlResolver = new EmbeddedXmlUrlResolver();

        public static XmlReader GetEmbeddedXsd(string resourceName, XmlSchemaSet schemaSet)
        {
            var schemaStream = XmlResolver.GetStream(resourceName);
            var reader = XmlReader.Create(schemaStream, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore,
                CloseInput = true,
                XmlResolver = XmlResolver
            });

            schemaSet.Add(null, reader);

            return reader;
        }

        // https://stackoverflow.com/questions/451950/get-the-xpath-to-an-xelement?noredirect=1&lq=1
        public static string GetAbsoluteXPath(this XAttribute attribute)
        {
            return GetAbsoluteXPath(attribute.Parent) + $"[{attribute.Name.LocalName}]";
        }

        /// <summary>
        /// Get the absolute XPath to a given XElement, including the namespace.
        /// (e.g. "/a:people/b:person[6]/c:name[1]/d:last[1]").
        /// </summary>
        public static string GetAbsoluteXPath(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            static string RelativeXPath(XElement e)
            {
                var index = e.IndexPosition();

                var currentNamespace = e.Name.Namespace;

                string name;
                if (currentNamespace == null)
                {
                    name = e.Name.LocalName;
                }
                else
                {
                    var namespacePrefix = e.GetPrefixOfNamespace(currentNamespace);
                    name = namespacePrefix + ":" + e.Name.LocalName;
                }

                // If the element is the root, no index is required
                return (index == -1) ?
                    "/" + name : 
                    string.Format
                    (
                        "/{0}[{1}]",
                        name,
                        index.ToString()
                    );
            }

            var ancestors = element.Ancestors()
                .Select(e => RelativeXPath(e));

            return string.Concat(ancestors.Reverse().ToArray()) +
                   RelativeXPath(element);
        }

        /// <summary>
        /// Get the index of the given XElement relative to its
        /// siblings with identical names. If the given element is
        /// the root, -1 is returned.
        /// </summary>
        /// <param name="element">
        /// The element to get the index of.
        /// </param>
        public static int IndexPosition(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (element.Parent == null)
            {
                return -1;
            }

            var i = 1; // Indexes for nodes start at 1, not 0

            foreach (var sibling in element.Parent.Elements(element.Name))
            {
                if (sibling == element)
                {
                    return i;
                }

                i++;
            }

            throw new InvalidOperationException("element has been removed from its parent.");
        }
    }
}