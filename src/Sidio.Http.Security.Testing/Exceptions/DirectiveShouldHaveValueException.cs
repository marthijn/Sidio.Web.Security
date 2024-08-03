namespace Sidio.Http.Security.Testing.Exceptions;

public sealed class DirectiveShouldHaveValueException : Exception
{
    public DirectiveShouldHaveValueException(string directive, object expectedValue, object actualValue)
        : base($"Expected header directive '{directive}' to have value '{expectedValue}', but '{actualValue}' was found.")
    {
    }
}