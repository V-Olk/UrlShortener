using Serilog;
using Serilog.Events;

namespace Volkin.UrlGenerator.Webhost.Common.Extensions
{
    public static class LoggingExtensions
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((context, configuration) => configuration
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)

                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()

                .WriteTo.Console()
                .WriteTo.Debug()

                .ReadFrom.Configuration(context.Configuration));
        }

        public static void CreateBootstrapLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)

                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()

                .WriteTo.Console()
                .WriteTo.Debug()

                .CreateBootstrapLogger();
        }
    }
}
