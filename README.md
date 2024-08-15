# Sidio.Web.Security

# Goal of this project
The goal of this project is to provide a set of functions that can be used to secure an ASP.NET Core application.
The functions are based on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).

The library is currently in preview and is not yet ready for production use.

# Installation
Get the packages on NuGet:
- [Sidio.Web.Security](https://www.nuget.org/packages/Sidio.Web.Security/): provides the core functionality. Can be used in .NET Standard 2.0 projects.
- [Sidio.Web.Security.AspNetCore](https://www.nuget.org/packages/Sidio.Web.Security.AspNetCore/): provides the ASP.NET Core middleware.
- [Sidio.Web.Security.Testing](https://www.nuget.org/packages/Sidio.Web.Security.AspNetCore.Mvc/): provides testing functionality.

## HTTP headers
- Content-Security-Policy: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy)
- Referrer-Policy: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy)
- X-Content-Type-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options)
- X-Frame-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options)

### Non-standard headers
- X-XSS-Protection: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection)
  - This header is non-standard and is not on a standard track. Do not use it.

## Example
```csharp
builder.Services
    .AddContentSecurityPolicy();
```

```csharp
app.UseXFrameOptions();
app.UseXContentTypeOptions();
app.UseStrictTransportSecurity();
app.UseContentSecurityPolicy(
    (services, b) =>
    {
        b.AddDefaultSrc(x => x.AllowSelf());
        b.AddScriptSrc(x => x.AddNonce(services).AllowUnsafeInline().AllowUrl("https://cdn.example.com"));
        b.AddStyleSrc(x => x.AddNonce(services));
    });
```

## Reporting API
The reporting API can be used to report violations of the Content Security Policy. Add the following headers:
```csharp
app.UseContentSecurityPolicy(
    (services, b) =>
    {
        // ...
        b.AddReportTo("csp-report");
    });

app.UseReportTo(
    new ReportToHeaderOptions
    {
        Groups =
        [
            new("csp-report", "/Home/Report")
        ],
    });
```
Create an action in a controller that will receive the reports:
```csharp
[HttpPost]
public IActionResult Report([FromBody] Reports model)
{
    _logger.LogWarning("Report sent from browser: {Report}", JsonSerializer.Serialize(model));
    return Ok();
}
```

## Secure cookies
By using the following code, a secure cookie policy is configured that is based 
on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).
```csharp
app.UseSecureCookiePolicy();
```

# Testing