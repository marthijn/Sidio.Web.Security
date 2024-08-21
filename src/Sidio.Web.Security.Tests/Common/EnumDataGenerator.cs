using System.Collections;
using System.Runtime.Serialization;

namespace Sidio.Web.Security.Tests.Common;

/// <summary>
/// Represents a data generator for an enum type.
/// An item is in the format [Enum, EnumMemberAttribute.Value].
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class EnumDataGenerator<T> : IEnumerable<object[]>
    where T : Enum
{
    private readonly List<object?[]> _data = new();

    protected EnumDataGenerator()
    {
        var enumType = typeof(T);
        foreach (var name in Enum.GetNames(enumType))
        {
            var enumMemberAttribute =
                ((EnumMemberAttribute[]) enumType.GetField(name)!
                    .GetCustomAttributes(typeof(EnumMemberAttribute), true))
                .SingleOrDefault();
            _data.Add([Enum.Parse(typeof(T), name), enumMemberAttribute?.Value ?? string.Empty]);
        }

        _data.Should().NotBeEmpty();
    }

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}