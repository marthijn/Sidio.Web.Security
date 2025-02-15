using System.Diagnostics.CodeAnalysis;

namespace Sidio.Web.Security.Examples.AspNetCore.Models;

[ExcludeFromCodeCoverage]
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}