namespace Sidio.Web.Security.Testing.Exceptions;

/// <summary>
/// The exception that is thrown when a directive should have a specific value.
/// </summary>
public sealed class DirectiveShouldHaveValueException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DirectiveShouldHaveValueException"/> class.
    /// </summary>
    /// <param name="directive">The directive.</param>
    /// <param name="expectedValue">The expected value.</param>
    /// <param name="actualValue">The actual value.</param>
    public DirectiveShouldHaveValueException(string directive, object expectedValue, object actualValue)
        : base($"Expected header directive '{directive}' to have value '{expectedValue}', but '{actualValue}' was found.")
    {
    }
}