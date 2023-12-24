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

        [Test]
        public void Ticket14_Can_use_multiple_emails_in_address_data()
        {
            var stream = File.Open(@"Orders\sample_order_opentrans_2_1_xml signature.xml", FileMode.Open);

            var order = target.Deserialize<Order>(stream);

            var generalEmails = order.Header.Information.Parties[0].Addresses[0].Emails;
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
        public void Ticket14_Can_use_multiple_emails_in_contact_data()
        {
            var order = testConfig.Orders.GetOrder();

            var generalEmails = order.Header.Information.Parties[0].Addresses[0].Emails;
            var contactEmails = order.Header.Information.Parties[0].Addresses[0].ContactDetails[0].Emails;

            generalEmails.Count.Should().Be(2);
            var generalEmail = generalEmails[0].EmailAddress;
            var generalPublicKeys = generalEmails[0].PublicKeys;

            var generalEmail2 = generalEmails[1].EmailAddress;
            var generalPublicKeys2 = generalEmails[1].PublicKeys;

            generalEmail.Should().Be("mail@example.com");
            generalPublicKeys[0].Type.Should().Be("PGP-6.5.1");
            generalPublicKeys[0].Value.Should().Be("1234");

            generalEmail2.Should().Be("mail.2@example.com");
            generalPublicKeys2[0].Type.Should().Be("etc");
            generalPublicKeys2[0].Value.Should().Be("1234");
            generalPublicKeys2[1].Type.Should().Be("etc2");
            generalPublicKeys2[1].Value.Should().Be("1234");

            var contactEmail1 = contactEmails[0];

            contactEmail1.EmailAddress.Should().Be("mail@example.com");
            contactEmail1.PublicKeys.Count.Should().Be(2);
        }
    }
}
