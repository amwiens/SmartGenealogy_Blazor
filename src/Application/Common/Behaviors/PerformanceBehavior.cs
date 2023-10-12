using System.Diagnostics;

namespace SmartGenealogy.Application.Common.Behaviors;

/// <summary>
/// This class is a behavior pipline in MediatR. It is used to monitor performance
/// and log warnings if a request takes longer to execute than a specified threshold.
/// </summary>
/// <typeparam name="TRequest">Type of Request</typeparam>
/// <typeparam name="TResponse">Type of Response</typeparam>
public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;

    public PerformanceBehavior(ICurrentUserService currentUserService, ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _currentUserService = currentUserService;
        _logger = logger;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Stopwatch? timer = null;

        // Increment ExecutionCount in a thread-safe manner.
        Interlocked.Increment(ref RequestCounter.ExecutionCount);
        if (RequestCounter.ExecutionCount > 3) timer = Stopwatch.StartNew();

        var response = await next().ConfigureAwait(false);

        timer?.Stop();
        var elapsedMilliseconds = timer?.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userName = _currentUserService.UserName;

            _logger.LogWarning(
                "{Name} long running request({ElapsedMilliseconds} milliseconds) with {@Request} {@UserName} ",
                requestName, elapsedMilliseconds, request, userName);
        }

        return response;
    }
}

/// <summary>
/// Static class that holds the ExecutionCount in a shared context between different
/// instances of our PerformanceBehavior class, regardless of the type of TRequest.
/// This allows to keep track of the number or requests application-wide.
/// </summary>
public static class RequestCounter
{
    public static int ExecutionCount;
}