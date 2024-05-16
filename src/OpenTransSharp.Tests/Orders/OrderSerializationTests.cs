using BMEcatSharp;
using System.Linq;

namespace OpenTransSharp.Tests.Orders;

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
        var options = new OpenTransXmlSerializerOptions
        {
            IncludeUdxTypes =
            [
                typeof(CustomData),
                typeof(CustomData2)
            ],
            XsdUris = [new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd")]
        };

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

    [Test]
    public void Ticket17_Directly_set_Address_Emails_property_is_serialized_even_if_not_accessed_before_serialization()
    {
        string[] emailAddresses = ["email@example.com", "email.2@example.com"];
        var address = new Address
        {
            Emails = emailAddresses.Select(s => new Email
            {
                EmailAddress = s
            }).ToList()
        };

        var options = new OpenTransXmlSerializerOptions();
        var serializerFactory = new OpenTransXmlSerializerFactory(options);

        var serializer = serializerFactory.Create<Address>();

        var serializedContent = serializer.Serialize(address);

        serializedContent.Should().Contain("email@example.com");
        serializedContent.Should().Contain("email.2@example.com");
    }

    [Test]
    public void Ticket19_deserialized_and_immediately_serialized_address_keeps_email_values()
    {   
        var options = new OpenTransXmlSerializerOptions();
        var serializerFactory = new OpenTransXmlSerializerFactory(options);

        var serializer = serializerFactory.Create<Address>();

        var addressString = """
            <ADDRESS xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.opentrans.org/XMLSchema/2.1"
                xmlns:bmecat="http://www.bmecat.org/bmecat/2005">
            	<CONTACT_DETAILS>
            		<bmecat:CONTACT_ID>general-id</bmecat:CONTACT_ID>
            		<bmecat:CONTACT_NAME>general-name</bmecat:CONTACT_NAME>
            	</CONTACT_DETAILS>
            	<bmecat:EMAIL>general-mail</bmecat:EMAIL>
            </ADDRESS>
            """;
        var deserialized = serializer.Deserialize<Address>(addressString);

        var serializedContent = serializer.Serialize(deserialized);

        serializedContent.Should().Contain("general-mail");
    }

    [Test]
    public void Ticket19_deserialized_and_immediately_serialized_address_keeps_email_values_while_accessing_emails_inbetween()
    {
        var options = new OpenTransXmlSerializerOptions();
        var serializerFactory = new OpenTransXmlSerializerFactory(options);

        var serializer = serializerFactory.Create<Address>();

        var addressString = """
            <ADDRESS xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.opentrans.org/XMLSchema/2.1"
                xmlns:bmecat="http://www.bmecat.org/bmecat/2005">
            	<CONTACT_DETAILS>
            		<bmecat:CONTACT_ID>general-id</bmecat:CONTACT_ID>
            		<bmecat:CONTACT_NAME>general-name</bmecat:CONTACT_NAME>
            	</CONTACT_DETAILS>
            	<bmecat:EMAIL>general-mail</bmecat:EMAIL>
            </ADDRESS>
            """;
        var deserialized = serializer.Deserialize<Address>(addressString);

        var emails = deserialized.Emails;

        var serializedContent = serializer.Serialize(deserialized);

        serializedContent.Should().Contain("general-mail");
    }

    [Test]
    public void Ticket19_deserialized_and_immediately_serialized_address_keeps_email_values_while_mutating_emails_inbetween()
    {
        var options = new OpenTransXmlSerializerOptions();
        var serializerFactory = new OpenTransXmlSerializerFactory(options);

        var serializer = serializerFactory.Create<Address>();

        var addressString = """
            <ADDRESS xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.opentrans.org/XMLSchema/2.1"
                xmlns:bmecat="http://www.bmecat.org/bmecat/2005">
            	<CONTACT_DETAILS>
            		<bmecat:CONTACT_ID>general-id</bmecat:CONTACT_ID>
            		<bmecat:CONTACT_NAME>general-name</bmecat:CONTACT_NAME>
            	</CONTACT_DETAILS>
            	<bmecat:EMAIL>general-mail</bmecat:EMAIL>
            </ADDRESS>
            """;
        var deserialized = serializer.Deserialize<Address>(addressString);

        var emails = deserialized.Emails;
        emails.Clear();
        emails.Add(new Email("another-email@gmail.com"));

        var serializedContent = serializer.Serialize(deserialized);

        serializedContent.Should().NotContain("general-mail");
        serializedContent.Should().Contain("another-email@gmail.com");
    }
}
