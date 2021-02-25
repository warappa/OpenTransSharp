using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Microsoft.AspNetCore
{
    public class OpenTransSharpXmlSerializerInputFormatter : XmlSerializerInputFormatter
    {
        private readonly IOpenTransXmlSerializerFactory openTransXmlSerializerFactory;

        public OpenTransSharpXmlSerializerInputFormatter(MvcOptions options, IOpenTransXmlSerializerFactory openTransXmlSerializerFactory)
            : base(options)
        {
            this.openTransXmlSerializerFactory = openTransXmlSerializerFactory ?? throw new ArgumentNullException(nameof(openTransXmlSerializerFactory));
        }

        protected override bool CanReadType(Type type)
        {
            try
            {
                return base.CanReadType(type);
            }
            catch
            {
                return false;
            }
        }

        protected override XmlSerializer CreateSerializer(Type type)
        {
            return openTransXmlSerializerFactory.Create(type);
        }
    }
}
