using System.Runtime.Serialization;

namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

public enum Sandbox
{
    [EnumMember(Value = "")]
    None,

    [EnumMember(Value = "allow-downloads")]
    AllowDownloads,

    [EnumMember(Value = "allow-forms")]
    AllowForms,

    [EnumMember(Value = "allow-modals")]
    AllowModals,

    [EnumMember(Value = "allow-orientation-lock")]
    AllowOrientationLock,

    [EnumMember(Value = "allow-pointer-lock")]
    AllowPointerLock,

    [EnumMember(Value = "allow-popups")]
    AllowPopups,

    [EnumMember(Value = "allow-popups-to-escape-sandbox")]
    AllowPopupsToEscapeSandbox,

    [EnumMember(Value = "allow-presentation")]
    AllowPresentation,

    [EnumMember(Value = "allow-same-origin")]
    AllowSameOrigin,

    [EnumMember(Value = "allow-scripts")]
    AllowScripts,

    [EnumMember(Value = "allow-top-navigation")]
    AllowTopNavigation,

    [EnumMember(Value = "allow-top-navigation-by-user-activation")]
    AllowTopNavigationByUserActivation,

    [EnumMember(Value = "allow-storage-access-by-user-activation")]
    AllowStorageAccessByUserActivation,

    [EnumMember(Value = "allow-top-navigation-to-custom-protocols")]
    AllowTopNavigationToCustomProtocols,
}