using Serilog;
using Volkin.UrlRedirector.Webhost.Common.Extensions;

namespace Volkin.UrlRedirector.Webhost;

public static class Program
{
    public static void Main(string[] args)
    {
        LoggingExtensions.CreateBootstrapLogger();

        Log.Information("Starting up");

        try
        {
            var app = CreateHostBuilder(args).Build();

            app.Run();

            Log.Information("Stopped cleanly");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host failure");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        return builder;
    }


}