namespace Sidio.Web.Security.Testing.Exceptions;

public sealed class HeaderShouldExistException : Exception
{
    public HeaderShouldExistException(string headerName)
        : base($"Expected header '{headerName}' to be present, but was not found.")
    {
    }
}