using System.Collections;
using System.Runtime.Serialization;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class CrossOriginResourcePolicyHeaderValidatorTests : HeaderValidatorTests<CrossOriginResourcePolicyHeaderOptions>
{
    protected override IHeaderValidator<CrossOriginResourcePolicyHeaderOptions> Validator => new CrossOriginResourcePolicyHeaderValidator();

    [Theory]
    [ClassData(typeof(CrossOriginResourcePolicyGenerator))]
    public void Validate_GivenValidValue_ShouldReturnValidResult(string value, CrossOriginResourcePolicy policy)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.Policy.Should().Be(policy);
    }

    [Fact]
    public void Validate_GivenOptions_ShouldReturnValidResult()
    {
        // arrange
        var options = new CrossOriginResourcePolicyHeaderOptions { Policy = CrossOriginResourcePolicy.SameOrigin };

        // act
        var result = Validator.Validate(options);

        // assert
        result.IsValid.Should().BeTrue();
    }

    private sealed class CrossOriginResourcePolicyGenerator : IEnumerable<object[]>
    {
        private readonly List<object?[]> _data = new();

        public CrossOriginResourcePolicyGenerator()
        {
            var referrerPolicy = typeof(CrossOriginResourcePolicy);
            foreach (var name in Enum.GetNames(referrerPolicy))
            {
                var enumMemberAttribute =
                    ((EnumMemberAttribute[]) referrerPolicy.GetField(name)!
                        .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                    .Single();
                _data.Add([enumMemberAttribute.Value, Enum.Parse(typeof(CrossOriginResourcePolicy), name)]);
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