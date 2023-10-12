namespace SmartGenealogy.Application.Common.Interfaces.Caching;

public interface ICacheInvalidatorRequest<TResponse> : IRequest<TResponse>
{
    string CacheKey { get => String.Empty; }

    CancellationTokenSource? SharedExpiryTokenSource { get; }
}