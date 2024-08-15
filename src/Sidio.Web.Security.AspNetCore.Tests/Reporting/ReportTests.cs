using System.Text.Json;
using Sidio.Web.Security.AspNetCore.Reporting;

namespace Sidio.Web.Security.AspNetCore.Tests.Reporting;

public sealed class ReportTests
{
    [Fact]
    public void Deserialize_GivenJson_ReturnsReports()
    {
        // arrange
        const string Json = "[{\n  \"type\": \"security-violation\",\n  \"age\": 10,\n  \"url\": \"https://example.com/vulnerable-page/\",\n  \"user_agent\": \"Mozilla/5.0 (X11; Linux x86_64; rv:60.0) Gecko/20100101 Firefox/60.0\",\n  \"body\": {\n    \"blocked\": \"https://evil.com/evil.js\",\n    \"policy\": \"bad-behavior 'none'\",\n    \"status\": 200,\n    \"referrer\": \"https://evil.com/\"\n  }\n}, {\n  \"type\": \"certificate-issue\",\n  \"age\": 32,\n  \"url\": \"https://www.example.com/\",\n  \"user_agent\": \"Mozilla/5.0 (X11; Linux x86_64; rv:60.0) Gecko/20100101 Firefox/60.0\",\n  \"body\": {\n    \"date-time\": \"2014-04-06T13:00:50Z\",\n    \"hostname\": \"www.example.com\",\n    \"port\": 443,\n    \"effective-expiration-date\": \"2014-05-01T12:40:50Z\",\n    \"served-certificate-chain\": [\"test\"]\n  }\n}, {\n  \"type\": \"cpu-on-fire\",\n  \"age\": 29,\n  \"url\": \"https://example.com/thing.js\",\n  \"user_agent\": \"Mozilla/5.0 (X11; Linux x86_64; rv:60.0) Gecko/20100101 Firefox/60.0\",\n  \"body\": {\n    \"temperature\": 614.0\n  }\n}]";

        // act
        var result = JsonSerializer.Deserialize<Reports>(Json);

        // assert
        result.Should().NotBeNull();
        result!.Count.Should().Be(3);

        var firstReport = result[0];
        firstReport.Type.Should().Be("security-violation");
        firstReport.Age.Should().Be(10);
        firstReport.Url.Should().Be("https://example.com/vulnerable-page/");
        firstReport.UserAgent.Should().Be("Mozilla/5.0 (X11; Linux x86_64; rv:60.0) Gecko/20100101 Firefox/60.0");
        firstReport.Body.Should().NotBeNull();
        firstReport.Body!.Count.Should().Be(4);
        firstReport.Body["blocked"].GetString().Should().Be("https://evil.com/evil.js");
        firstReport.Body["policy"].GetString().Should().Be("bad-behavior 'none'");
        firstReport.Body["status"].GetInt32().Should().Be(200);
        firstReport.Body["referrer"].GetString().Should().Be("https://evil.com/");

    }
}