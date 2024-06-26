﻿namespace Nik.ApiConnection;

public static class ServicesExtensions
{
    public static IServiceCollection AddNikApiConnection(this IServiceCollection services)
    {
        services.AddSingleton<IHttpClientFactory, HttpClientFactory>();
        services.AddSingleton<IApiCacher, ApiCacher>();
        services.AddSingleton<IApiConfigLoader, AppSettingsApiConfigLoader>();

        return services;
    }
}