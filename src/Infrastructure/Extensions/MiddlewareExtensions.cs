﻿using Microsoft.AspNetCore.Builder;

namespace SmartGenealogy.Infrastructure.Extensions;

internal static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<LocalizationCookiesMiddleware>();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}