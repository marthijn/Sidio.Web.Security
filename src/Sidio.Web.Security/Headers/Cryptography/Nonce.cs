using System.Diagnostics;
using System.Security.Cryptography;

namespace Sidio.Web.Security.Headers.Cryptography;

/// <summary>
/// The Nonce class represents a cryptographic nonce.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed record Nonce
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Nonce"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="ArgumentException">Thrown when the value is null or empty.</exception>
    public Nonce(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Creates a new nonce with a specified length.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>A <see cref="Nonce"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the length is invalid.</exception>
    public static Nonce Create(int length = 32)
    {
        if (length < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");
        }

        var bytes = new byte[length];
        using var rnd = RandomNumberGenerator.Create();
        rnd.GetBytes(bytes);
        return new Nonce(bytes.Base64UrlEncode());
    }

    /// <inheritdoc />
    public override string ToString() => Value;
}