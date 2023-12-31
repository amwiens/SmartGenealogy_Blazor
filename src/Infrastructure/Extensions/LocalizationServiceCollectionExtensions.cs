﻿using Microsoft.AspNetCore.Builder;

using SmartGenealogy.Infrastructure.Constants.Localization;

namespace SmartGenealogy.Infrastructure.Extensions;

public static class LocalizationServiceCollectionExtensions
{
    public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
    {
        return services.AddScoped<LocalizationCookiesMiddleware>()
            .Configure<RequestLocalizationOptions>(options =>
            {
                options.AddSupportedUICultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
                options.AddSupportedCultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
                options.FallBackToParentUICultures = true;
            })
            .AddLocalization(options => options.ResourcesPath = LocalizationConstants.ResourcesPath);
    }
}