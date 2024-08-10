# Sidio.Web.Security

# Goal of this project
The goal of this project is to provide a set of functions that can be used to secure an ASP.NET Core application.
The functions are based on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).

The library is currently in preview and is not yet ready for production use.

## HTTP headers
- Content-Security-Policy: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy)
- X-Content-Type-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options)
- X-Frame-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options)

### Non-standard headers
- X-XSS-Protection: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection)
  - This header is non-standard and is not on a standard track. Do not use it.

## Secure cookies
By using the following code, a secure cookie policy is configured that is based 
on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).
```csharp
app.ApplySecureCookiePolicy();
```