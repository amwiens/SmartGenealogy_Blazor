﻿using SmartGenealogy.Infrastructure.Hubs;

namespace SmartGenealogy.Infrastructure.Extensions;

public static class SignalRServiceCollectionExtensions
{
    public static void AddSignalRServices(this IServiceCollection services)
    {
        services.AddSingleton<IUsersStateContainer, UsersStateContainer>()
            .AddScoped<HubClient>()
            .AddSignalR();
    }
}