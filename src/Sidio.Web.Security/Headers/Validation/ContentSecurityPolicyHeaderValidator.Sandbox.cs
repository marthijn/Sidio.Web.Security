namespace Sidio.Web.Security.Headers.Validation;

public sealed partial class ContentSecurityPolicyHeaderValidator
{
    internal static readonly string[] AllowedSandboxTokens =
    {
        "allow-downloads",
        "allow-forms",
        "allow-modals",
        "allow-orientation-lock",
        "allow-pointer-lock",
        "allow-popups",
        "allow-popups-to-escape-sandbox",
        "allow-presentation",
        "allow-same-origin",
        "allow-scripts",
        "allow-top-navigation",
        "allow-top-navigation-by-user-activation",
        "allow-storage-access-by-user-activation",
        "allow-top-navigation-to-custom-protocols"
    };
}