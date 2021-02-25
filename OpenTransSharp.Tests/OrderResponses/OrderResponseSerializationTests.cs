using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.OrderResponses
{
    public class OrderResponseSerializationTests
    {
        private TestConfig testConfig;

        public OrderResponseSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_OrderResponse()
        {
            var order = testConfig.OrderResponses.GetOrderResponse();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_OrderResponse()
        {
            var order = testConfig.OrderResponses.GetOrderResponse();

            var serializer = new XmlSerializer(order.GetType());
            //var serialized = serializer.Serialize(order);
            order.IsValid(serializer).Should().Be(true);
        }
    }
}