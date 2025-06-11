using Sidio.Web.Security.Cryptography;

namespace Sidio.Web.Security.Tests.Cryptography;

public sealed class SubresourceIntegrityOptionsTests
{
    [Fact]
    public void Construct_VerifyDefaultValues()
    {
        // act
        var result = new SubresourceIntegrityOptions();

        // assert
        result.Algorithm.Should().Be(SubresourceHashAlgorithm.SHA256);
        result.CacheExpiration.Should().Be(TimeSpan.FromDays(90));
        result.LocalCacheExpiration.Should().Be(TimeSpan.FromMinutes(5));
        result.CacheWhenFailed.Should().BeTrue();
    }
}