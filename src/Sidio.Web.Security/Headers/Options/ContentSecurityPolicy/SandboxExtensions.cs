using System.Runtime.Serialization;

namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The sandbox extensions.
/// </summary>
public static class SandboxExtensions
{
    /// <summary>
    /// Converts the sandbox to its value.
    /// </summary>
    /// <param name="sandbox">The sandbox value.</param>
    /// <returns>A <see cref="string"/>.</returns>
    public static string ToValue(this Sandbox sandbox)
    {
        var enumMemberAttribute =
            ((EnumMemberAttribute[]) typeof(Sandbox).GetField(sandbox.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), true))
            .Single();
        return enumMemberAttribute.Value;
    }

    internal static bool TryToEnum<T>(this string value, out T? result)
        where T : Enum
    {
        var enumType = typeof(T);
        foreach (var name in Enum.GetNames(enumType))
        {
            var enumMemberAttribute =
                ((EnumMemberAttribute[]) enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true))
                .Single();
            if (!enumMemberAttribute.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            result = (T)Enum.Parse(enumType, name);
            return true;
        }

        result = default;
        return false;
    }
}