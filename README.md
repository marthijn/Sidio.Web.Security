# ASP.NET Core web security

# Goal of this project
The goal of this project is to provide a set of services, helper functions and middleware that can be used to secure an ASP.NET Core application.
All features are based on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).

__Note:__

The packages are currently in preview and is not yet ready for production use. During the preview phase,
breaking changes may be introduced. Extensive documentation is also still being worked on.

# Packages
## Sidio.Web.Security.AspNetCore
[Sidio.Web.Security.AspNetCore](https://www.nuget.org/packages/Sidio.Web.Security.AspNetCore/) provides the ASP.NET Core services and middleware. The project targets .NET 8.0 and higher.

[![build](https://github.com/marthijn/Sidio.Web.Security/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Web.Security/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Sidio.Web.Security.AspNetCore)](https://www.nuget.org/packages/Sidio.Web.Security.AspNetCore/)

## Sidio.Web.Security.Testing
[Sidio.Web.Security.Testing](https://www.nuget.org/packages/Sidio.Web.Security.AspNetCore.Mvc/) provides testing 
functionality that can be used to verify that the security headers are set correctly.

[![build](https://github.com/marthijn/Sidio.Web.Security/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Web.Security/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Sidio.Web.Security.Testing)](https://www.nuget.org/packages/Sidio.Web.Security.Testing/)

## .NET Framework support: Sidio.Web.Security
[Sidio.Web.Security](https://www.nuget.org/packages/Sidio.Web.Security/) provides the core functionality. Can be used in projects targeting .NET Standard 2.0.
It is useful to use this package if .NET Framework is still in use. Otherwise, use [Sidio.Web.Security.AspNetCore](https://www.nuget.org/packages/Sidio.Web.Security.AspNetCore/).
Note that this package does not contain the middleware and services that are provided by the ASP.NET Core package. Feel free to make a contribution to this project or a fork
targeting .NET Framework.

[![build](https://github.com/marthijn/Sidio.Web.Security/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Web.Security/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Sidio.Web.Security)](https://www.nuget.org/packages/Sidio.Web.Security/)

# HTTP headers
- Content-Security-Policy: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy)
- Referrer-Policy: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy)
- Report-To: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Report-To)
- X-Content-Type-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options)
- X-Frame-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options)

## Non-standard headers
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
Create an action named `Report` in the `HomeController`:
```csharp
[HttpPost]
public IActionResult Report([FromBody] Reports model)
{
    _logger.LogWarning("Report sent from browser: {Report}", JsonSerializer.Serialize(model));
    return Ok();
}
```

# Secure cookies
By using the following code, a secure cookie policy is configured that is based 
on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).
```csharp
app.UseSecureCookiePolicy();
```

# Testing
_todo_