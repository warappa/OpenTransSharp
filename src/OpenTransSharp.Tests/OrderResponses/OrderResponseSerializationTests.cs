using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.OrderResponses
{
    public class OrderResponseSerializationTests
    {
        private readonly TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public OrderResponseSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
            var options = new OpenTransXmlSerializerOptions
            {
                IncludeUdxTypes = new[]
                {
                    typeof(CustomData),
                    typeof(CustomData2)
                },
                XsdUris = new[] { new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd") }
            };

            serializerFactory = new OpenTransXmlSerializerFactory(options);

            target = serializerFactory.Create<OrderResponse>();
        }

        [Test]
        public void Can_serialize_OrderResponse()
        {
            var order = testConfig.OrderResponses.GetOrderResponse();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_OrderResponse()
        {
            var order = testConfig.OrderResponses.GetOrderResponse();

            //var serialized = target.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_OrderResponse_with_UDX()
        {
            var order = testConfig.OrderResponses.GetOrderResponseWithUdx();

            var serialized = target.Serialize(order);
            Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }
    }
}
