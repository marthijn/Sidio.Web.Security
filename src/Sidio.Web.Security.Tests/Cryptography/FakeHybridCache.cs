using Microsoft.Extensions.Caching.Hybrid;

namespace Sidio.Web.Security.Tests.Cryptography;

//// https://github.com/dotnet/extensions/issues/5763
internal sealed class FakeHybridCache : HybridCache
{
    private readonly Dictionary<string, object?> _cache = new();

    public override async ValueTask<T> GetOrCreateAsync<TState, T>(
        string key,
        TState state,
        Func<TState, CancellationToken, ValueTask<T>> factory,
        HybridCacheEntryOptions? options = null,
        IEnumerable<string>? tags = null,
        CancellationToken cancellationToken = default)
    {
        var cached = _cache.TryGetValue(key, out object? value);
        if (cached)
        {
            return (T?) value!;
        }

        _cache.Add(key, await factory(state, cancellationToken));
        return (T?) _cache[key]!;
    }

    public override ValueTask SetAsync<T>(
        string key,
        T value,
        HybridCacheEntryOptions? options = null,
        IEnumerable<string>? tags = null,
        CancellationToken cancellationToken = default)
    {
        _cache[key] = value;
        return new ValueTask();
    }

    public override ValueTask RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        _cache.Remove(key);
        return new ValueTask();
    }

    public override ValueTask RemoveByTagAsync(string tag, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }

    public void KeyExists(string key)
    {
        _cache.Should().ContainKey(key);
    }

    public void KeyNotExists(string key)
    {
        _cache.Should().NotContainKey(key);
    }
}