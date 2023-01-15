using Serilog;
using Serilog.Events;

namespace Volkin.UrlGenerator.Webhost.Common.Extensions
{
    public static class LoggingExtensions
    {
        public static void ConfigureSerilog()
        {
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot? configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)

                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                
                .WriteTo.Console()
                .WriteTo.Debug()

                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
