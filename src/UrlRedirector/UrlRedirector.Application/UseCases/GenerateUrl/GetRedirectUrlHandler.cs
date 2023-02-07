using Volkin.UrlRedirector.Application.Services;
using Volkin.UrlRedirector.Domain.DataAccess.Repositories.Actors;
using Volkin.UrlRedirector.Domain.Models;
using Volkin.UrlRedirector.Domain.UseCases.Handlers;

namespace Volkin.UrlRedirector.Application.UseCases.GenerateUrl
{
    internal class GetRedirectUrlHandler : ICommandHandler<GetRedirectUrlCommand, GetRedirectUrlResult>
    {
        private readonly IUrlsRepository _urlsRepository;
        private readonly IBase36Service _base36Service;

        public GetRedirectUrlHandler(IUrlsRepository urlsRepository, IBase36Service base36Service)
        {
            _urlsRepository = urlsRepository;
            _base36Service = base36Service;
        }

        public async Task<GetRedirectUrlResult> Handle(GetRedirectUrlCommand request, CancellationToken ct)
        {
            var urlId = _base36Service.Decode(request.ShortUrl);

            var url = new Url
            {
                Id = urlId,
            };

            //TODO: Add redis
            url = await _urlsRepository.GetFullUrl(url, ct);

            return new GetRedirectUrlResult { Url = url?.Full };
        }
    }
}
