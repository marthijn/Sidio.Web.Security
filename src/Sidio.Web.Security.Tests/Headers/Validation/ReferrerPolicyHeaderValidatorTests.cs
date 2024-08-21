using System.Collections;
using System.Runtime.Serialization;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class ReferrerPolicyHeaderValidatorTests : HeaderValidatorTests<ReferrerPolicyHeaderOptions>
{
    protected override IHeaderValidator<ReferrerPolicyHeaderOptions> Validator => new ReferrerPolicyHeaderValidator();

    [Theory]
    [ClassData(typeof(ReferrerPolicyGenerator))]
    public void Validate_GivenValidValue_ShouldReturnValidResult(string value, ReferrerPolicy policy)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.Policies.Should().Contain(policy);
    }

    [Fact]
    public void Validate_GivenOptions_ShouldReturnValidResult()
    {
        // arrange
        var options = new ReferrerPolicyHeaderOptions { Policies = [ReferrerPolicy.NoReferrer] };

        // act
        var result = Validator.Validate(options);

        // assert
        result.IsValid.Should().BeTrue();
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
                    ((EnumMemberAttribute[]) referrerPolicy.GetField(name)!
                        .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                    .Single();
                _data.Add([enumMemberAttribute.Value, Enum.Parse(typeof(ReferrerPolicy), name)]);
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