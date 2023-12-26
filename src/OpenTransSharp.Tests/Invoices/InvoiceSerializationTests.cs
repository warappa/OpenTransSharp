using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Invoices
{
    public class InvoiceSerializationTests
    {
        private readonly TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public InvoiceSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
            var options = new OpenTransXmlSerializerOptions
            {
                IncludeUdxTypes =
                [
                    typeof(CustomData),
                    typeof(CustomData2)
                ],
                XsdUris = [new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd")]
            };

            serializerFactory = new OpenTransXmlSerializerFactory(options);

            target = serializerFactory.Create<Invoice>();
        }

        [Test]
        public void Can_serialize_Invoice()
        {
            var order = testConfig.Invoices.GetInvoice();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_Invoice()
        {
            var order = testConfig.Invoices.GetInvoice();

            //var serialized = target.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_Invoice_with_UDX()
        {
            var order = testConfig.Invoices.GetInvoiceWithUdx();

            var serialized = target.Serialize(order);
            Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_deserialize_sample_Invoice()
        {
            var stream = File.Open(@"Invoices\sample_invoice_opentrans_2_1.xml", FileMode.Open);

            var invoice = target.Deserialize<Invoice>(stream);

            invoice.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_deserialize_sample_Invoice2()
        {
            var stream = File.Open(@"Invoices\sample_invoice_opentrans_2_1_xml signature.xml", FileMode.Open);

            var invoice = target.Deserialize<Invoice>(stream);

            invoice.IsValid(target).Should().Be(true);
        }
    }
}
