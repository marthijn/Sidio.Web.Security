using System.Runtime.Serialization;

namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

public enum Sandbox
{
    [EnumMember(Value = "allow-downloads")]
    AllowDownloads,
}