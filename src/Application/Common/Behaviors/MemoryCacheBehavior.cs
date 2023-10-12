namespace SmartGenealogy.Application.Common.Behaviors;

public class MemoryCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheableRequest<TResponse>
{
    private readonly IAppCache _cache;
    private readonly ILogger<MemoryCacheBehavior<TRequest, TResponse>> _logger;

    public MemoryCacheBehavior(IAppCache cache, ILogger<MemoryCacheBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogTrace("{Name} is caching with {@Request}", nameof(request), request);
        var response = await _cache.GetOrAddAsync(
            request.CacheKey,
            async () =>
            await next(),
            request.Options).ConfigureAwait(false);

        return response;
    }
}