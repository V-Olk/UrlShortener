using Volkin.UrlRedirector.Application.Services;
using Volkin.UrlRedirector.Domain.UseCases.Handlers;

namespace Volkin.UrlRedirector.Application.UseCases.GenerateUrl
{
    internal class GetRedirectUrlHandler : ICommandHandler<GetRedirectUrlCommand, GetRedirectUrlResult?>
    {
        private readonly IFullUrlByShortResolver _fullUrlByShortResolver;

        public GetRedirectUrlHandler(IFullUrlByShortResolver fullUrlByShortResolver)
        {
            _fullUrlByShortResolver = fullUrlByShortResolver;
        }

        public Task<GetRedirectUrlResult?> Handle(GetRedirectUrlCommand request, CancellationToken ct)
            => _fullUrlByShortResolver.Resolve(request.ShortUrl, ct);
    }
}
