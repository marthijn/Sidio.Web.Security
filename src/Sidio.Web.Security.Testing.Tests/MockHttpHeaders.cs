using System.Net.Http.Headers;
using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Testing.Tests;

internal sealed class MockHttpHeaders : HttpHeaders
{
    public MockHttpHeaders()
    {
    }

    public MockHttpHeaders(HttpHeader header)
    {
        Add(header.Name, header.Value);
    }

    public MockHttpHeaders(HttpHeaders headers)
    {
        foreach (var header in headers)
        {
            foreach (var value in header.Value)
            {
                Add(header.Key, value);
            }
        }
    }
}