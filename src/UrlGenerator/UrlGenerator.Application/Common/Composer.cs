using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Volkin.UrlGenerator.Application.Behaviors;
using Volkin.UrlGenerator.Application.Services;

namespace Volkin.UrlGenerator.Application.Common;

public static class Composer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(typeof(Composer))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>))
            .AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Composer)), includeInternalTypes: true)
            .AddScoped<IBase36Service, Base36Service>();

        return services;
    }
}