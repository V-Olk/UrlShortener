using Volkin.UrlGenerator.Webhost.Common.CustomExceptionMiddleware;

namespace Volkin.UrlGenerator.Webhost.Common.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
