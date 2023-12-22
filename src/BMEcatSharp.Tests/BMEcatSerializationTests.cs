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
            options.XsdUris = new[] { new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd") };

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
        public void Can_validate_BMEcat_with_UDX_with_no_error()
        {
            var order = testConfig.BMEcats.GetBMEcatNewCatalogWithUdx();

            //var serialized = target.Serialize(order);
            //Debug.WriteLine(serialized);

            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_BMEcat_with_UDX_with_error()
        {
            var order = testConfig.BMEcats.GetBMEcatNewCatalogWithUdx();
            order.Header.UserDefinedExtensions.Add(new CustomData2 { Name = "Too looooong" });

            //var serialized = target.Serialize(order);
            //Debug.WriteLine(serialized);

            var result = order.Validate(target);
            result.Errors.Any().Should().Be(true);
            result.Errors.First().Value[0].Should().Contain("Too looooong");
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

        [Test]
        public void Can_deserialize_BMEcat_with_multiple_catalog_languages()
        {
            var stream = File.Open(@"bmecat-sample.xml", FileMode.Open);

            var document = target.Deserialize<BMEcatDocument>(stream);

            var catalog = document.Header.Catalog;
            catalog.Languages.Count.Should().Be(2);
            var language1 = catalog.Languages[0];
            var language2 = catalog.Languages[1];

            language1.Value.Should().Be("eng");
            language1.Default.Should().Be(true);

            language2.Value.Should().Be("deu");

            document.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_serialize_ClassificationGroupFeatureTemplate_with_all_optional_values_empty()
        {
            var subTypeTarget = serializerFactory.Create<ClassificationGroupFeatureTemplate>();

            var data = new ClassificationGroupFeatureTemplate
            {
                FeatureIdref = "featureIdref"
            };
            var serialized = subTypeTarget.Serialize(data);
            var validationResult = serialized.ValidateBMECatDocument(subTypeTarget);

            validationResult.IsValid.Should().BeTrue();
        }

        [Test]
        public void Ticket14_Can_use_multiple_emails_in_party_contact_data()
        {
            var stream = File.Open(@"bmecat-sample.xml", FileMode.Open);

            var order = target.Deserialize<BMEcatDocument>(stream);

            var generalEmails = order.Header.Parties[0].Address.Emails;
            generalEmails.Count.Should().Be(2);
            var generalEmail = generalEmails[0].EmailAddress;
            var generalPublicKeys = generalEmails[0].PublicKeys;

            var generalEmail2 = generalEmails[1].EmailAddress;
            var generalPublicKeys2 = generalEmails[1].PublicKeys;

            generalEmail.Should().Be("general-mail");
            generalPublicKeys[0].Type.Should().Be("c");
            generalPublicKeys[0].Value.Should().Be("c2");
            generalPublicKeys[1].Type.Should().Be("d");
            generalPublicKeys[1].Value.Should().Be("d2");

            generalEmail2.Should().Be("general-mail 2");
            generalPublicKeys2[0].Type.Should().Be("c2");
            generalPublicKeys2[0].Value.Should().Be("c22");
        }

        [Test]
        public void Ticket14_Can_use_multiple_emails_in_buyer_data()
        {
            var stream = File.Open(@"bmecat-sample.xml", FileMode.Open);

            var order = target.Deserialize<BMEcatDocument>(stream);

            var generalEmails = order.Header.Buyer.Address.Emails;
            generalEmails.Count.Should().Be(2);
            var generalEmail = generalEmails[0].EmailAddress;
            var generalPublicKeys = generalEmails[0].PublicKeys;

            var generalEmail2 = generalEmails[1].EmailAddress;
            var generalPublicKeys2 = generalEmails[1].PublicKeys;

            generalEmail.Should().Be("general-mail");
            generalPublicKeys[0].Type.Should().Be("c");
            generalPublicKeys[0].Value.Should().Be("c2");
            generalPublicKeys[1].Type.Should().Be("d");
            generalPublicKeys[1].Value.Should().Be("d2");

            generalEmail2.Should().Be("general-mail 2");
            generalPublicKeys2[0].Type.Should().Be("c2");
            generalPublicKeys2[0].Value.Should().Be("c22");
        }

        [Test]
        public void Ticket14_Can_use_multiple_emails_in_supplier_data()
        {
            var stream = File.Open(@"bmecat-sample.xml", FileMode.Open);

            var order = target.Deserialize<BMEcatDocument>(stream);

            var generalEmails = order.Header.Supplier.Address.Emails;
            generalEmails.Count.Should().Be(2);
            var generalEmail = generalEmails[0].EmailAddress;
            var generalPublicKeys = generalEmails[0].PublicKeys;

            var generalEmail2 = generalEmails[1].EmailAddress;
            var generalPublicKeys2 = generalEmails[1].PublicKeys;

            generalEmail.Should().Be("general-mail");
            generalPublicKeys[0].Type.Should().Be("c");
            generalPublicKeys[0].Value.Should().Be("c2");
            generalPublicKeys[1].Type.Should().Be("d");
            generalPublicKeys[1].Value.Should().Be("d2");

            generalEmail2.Should().Be("general-mail 2");
            generalPublicKeys2[0].Type.Should().Be("c2");
            generalPublicKeys2[0].Value.Should().Be("c22");
        }
    }
}
