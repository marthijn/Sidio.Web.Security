using System.Collections;
using System.Runtime.Serialization;
using Sidio.Web.Security.Common;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Tests.Common;

public sealed class EnumExtensionsTests
{
    [Theory]
    [ClassData(typeof(SandboxDataGenerator))]
    public void ToStringValue_Sandbox_ReturnsString(Sandbox sandbox, string expected)
    {
        // act
        var result = sandbox.ToStringValue();

        // assert
        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(ReferrerPolicyGenerator))]
    public void ToStringValue_ReferrerPolicy_ReturnsString(ReferrerPolicy policy, string expected)
    {
        // act
        var result = policy.ToStringValue();

        // assert
        result.Should().Be(expected);
    }

    // todo refactor these data generators to a common class
    private sealed class SandboxDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object?[]> _data = new();

        public SandboxDataGenerator()
        {
            var sandboxType = typeof(Sandbox);
            foreach (var name in Enum.GetNames(sandboxType))
            {
                var enumMemberAttribute =
                    ((EnumMemberAttribute[]) sandboxType.GetField(name)!
                        .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                    .SingleOrDefault();
                _data.Add([Enum.Parse(typeof(Sandbox), name), enumMemberAttribute?.Value ?? string.Empty]);
            }

            _data.Should().NotBeEmpty();
        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    private sealed class ReferrerPolicyGenerator : IEnumerable<object[]>
    {
        private readonly List<object?[]> _data = new();

        public ReferrerPolicyGenerator()
        {
            var referrerPolicy = typeof(ReferrerPolicy);
            foreach (var name in Enum.GetNames(referrerPolicy))
            {
                var enumMemberAttribute =
                    ((EnumMemberAttribute[]) referrerPolicy.GetField(name)
                        .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                    .SingleOrDefault();
                _data.Add([Enum.Parse(typeof(ReferrerPolicy), name), enumMemberAttribute?.Value ?? string.Empty]);
            }

            _data.Should().NotBeEmpty();
        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}