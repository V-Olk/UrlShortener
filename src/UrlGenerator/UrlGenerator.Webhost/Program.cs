using Serilog;
using Volkin.UrlGenerator.Webhost.Common.Extensions;

namespace Volkin.UrlGenerator.Webhost;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var app = CreateHostBuilder(args).Build();

            app.Run();
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
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        builder.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddSerilog();
        });

        LoggingExtensions.ConfigureSerilog();

        return builder;
    }
}