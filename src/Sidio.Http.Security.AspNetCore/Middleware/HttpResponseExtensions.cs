using Microsoft.AspNetCore.Http;
using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.AspNetCore.Middleware;

internal static class HttpResponseExtensions
{
    public static bool HeaderExists(this HttpResponse response, string headerName) =>
        response.Headers.ContainsKey(headerName);

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