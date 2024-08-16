using System.Runtime.Serialization;

namespace Sidio.Web.Security.Common;

/// <summary>
/// The enum extensions.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Converts the enum value to its value, taken from the <see cref="EnumMemberAttribute"/>.
    /// </summary>
    /// <param name="enumValue">The enum value.</param>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <returns>A <see cref="string"/>.</returns>
    public static string ToStringValue<T>(this T enumValue)
        where T : Enum
    {
        var enumMemberAttribute =
            ((EnumMemberAttribute[]) typeof(T).GetField(enumValue.ToString())!
                .GetCustomAttributes(typeof(EnumMemberAttribute), true))
            .Single();
        return enumMemberAttribute.Value!;
    }

    internal static bool TryToEnum<T>(this string value, out T? result)
        where T : Enum
    {
        var enumType = typeof(T);
        foreach (var name in Enum.GetNames(enumType))
        {
            var enumMemberAttribute =
                ((EnumMemberAttribute[]) enumType.GetField(name)!.GetCustomAttributes(typeof(EnumMemberAttribute), true))
                .Single();
            if (!enumMemberAttribute.Value!.Equals(value, StringComparison.OrdinalIgnoreCase))
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