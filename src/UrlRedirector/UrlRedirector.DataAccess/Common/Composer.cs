using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Volkin.UrlRedirector.DataAccess.Database.Cache;
using Volkin.UrlRedirector.DataAccess.Database.CommandBuilder;
using Volkin.UrlRedirector.DataAccess.Database.Repositories.Actors;
using Volkin.UrlRedirector.Domain.DataAccess.Cache;
using Volkin.UrlRedirector.Domain.DataAccess.Repositories.Actors;

namespace Volkin.UrlRedirector.DataAccess.Common;

public static class Composer
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddScoped<IUrlsRepository, UrlsRepository>()
            .AddScoped<IDatabaseCommandBuilder, DatabaseCommandBuilder>()
            .AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"))
            .AddSingleton<IRedisStore, RedisStore>();

        return services;
    }
}