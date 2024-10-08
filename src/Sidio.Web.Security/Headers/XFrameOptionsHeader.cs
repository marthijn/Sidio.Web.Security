﻿using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The X-Frame-Options header.
/// </summary>
public sealed class XFrameOptionsHeader : ValidatableHttpHeader<XFrameOptionsHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "X-Frame-Options";

    /// <summary>
    /// The DENY option.
    /// </summary>
    public const string Deny = "DENY";

    /// <summary>
    /// The SAMEORIGIN option.
    /// </summary>
    public const string SameOrigin = "SAMEORIGIN";

    /// <summary>
    /// The ALLOW-FROM option.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal const string AllowFrom = "ALLOW-FROM";

    /// <summary>
    /// The allowed/recommended values.
    /// </summary>
    internal static readonly string[] AllowedValues = [Deny, SameOrigin];

    /// <summary>
    /// Initializes a new instance of the <see cref="XFrameOptionsHeader"/> class.
    /// </summary>
    /// <param name="value">The header value.</param>
    public XFrameOptionsHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<XFrameOptionsHeaderOptions> Validator => new XFrameOptionsHeaderValidator();
}