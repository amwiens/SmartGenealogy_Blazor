using SmartGenealogy.Application.Common.Interfaces.Serialization;

namespace SmartGenealogy.Infrastructure.Extensions;

public static class SerializationServiceCollectionExtensions
{
    public static IServiceCollection AddSerialization(this IServiceCollection services)
        => services.AddSingleton<ISerializer, SystemTextJsonSerializer>();
}