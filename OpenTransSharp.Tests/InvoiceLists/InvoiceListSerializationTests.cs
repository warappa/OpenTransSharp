using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.InvoiceLists
{
    public class InvoiceListSerializationTests
    {
        private TestConfig testConfig;

        public InvoiceListSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_InvoiceList()
        {
            var order = testConfig.InvoiceLists.GetInvoiceList();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_InvoiceList()
        {
            var order = testConfig.InvoiceLists.GetInvoiceList();

            var serializer = new XmlSerializer(order.GetType());
            //var serialized = serializer.Serialize(order);
            order.IsValid(serializer).Should().Be(true);
        }
    }
}