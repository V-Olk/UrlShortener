using System.Text.Json;

namespace Volkin.UrlGenerator.Webhost.Common.CustomExceptionMiddleware
{
    public class ErrorDetails
    {
        public int StatusCode { get; init; }
        public string? Message { get; init; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
