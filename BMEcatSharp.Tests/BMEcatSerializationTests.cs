using BMEcatSharp;
using BMEcatSharp.Validation;
using BMEcatSharp.Xml;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BMEcatSharp.Tests
{
    public class BMEcatSerializationTests
    {
        private readonly TestConfig testConfig;

        private BMEcatXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public BMEcatSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
            var options = new BMEcatXmlSerializerOptions();
            options.IncludeUdxTypes = new[]
            {
                typeof(CustomData),
                typeof(CustomData2)
            };

            serializerFactory = new BMEcatXmlSerializerFactory(options);

            target = serializerFactory.Create<BMEcatDocument>();
        }

        [Test]
        public void Can_serialize_BMEcatNewCatalog()
        {
            var order = testConfig.BMEcats.GetBMEcatNewCatalog();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_serialize_BMEcatUpdateProducts()
        {
            var order = testConfig.BMEcats.GetBMEcatUpdateProducts();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_serialize_BMEcatUpdatePrices()
        {
            var order = testConfig.BMEcats.GetBMEcatUpdatePrices();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_BMEcatNewCatalog()
        {
            var order = testConfig.BMEcats.GetBMEcatNewCatalog();

            //var serialized = target.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_BMEcatUpdateProducts()
        {
            var order = testConfig.BMEcats.GetBMEcatUpdateProducts();

            //var serialized = target.Serialize(order);
            //Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_BMEcatUpdatePrices()
        {
            var order = testConfig.BMEcats.GetBMEcatUpdatePrices();

            //var serialized = target.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_BMEcat_with_UDX()
        {
            var order = testConfig.BMEcats.GetBMEcatNewCatalogWithUdx();

            var serialized = target.Serialize(order);
            Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_deserialize_BMEcat()
        {
            var stream = File.Open(@"bmecat-sample.xml", FileMode.Open);

            var document = target.Deserialize<BMEcatDocument>(stream);

            document.Header.UserDefinedExtensions.Count.Should().Be(1);

            var udx = document.Header.UserDefinedExtensions.First();
            udx.GetType().Should().BeAssignableTo<CustomData>();

            var customData = (CustomData)udx;
            customData.Names[0].Should().Be("Name 1");
            customData.Names[1].Should().Be("Name 2");

            document.IsValid(target).Should().Be(true);
        }
    }
}