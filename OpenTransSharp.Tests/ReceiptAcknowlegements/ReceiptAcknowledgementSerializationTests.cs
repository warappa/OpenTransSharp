using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.ReceiptAcknowledgements
{
    public class ReceiptAcknowledgementSerializationTests
    {
        private TestConfig testConfig;

        public ReceiptAcknowledgementSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_ReceiptAcknowledgement()
        {
            var order = testConfig.ReceiptAcknowledgements.GetReceiptAcknowledgement();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_ReceiptAcknowledgement()
        {
            var order = testConfig.ReceiptAcknowledgements.GetReceiptAcknowledgement();

            var serializer = new XmlSerializer(order.GetType());
            //var serialized = serializer.Serialize(order);
            order.IsValid(serializer).Should().Be(true);
        }
    }
}