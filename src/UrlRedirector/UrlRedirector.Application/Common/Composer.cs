using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Volkin.UrlRedirector.Application.Services;

namespace Volkin.UrlRedirector.Application.Common;

public static class Composer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(typeof(Composer))
            .AddScoped<IBase36Service, Base36Service>();

        return services;
    }
}