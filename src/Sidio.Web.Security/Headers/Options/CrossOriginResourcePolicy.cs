using System.Runtime.Serialization;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Cross Origin Resource Policy directives.
/// </summary>
public enum CrossOriginResourcePolicy
{
    /// <summary>
    /// Isolates the browsing context such that it is available only to documents that belong to the same site.
    /// </summary>
    [EnumMember(Value = "same-site")]
    SameSite,

    /// <summary>
    /// Isolates the browsing context such that it is available only to documents of the same origin.
    /// </summary>
    [EnumMember(Value = "same-origin")]
    SameOrigin,

    /// <summary>
    /// No cross-origin restrictions.
    /// </summary>
    [EnumMember(Value = "cross-origin")]
    CrossOrigin
}