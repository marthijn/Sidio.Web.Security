# ASP.NET Core web security

# Goal of this project
The goal of this project is to provide a set of services, helper functions and middleware that can be used to secure an ASP.NET Core application.
All features are based on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).

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

## Code quality
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=marthijn_Sidio.Web.Security&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=marthijn_Sidio.Web.Security)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=marthijn_Sidio.Web.Security&metric=coverage)](https://sonarcloud.io/summary/new_code?id=marthijn_Sidio.Web.Security)

# Documentation
See the [wiki docs](https://github.com/marthijn/Sidio.Web.Security/wiki/HTTP-headers).

# Features
## HTTP headers
- Content-Security-Policy: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Content%E2%80%90Security%E2%80%90Policy)
- Referrer-Policy: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Referrer%E2%80%90Policy)
- Report-To: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Report%E2%80%90To)
- Strict-Transport-Security (HSTS): [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Strict%E2%80%90Transport%E2%80%90Security-(HSTS))
- X-Content-Type-Options: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/X%E2%80%90Content%E2%80%90Type%E2%80%90Options)
- X-Frame-Options: [docs](https://github.com/marthijn/Sidio.Web.Security/wiki/X%E2%80%90Frame%E2%80%90Options)

Read more in the [wiki docs](https://github.com/marthijn/Sidio.Web.Security/wiki/HTTP-headers).

### Example
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

See [getting started](https://github.com/marthijn/Sidio.Web.Security/wiki/Getting-started) and
the [recommended ASP.NET Core configuration](https://github.com/marthijn/Sidio.Web.Security/wiki/Recommended-configuration-for-ASP.NET-Core).

### Reporting API
The reporting API can be used to report violations of the Content Security Policy.
Read more in the [wiki docs](https://github.com/marthijn/Sidio.Web.Security/wiki/Reporting-API).

## Default policies
- A [secure cookie policy](https://github.com/marthijn/Sidio.Web.Security/wiki/Cookies)

## Testing
The package [Sidio.Web.Security.Testing](https://www.nuget.org/packages/Sidio.Web.Security.AspNetCore.Mvc/) provides a set of functions that can be used to test
the security configuration of an ASP.Net Core application. [Read more](https://github.com/marthijn/Sidio.Web.Security/wiki/Testing).

## Upgrade to version 2.x
In version 2.x the `IDistributedCache` is replaced by the `HybridCache`:
- `SubresourceIntegrityOptions`: the property `AbsoluteExpiration` is removed and replaced by `LocalCacheExpiration` and `CacheExpiration`

# Contributions
Contributions are welcome! Feel free to create a pull request or an issue.

# License
This project is licensed under the [MIT License](LICENSE).

Texts used in this project (including this readme, the code documentation and wiki pages) may come from, or be based on, the [MDN Web Doc's](https://developer.mozilla.org/en-US/docs/MDN/).
Documentation by [Mozilla Contributors](https://developer.mozilla.org/en-US/docs/MDN/Community/Roles_teams#contributor) is licensed under [CC-BY-SA 2.5](https://creativecommons.org/licenses/by-sa/2.5/).