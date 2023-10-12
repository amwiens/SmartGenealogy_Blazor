namespace SmartGenealogy.Application.Common.Behaviors;

public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehavior(ILogger logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = nameof(TRequest);
        var userName = _currentUserService.UserName;
        _logger.LogTrace("Request: {Name} with {@Request} by {@UserName}",
            requestName, request, userName);
        return Task.CompletedTask;
    }
}