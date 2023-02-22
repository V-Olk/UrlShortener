using System.Reflection;
using Volkin.UrlRedirector.Application.Common;
using Volkin.UrlRedirector.DataAccess.Common;
using Volkin.UrlRedirector.Domain.Options;
using Volkin.UrlRedirector.Webhost.Common.Extensions;

namespace Volkin.UrlRedirector.Webhost;

public class Startup
{
    private readonly IConfiguration _сonfiguration;

    public Startup(IConfiguration configuration)
    {
        _сonfiguration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<DatabaseOptions>(_сonfiguration.GetSection(nameof(DatabaseOptions)));

        services.AddDataAccess(_сonfiguration);
        services.AddApplication();

        services.AddControllers(x => x.SuppressAsyncSuffixInActionNames = true);
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            // Set the comments path for the Swagger JSON and UI
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlShortener V1"));
        }

        app.ConfigureCustomExceptionMiddleware();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}