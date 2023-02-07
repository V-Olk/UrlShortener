using Volkin.UrlRedirector.Webhost.Common.CustomExceptionMiddleware;

namespace Volkin.UrlRedirector.Webhost.Common.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
