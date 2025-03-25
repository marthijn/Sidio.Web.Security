namespace Sidio.Web.Security.Headers.Options.PermissionsPolicy;

/// <summary>
/// The builder for the Permissions-Policy directive.
/// </summary>
public sealed class DirectiveValueBuilder
{
    private const string Wildcard = "*";

    private readonly HashSet<string> _directives = new();

    /// <summary>
    /// The feature will be allowed for specific origins.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public DirectiveValueBuilder AddOrigin(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(url));
        }

        _directives.Add($"{url}");
        return this;
    }

    /// <summary>
    /// The feature will be allowed in the document, and all nested browsing contexts in the
    /// same origin only.
    /// </summary>
    /// <returns>The <see cref="DirectiveValueBuilder"/> instance.</returns>
    public DirectiveValueBuilder AddSelf()
    {
        _directives.Add("self");
        return this;
    }

    /// <summary>
    /// The feature will be allowed in the document, and all nested browsing contexts
    /// regardless of their origin.
    /// </summary>
    /// <remarks>This function will overwrite all other directives.</remarks>
    /// <returns>The <see cref="DirectiveValueBuilder"/> instance.</returns>
    public DirectiveValueBuilder AllowAll()
    {
        _directives.Add(Wildcard);
        return this;
    }

    /// <summary>
    /// The feature will be disabled in top-level and nested browsing contexts.
    /// </summary>
    /// <remarks>This function will overwrite all other directives. When <see cref="AllowAll"/> is
    /// specified, this feature will be ignored.</remarks>
    /// <returns>The <see cref="DirectiveValueBuilder"/> instance.</returns>
    public DirectiveValueBuilder AllowNone()
    {
        _directives.Add(string.Empty);
        return this;
    }

    /// <summary>
    /// Builds the directives. Returns null when no directives are specified.
    /// </summary>
    /// <returns>The header directive.</returns>
    public string? Build()
    {
        if (_directives.Count == 0)
        {
            return null;
        }

        if (_directives.Contains(Wildcard))
        {
            return Wildcard;
        }

        if (_directives.Contains(string.Empty))
        {
            return "()";
        }

        return $"({string.Join(" ", _directives)})";
    }
}