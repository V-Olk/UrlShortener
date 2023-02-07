using Microsoft.Extensions.DependencyInjection;
using Volkin.UrlGenerator.DataAccess.Database.CommandBuilder;
using Volkin.UrlGenerator.DataAccess.Database.Repositories.Actors;
using Volkin.UrlGenerator.Domain.DataAccess.Repositories.Actors;

namespace Volkin.UrlGenerator.DataAccess.Common;

public static class Composer
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddScoped<IUrlsRepository, UrlsRepository>()
            .AddScoped<IDatabaseCommandBuilder, DatabaseCommandBuilder>();

        return services;
    }
}