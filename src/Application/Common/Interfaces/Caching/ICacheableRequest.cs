namespace SmartGenealogy.Application.Common.Interfaces.Caching;

public interface ICacheableRequest<TResponse> : IRequest<TResponse>
{
    string CacheKey { get => String.Empty; }

    MemoryCacheEntryOptions? Options { get; }
}