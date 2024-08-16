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
- Content-Security-Policy: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Content%E2%80%90Security%E2%80%90Policy)
- Referrer-Policy: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Referrer%E2%80%90Policy)
- Report-To: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Report%E2%80%90To)
- X-Content-Type-Options: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/X%E2%80%90Content%E2%80%90Type%E2%80%90Options)
- X-Frame-Options: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/X%E2%80%90Frame%E2%80%90Options)

## Non-standard headers
- X-XSS-Protection: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/X%E2%80%90XSS%E2%80%90Protection)
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
The reporting API can be used to report violations of the Content Security Policy.
Read more in the [wiki docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Reporting-API).

# Secure cookies
By using the following code, a secure cookie policy is configured that is based 
on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).
```csharp
app.UseSecureCookiePolicy();
```

# Testing
_todo_

# License
This project is licensed under the [MIT License](LICENSE).

Texts used in this project (including this readme, the code documentation and wiki pages) may come from, or be based on, the [MDN Web Doc's](https://developer.mozilla.org/en-US/docs/MDN/).
[Attributions and copyright licensing](https://developer.mozilla.org/en-US/docs/MDN/Writing_guidelines/Attrib_copyright_license) by [Mozilla Contributors](https://developer.mozilla.org/en-US/docs/MDN/Community/Roles_teams#contributor) is licensed under [CC-BY-SA 2.5](https://creativecommons.org/licenses/by-sa/2.5/).