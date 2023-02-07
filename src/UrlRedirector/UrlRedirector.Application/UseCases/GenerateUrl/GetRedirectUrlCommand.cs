using Volkin.UrlRedirector.Domain.UseCases;

namespace Volkin.UrlRedirector.Application.UseCases.GenerateUrl
{
    public class GetRedirectUrlCommand : ICommand<GetRedirectUrlResult>
    {
        public string ShortUrl { get; init; } = String.Empty;
    }
}
