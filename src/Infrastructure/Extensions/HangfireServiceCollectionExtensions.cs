using Hangfire;

namespace SmartGenealogy.Infrastructure.Extensions;

public static class HangfireServiceCollectionExtensions
{
    public static IServiceCollection AddHangfireService(this IServiceCollection services)
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseInMemoryStorage());
        services.AddHangfireServer();
        services.AddMvc();
        return services;
    }
}