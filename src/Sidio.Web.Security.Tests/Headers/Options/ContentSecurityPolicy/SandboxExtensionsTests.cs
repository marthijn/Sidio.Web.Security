using System.Collections;
using System.Runtime.Serialization;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Tests.Headers.Options.ContentSecurityPolicy;

public sealed class SandboxExtensionsTests
{
    [Theory]
    [ClassData(typeof(SandboxDataGenerator))]
    public void ToValue_ReturnsString(Sandbox sandbox, string expected)
    {
        // act
        var result = sandbox.ToValue();

        // assert
        result.Should().Be(expected);
    }

    private sealed class SandboxDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object?[]> _data = new();

        public SandboxDataGenerator()
        {
            var sandboxType = typeof(Sandbox);
            foreach (var name in Enum.GetNames(sandboxType))
            {
                var enumMemberAttribute =
                    ((EnumMemberAttribute[]) sandboxType.GetField(name)
                        .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                    .Single();
                _data.Add([Enum.Parse(typeof(Sandbox), name), enumMemberAttribute.Value]);
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