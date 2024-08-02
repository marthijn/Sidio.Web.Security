namespace Sidio.Http.Security.Testing;

internal sealed class HeaderShouldExistException : Exception
{
    public HeaderShouldExistException(string headerName)
        : base($"The header '{headerName}' should exist.")
    {
    }
}