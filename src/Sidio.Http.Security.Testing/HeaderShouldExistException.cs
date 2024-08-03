namespace Sidio.Http.Security.Testing;

internal sealed class HeaderShouldExistException : Exception
{
    public HeaderShouldExistException(string headerName)
        : base($"Expected header '{headerName}' to be present, but was not found.")
    {
    }
}