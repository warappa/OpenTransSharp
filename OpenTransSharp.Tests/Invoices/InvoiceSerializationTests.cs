using FluentAssertions;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Invoices
{
    public class InvoiceSerializationTests
    {
        private TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public InvoiceSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
            var options = new OpenTransOptions();
            options.Serialization.IncludeUdxTypes = new[]
            {
                typeof(CustomData),
                typeof(CustomData2)
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
    }
}