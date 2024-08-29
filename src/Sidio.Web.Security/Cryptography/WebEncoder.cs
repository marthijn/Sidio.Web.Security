namespace Sidio.Web.Security.Cryptography;

internal static class WebEncoder
{
    private static readonly char[] Padding = ['='];

    /// <summary>
    /// Returns a web-safe base64 encoded string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A <see cref="string"/>.</returns>
    public static string Base64UrlEncode(this byte[] input)
    {
        var base64 = Convert.ToBase64String(input);
        return base64.TrimEnd(Padding).Replace('/', '_').Replace('+', '-');
    }
}