using Microsoft.Extensions.DependencyInjection;

using SmartGenealogy.Application.Common.Behaviors;
using SmartGenealogy.Application.Common.Interfaces.MultiTenant;
using SmartGenealogy.Application.Common.PublishStrategies;
using SmartGenealogy.Application.Services.MultiTenant;
using SmartGenealogy.Application.Services.Picklist;
using SmartGenealogy.Application.Services.Validation;

namespace SmartGenealogy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.NotificationPublisher = new ParallelNoWaitPublisher();
            config.AddOpenBehavior(typeof(PerformanceBehavior<,>));
            config.AddOpenBehavior(typeof(UnhandledExceptionBehavior<,>));
            config.AddOpenBehavior(typeof(RequestExceptionActionProcessorBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(MemoryCacheBehavior<,>));
            config.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            config.AddOpenBehavior(typeof(CacheInvalidationBehavior<,>));
        });
        services.AddFluxor(options =>
        {
            options.ScanAssemblies(Assembly.GetExecutingAssembly());
            options.UseReduxDevTools();
        });
        services.AddLazyCache();
        services.AddSingleton<PicklistService>();
        services.AddSingleton<IPicklistService>(sp =>
        {
            var service = sp.GetRequiredService<PicklistService>();
            service.Initialize();
            return service;
        });
        services.AddSingleton<TenantService>();
        services.AddSingleton<ITenantService>(sp =>
        {
            var service = sp.GetRequiredService<TenantService>();
            service.Initialize();
            return service;
        });
        services.AddScoped<IValidationService, ValidationService>();
        return services;
    }
}