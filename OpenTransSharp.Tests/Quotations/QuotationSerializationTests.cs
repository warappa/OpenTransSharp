using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Quotations
{
    public class QuotationSerializationTests
    {
        private TestConfig testConfig;

        public QuotationSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_Quotation()
        {
            var order = testConfig.Quotations.GetQuotation();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }
    }
}