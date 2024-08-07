using System.Security.Cryptography;

namespace Sidio.Web.Security.Headers.Cryptography;

public sealed record Nonce
{
    public Nonce(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    public string Value { get; }

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
}