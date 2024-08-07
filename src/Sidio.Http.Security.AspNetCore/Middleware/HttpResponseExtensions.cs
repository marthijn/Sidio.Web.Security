using Microsoft.AspNetCore.Http;
using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.AspNetCore.Middleware;

internal static class HttpResponseExtensions
{
    /// <summary>
    /// Returns <c>true</c> when the header exists, false otherwise.
    /// </summary>
    /// <param name="response">The HTTP response.</param>
    /// <param name="headerName">The header name.</param>
    /// <returns>Returns <c>true</c> when the header exists, false otherwise.</returns>
    public static bool HeaderExists(this HttpResponse response, string headerName) =>
        response.Headers.ContainsKey(headerName);

    /// <summary>
    /// Appends the header to the response if it does not exist.
    /// </summary>
    /// <param name="response">The HTTP response.</param>
    /// <param name="header">The header to append.</param>
    /// <returns>Returns <c>true</c> when the header is added, false otherwise.</returns>
    public static bool AppendHeaderIfNotExists(this HttpResponse response, HttpHeader header)
    {
        if (!response.HeaderExists(header.Name))
        {
            response.Headers.Append(header.Name, header.Value);
            return true;
        }

        return false;
    }
}