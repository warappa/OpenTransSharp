using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.OrderChanges
{
    public class OrderChangeSerializationTests
    {
        private readonly TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public OrderChangeSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
            var options = new OpenTransXmlSerializerOptions();
            options.IncludeUdxTypes = new[]
            {
                typeof(CustomData),
                typeof(CustomData2)
            };
            options.XsdUris = new[] { new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd") };

            serializerFactory = new OpenTransXmlSerializerFactory(options);

            target = serializerFactory.Create<OrderChange>();
        }

        [Test]
        public void Can_serialize_OrderChange()
        {
            var order = testConfig.OrderChanges.GetOrderChange();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_OrderChange()
        {
            var order = testConfig.OrderChanges.GetOrderChange();

            //var serialized = target.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_OrderChange_with_UDX()
        {
            var order = testConfig.OrderChanges.GetOrderChangeWithUdx();

            var serialized = target.Serialize(order);
            Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }
    }
}
