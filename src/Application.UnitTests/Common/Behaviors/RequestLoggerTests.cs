using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using SmartGenealogy.Application.Common.Behaviors;
using SmartGenealogy.Application.Common.Interfaces;
using SmartGenealogy.Application.Common.Interfaces.Identity;
using SmartGenealogy.Application.Features.Products.Commands.AddEdit;

namespace Application.UnitTests.Common.Behaviors;

public class RequestLoggerTests
{
    private readonly Mock<ICurrentUserService> _currentUserService;
    private readonly Mock<IIdentityService> _identityService;
    private readonly Mock<ILogger<AddEditProductCommand>> _logger;

    public RequestLoggerTests()
    {
        _currentUserService = new Mock<ICurrentUserService>();
        _identityService = new Mock<IIdentityService>();
        _logger = new Mock<ILogger<AddEditProductCommand>>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns("Administrator");
        var requestLogger = new LoggingBehavior<AddEditProductCommand>(_logger.Object, _currentUserService.Object);
        await requestLogger.Process(new AddEditProductCommand { Brand = "Brand", Name = "Brand", Price = 1.0m, Unit = "EA" }, new CancellationToken());
        _currentUserService.Verify(i => i.UserName, Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehavior<AddEditProductCommand>(_logger.Object, _currentUserService.Object);
        await requestLogger.Process(new AddEditProductCommand { Brand = "Brand", Name = "Brand", Price = 1.0m, Unit = "EA" }, new CancellationToken());
        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>(), CancellationToken.None), Times.Never);
    }
}