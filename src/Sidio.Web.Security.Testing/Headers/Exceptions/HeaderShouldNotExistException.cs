namespace Sidio.Web.Security.Testing.Headers.Exceptions;

/// <summary>
/// The exception that is thrown when a header should not exist.
/// </summary>
public sealed class HeaderShouldNotExistException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderShouldNotExistException"/> class.
    /// </summary>
    /// <param name="headerName">The name of the header.</param>
    public HeaderShouldNotExistException(string headerName) : base(
        $"Expected header '{headerName}' to not be present, but was found.")
    {
    }
}