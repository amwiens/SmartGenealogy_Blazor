namespace SmartGenealogy.Application.Features.Customers.Caching;

public static class CustomerCacheKey
{
    private static readonly TimeSpan refreshInterval = TimeSpan.FromHours(3);
    public const string GetAllCacheKey = "all-Customers";

    public static string GetPaginationCacheKey(string parameters)
    {
        return $"CustomerCacheKey:CustomersWithPaginationQuery,{parameters}";
    }

    public static string GetByNameCacheKey(string parameters)
    {
        return $"CustomerCacheKey:GetByNameCacheKey,{parameters}";
    }

    public static string GetByIdCacheKey(string parameters)
    {
        return $"CustomerCacheKey:GetByIdCacheKey,{parameters}";
    }

    static CustomerCacheKey()
    {
        _tokenSource = new CancellationTokenSource(refreshInterval);
    }

    private static CancellationTokenSource _tokenSource;

    public static CancellationTokenSource SharedExpiryTokenSource()
    {
        if (_tokenSource.IsCancellationRequested)
        {
            _tokenSource = new CancellationTokenSource(refreshInterval);
        }
        return _tokenSource;
    }

    public static void Refresh() => SharedExpiryTokenSource().Cancel();

    public static MemoryCacheEntryOptions MemoryCacheEntryOptions => new MemoryCacheEntryOptions().AddExpirationToken(new CancellationChangeToken(SharedExpiryTokenSource().Token));
}