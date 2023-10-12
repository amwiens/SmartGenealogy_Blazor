namespace SmartGenealogy.Application.Common.Behaviors;

public class CacheInvalidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheInvalidatorRequest<TResponse>
{
    private readonly IAppCache _cache;
    private readonly ILogger<CacheInvalidationBehavior<TRequest, TResponse>> _logger;

    public CacheInvalidationBehavior(IAppCache cache, ILogger<CacheInvalidationBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogTrace("{Name} cache expire with {@Request}", nameof(request), request);
        var response = await next().ConfigureAwait(false);
        if (!string.IsNullOrEmpty(request.CacheKey))
        {
            _cache.Remove(request.CacheKey);
        }
        request.SharedExpiryTokenSource?.Cancel();
        return response;
    }
}