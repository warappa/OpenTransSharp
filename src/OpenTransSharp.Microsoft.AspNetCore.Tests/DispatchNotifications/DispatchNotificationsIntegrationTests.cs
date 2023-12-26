namespace OpenTransSharp.Microsoft.AspNetCore.Tests.DispatchNotifications;

public class DispatchNotificationsIntegrationTests
{
    private WebApplicationFactory<Startup> factory;
    private HttpClient client;

    [SetUp]
    public void Setup()
    {
        factory = new WebApplicationFactory<Startup>();
        client = factory.CreateClient();
    }

    [Test]
    public async Task Can_parse_valid_DispatchNotification_via_stream()
    {
        using var stream = File.OpenRead(@"DispatchNotifications\sample_dispatchnotification_opentrans_2_1.xml");

        var content = new StreamContent(stream);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

        var result = await client.PostAsync("DispatchNotificationValidation/via-stream", content);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task Cannot_parse_invalid_DispatchNotification_via_stream()
    {
        using var stream = File.OpenRead(@"DispatchNotifications\sample_dispatchnotification_opentrans_2_1 - invalid.xml");

        var content = new StreamContent(stream);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

        var result = await client.PostAsync("DispatchNotificationValidation/via-stream", content);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var error = await GetValidationResult(result);
        error.Errors.First().Value[0].Should().Contain("MaxLength");
    }

    [Test]
    public async Task Can_parse_valid_DispatchNotification_via_model_binding()
    {
        using var stream = File.OpenRead(@"DispatchNotifications\sample_dispatchnotification_opentrans_2_1.xml");

        var content = new StreamContent(stream);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

        var result = await client.PostAsync("DispatchNotificationValidation/via-model-binding", content);
        var r = await result.Content.ReadAsStringAsync();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task Cannot_parse_invalid_DispatchNotification_via_model_binding()
    {
        using var stream = File.OpenRead(@"DispatchNotifications\sample_dispatchnotification_opentrans_2_1 - invalid.xml");

        var content = new StreamContent(stream);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

        var result = await client.PostAsync("DispatchNotificationValidation/via-model-binding", content);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var error = await GetValidationResult(result);
        error.Errors.ElementAt(1).Value[0].Should().Contain("MaxLength");
    }

    [Test]
    public async Task Can_parse_valid_DispatchNotification_via_file()
    {
        using var stream = File.OpenRead(@"DispatchNotifications\sample_dispatchnotification_opentrans_2_1.xml");

        var content = new MultipartFormDataContent
        {
            {new StreamContent(stream), "file", @"DispatchNotifications\sample_dispatchnotification_opentrans_2_1.xml"}
        };

        var result = await client.PostAsync("DispatchNotificationValidation/via-file", content);
        var r = await result.Content.ReadAsStringAsync();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task Cannot_parse_invalid_DispatchNotification_via_file()
    {
        using var stream = File.OpenRead(@"DispatchNotifications\sample_dispatchnotification_opentrans_2_1 - invalid.xml");

        var content = new MultipartFormDataContent
        {
            {new StreamContent(stream), "file", @"DispatchNotifications\sample_dispatchnotification_opentrans_2_1 - invalid.xml"}
        };

        var result = await client.PostAsync("DispatchNotificationValidation/via-file", content);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var error = await GetValidationResult(result);
        error.Errors.First().Value[0].Should().Contain("MaxLength");
    }

    private static async Task<ValidationResult> GetValidationResult(HttpResponseMessage result)
    {
        var errorJson = await result.Content.ReadAsStringAsync();
        var error = JsonSerializer.Deserialize<ValidationResult>(errorJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return error;
    }
}
