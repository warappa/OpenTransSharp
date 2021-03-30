using BMEcatSharp;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Xml.Serialization;
using OpenTransSharp.Validation;

namespace OpenTransSharp.Tests.BMEcats
{
    public class BMEcatSerializationTests
    {
        private TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public BMEcatSerializationTests()
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

            var serialized = target.Serialize(order);
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
    }
}