using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Volkin.UrlRedirector.DataAccess.Common.Exceptions;
using Volkin.UrlRedirector.DataAccess.Database.Cache;
using Volkin.UrlRedirector.DataAccess.Database.CommandBuilder;
using Volkin.UrlRedirector.DataAccess.Database.Repositories.Actors;
using Volkin.UrlRedirector.Domain.DataAccess.Cache;
using Volkin.UrlRedirector.Domain.DataAccess.Repositories.Actors;

namespace Volkin.UrlRedirector.DataAccess.Common;

public static class Composer
{
    private const string RedisConnectionString = "RedisOptions:ConnectionString";
    private const string RedisConStringMissing = "Redis connection string missing";

    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnectionString = configuration.GetSection(RedisConnectionString).Value
                  ?? throw new ConfigurationMissingException(RedisConStringMissing);

        services
            .AddScoped<IUrlsRepository, UrlsRepository>()
            .AddScoped<IDatabaseCommandBuilder, DatabaseCommandBuilder>()
            .AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString))
            .AddSingleton<IRedisStore, RedisStore>();

        return services;
    }
}