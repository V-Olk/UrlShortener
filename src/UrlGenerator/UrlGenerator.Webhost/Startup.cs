using System.Reflection;
using Volkin.UrlGenerator.Application.Common;
using Volkin.UrlGenerator.DataAccess.Common;
using Volkin.UrlGenerator.Webhost.Common.Extensions;

namespace Volkin.UrlGenerator.Webhost;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDataAccess();
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
        if (env.IsDevelopment())// || env.EnvironmentName is "Docker")
        {
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlShortener V1"));
        }

        app.ConfigureCustomExceptionMiddleware();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}