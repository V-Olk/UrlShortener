using Microsoft.Extensions.DependencyInjection;
using Volkin.UrlGenerator.DataAccess.Database.CommandBuilder;
using Volkin.UrlGenerator.DataAccess.Database.Repositories;
using Volkin.UrlGenerator.Domain.DataAccess.Repositories;

namespace Volkin.UrlGenerator.DataAccess.Common;

public static class Composer
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddScoped<IUrlRepository, UrlRepository>()
            .AddScoped<IDatabaseCommandBuilder, DatabaseCommandBuilder>();

        return services;
    }
}