﻿using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.Tests.Headers;

public sealed class XFrameOptionsHeaderTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_GivenValue_ShouldSetProperties()
    {
        // arrange
        var value = _fixture.Create<string>();

        // act
        var header = new XFrameOptionsHeader(value);

        // assert
        header.Value.Should().Be(value);
    }
}