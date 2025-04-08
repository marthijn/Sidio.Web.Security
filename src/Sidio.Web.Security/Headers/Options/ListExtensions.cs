namespace Sidio.Web.Security.Headers.Options;

internal static class ListExtensions
{
    public static List<string> AddIfNotNull(this List<string> list, string directive, string? value, string separator = " ")
    {
        if (value != null)
        {
            list.Add($"{directive}{separator}{value}");
        }

        return list;
    }

    public static List<string> AddIfTrue(this List<string> list, string directive, bool? value)
    {
        if (value != null && value.Value)
        {
            list.Add(directive);
        }

        return list;
    }
}