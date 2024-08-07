namespace Sidio.Web.Security.Testing.Exceptions;

public sealed class HeaderShouldNotExistException : Exception
{
    public HeaderShouldNotExistException(string headerName) : base(
        $"Expected header '{headerName}' to not be present, but was found.")
    {
    }
}