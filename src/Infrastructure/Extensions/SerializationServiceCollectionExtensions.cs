using SmartGenealogy.Application.Common.Interfaces.Serialization;
using SmartGenealogy.Infrastructure.Services.Serialization;

namespace SmartGenealogy.Infrastructure.Extensions;

public static class SerializationServiceCollectionExtensions
{
    public static IServiceCollection AddSerialization(this IServiceCollection services)
        => services.AddSingleton<ISerializer, SystemTextJsonSerializer>();
}