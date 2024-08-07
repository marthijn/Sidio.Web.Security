# Sidio.Web.Security

# Goal of this project
The goal of this project is to provide a set of classes that can be used to secure an ASP.NET Core application.
The classes are based on the [Mozilla Web Security Guidelines](https://infosec.mozilla.org/guidelines/web_security).

The library is currently in preview and is not yet ready for production use.

## Headers
- X-Content-Type-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options)
- X-Frame-Options: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options)

### Non-standard headers
- X-XSS-Protection: [Mozilla docs](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection)
  - This header is non-standard and is not on a standard track. Do not use it.