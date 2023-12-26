namespace OpenTransSharp.Tests.ReceiptAcknowledgements;

public class ReceiptAcknowledgementSerializationTests
{
    private readonly TestConfig testConfig;
    private OpenTransXmlSerializerFactory serializerFactory;
    private XmlSerializer target;

    public ReceiptAcknowledgementSerializationTests()
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

        target = serializerFactory.Create<ReceiptAcknowledgement>();
    }

    [Test]
    public void Can_serialize_ReceiptAcknowledgement()
    {
        var order = testConfig.ReceiptAcknowledgements.GetReceiptAcknowledgement();

        Action action = () => target.Serialize(order);
        action.Should().NotThrow();
    }

    [Test]
    public void Can_validate_ReceiptAcknowledgement()
    {
        var order = testConfig.ReceiptAcknowledgements.GetReceiptAcknowledgement();

        //var serialized = target.Serialize(order);
        order.IsValid(target).Should().Be(true);
    }

    [Test]
    public void Can_validate_ReceiptAcknowledgement_with_UDX()
    {
        var order = testConfig.ReceiptAcknowledgements.GetReceiptAcknowledgementWithUdx();

        var serialized = target.Serialize(order);
        Debug.WriteLine(serialized);
        order.IsValid(target).Should().Be(true);
    }
}
