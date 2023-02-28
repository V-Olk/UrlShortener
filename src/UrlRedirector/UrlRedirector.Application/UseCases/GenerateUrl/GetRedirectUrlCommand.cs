using Volkin.UrlRedirector.Application.UseCases.Base;

namespace Volkin.UrlRedirector.Application.UseCases.GenerateUrl
{
    public class GetRedirectUrlCommand : ICommand<GetRedirectUrlResult>
    {
        public string ShortUrl { get; init; } = String.Empty;
    }
}
