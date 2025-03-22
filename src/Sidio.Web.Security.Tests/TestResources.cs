using System.Reflection;

namespace Sidio.Web.Security.Tests;

internal static class TestResources
{
    public static string GetFileContents(string filename)
    {
        var assembly = typeof(TestResources).GetTypeInfo().Assembly;
        using var resource =
            assembly.GetManifestResourceStream(filename);
        using var reader = new StreamReader(resource!);
        var result = reader.ReadToEnd();
        return result.Replace("\r\n", "\n").Replace("\r", "\n");
    }
}