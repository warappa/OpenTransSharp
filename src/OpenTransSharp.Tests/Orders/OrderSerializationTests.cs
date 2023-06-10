using BMEcatSharp;
using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Orders
{
    public class OrderSerializationTests
    {
        private readonly TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public OrderSerializationTests()
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

            target = serializerFactory.Create<Order>();
        }

        [Test]
        public void Can_serialize_Order()
        {
            var order = testConfig.Orders.GetOrder();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_Order()
        {
            var order = testConfig.Orders.GetOrder();

            //var serialized = serializer.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_Order_with_UDX_with_no_error()
        {
            var order = testConfig.Orders.GetOrderWithUdx();

            //var serialized = target.Serialize(order);
            //Debug.WriteLine(serialized);

            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_Order_with_UDX_with_error()
        {
            var order = testConfig.Orders.GetOrderWithUdx();
            order.Header.Information.HeaderUdx.Add(new CustomData2 { Name = "Too loooong" });

            //var serialized = target.Serialize(order);
            //Debug.WriteLine(serialized);

            var result = order.Validate(target);
            result.Errors.Any().Should().Be(true);
            result.Errors.First().Value[0].Should().Contain("Too loooong");
        }

        [Test]
        public void Can_deserialize_sample_order()
        {
            var stream = File.Open(@"Orders\sample_order_opentrans_2_1_xml signature.xml", FileMode.Open);

            var order = target.Deserialize<Order>(stream);

            order.Header.Information.HeaderUdx.Count.Should().Be(1);

            var udx = order.Header.Information.HeaderUdx.First();
            udx.GetType().Should().BeAssignableTo<CustomData>();

            var customData = (CustomData)udx;
            customData.Names[0].Should().Be("Name 1");
            customData.Names[1].Should().Be("Name 2");

            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_serialize_Order_with_all_optional_values_empty()
        {
            var order = testConfig.Orders.GetMinimalValidOrder();

            var serialized = target.Serialize(order);
            var validationResult = serialized.ValidateOpenTransDocument(target);

            validationResult.Errors.Should().BeEmpty();
            validationResult.IsValid.Should().BeTrue();
        }

        [Test]
        public void Can_serialize_CustomerOrderReference_with_all_optional_values_empty()
        {
            var subTypeTarget = serializerFactory.Create<CustomerOrderReference>();

            var data = new CustomerOrderReference();

            var serialized = subTypeTarget.Serialize(data);
            var validationResult = serialized.ValidateOpenTransDocument(subTypeTarget);

            validationResult.IsValid.Should().BeTrue();
        }
    }
}
