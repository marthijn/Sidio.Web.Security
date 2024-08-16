namespace Sidio.Web.Security.Testing.Headers.Exceptions;

/// <summary>
/// The exception that is thrown when a header should exist.
/// </summary>
public sealed class HeaderShouldExistException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderShouldExistException"/> class.
    /// </summary>
    /// <param name="headerName">The name of the header.</param>
    public HeaderShouldExistException(string headerName)
        : base($"Expected header '{headerName}' to be present, but was not found.")
    {
    }
}