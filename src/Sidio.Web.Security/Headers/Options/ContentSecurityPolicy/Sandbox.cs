using System.Runtime.Serialization;

namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The sandbox directive enables a sandbox for the requested resource.
/// </summary>
public enum Sandbox
{
    /// <summary>
    /// The default value.
    /// </summary>
    [EnumMember(Value = "")]
    Default,

    /// <summary>
    /// Allow downloading files.
    /// </summary>
    [EnumMember(Value = "allow-downloads")]
    AllowDownloads,

    /// <summary>
    /// Allows the page to submit forms.
    /// </summary>
    [EnumMember(Value = "allow-forms")]
    AllowForms,

    /// <summary>
    /// Allows the page to open modal windows.
    /// </summary>
    [EnumMember(Value = "allow-modals")]
    AllowModals,

    /// <summary>
    /// Lets the resource lock the screen orientation.
    /// </summary>
    [EnumMember(Value = "allow-orientation-lock")]
    AllowOrientationLock,

    /// <summary>
    /// Allows the page to use the pointer lock API.
    /// </summary>
    [EnumMember(Value = "allow-pointer-lock")]
    AllowPointerLock,

    /// <summary>
    /// Allows popups.
    /// </summary>
    [EnumMember(Value = "allow-popups")]
    AllowPopups,

    /// <summary>
    /// Allows a sandboxed document to open new windows without forcing the sandboxing flags upon them.
    /// </summary>
    [EnumMember(Value = "allow-popups-to-escape-sandbox")]
    AllowPopupsToEscapeSandbox,

    /// <summary>
    /// Allows embedders to have control over whether an iframe can start a presentation session.
    /// </summary>
    [EnumMember(Value = "allow-presentation")]
    AllowPresentation,

    /// <summary>
    /// If this token is not used, the resource is treated as being from a special origin that always fails the same-origin policy.
    /// </summary>
    [EnumMember(Value = "allow-same-origin")]
    AllowSameOrigin,

    /// <summary>
    /// Allows the page to run scripts (but not create pop-up windows). If this keyword is not used, this operation is not allowed.
    /// </summary>
    [EnumMember(Value = "allow-scripts")]
    AllowScripts,

    /// <summary>
    /// Lets the resource navigate the top-level browsing context (the one named _top).
    /// </summary>
    [EnumMember(Value = "allow-top-navigation")]
    AllowTopNavigation,

    /// <summary>
    /// Lets the resource navigate the top-level browsing context, but only if initiated by a user gesture.
    /// </summary>
    [EnumMember(Value = "allow-top-navigation-by-user-activation")]
    AllowTopNavigationByUserActivation,

    /// <summary>
    /// Lets the resource request access to the parent's storage capabilities with the Storage Access API.
    /// </summary>
    [EnumMember(Value = "allow-storage-access-by-user-activation")]
    AllowStorageAccessByUserActivation,

    /// <summary>
    /// Allows navigations to non-http protocols built into browser or registered by a website.
    /// </summary>
    [EnumMember(Value = "allow-top-navigation-to-custom-protocols")]
    AllowTopNavigationToCustomProtocols,
}