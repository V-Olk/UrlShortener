using Volkin.UrlRedirector.Application.UseCases.GenerateUrl;

namespace Volkin.UrlRedirector.Application.Services;

internal interface IFullUrlByShortResolver
{
    public Task<GetRedirectUrlResult?> Resolve(string shortUrl, CancellationToken ct);
}