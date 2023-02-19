using Volkin.UrlGenerator.Application.Services;
using Volkin.UrlGenerator.Domain.DataAccess.Repositories.Actors;
using Volkin.UrlGenerator.Domain.Models;
using Volkin.UrlGenerator.Domain.UseCases.Handlers;

namespace Volkin.UrlGenerator.Application.UseCases.GenerateUrl
{
    internal class GenerateUrlHandler : ICommandHandler<GenerateUrlCommand, GenerateUrlResult>
    {
        private readonly IUrlsRepository _urlsRepository;
        private readonly IBase36Service _base36Service;

        public GenerateUrlHandler(IUrlsRepository urlsRepository, IBase36Service base36Service)
        {
            _urlsRepository = urlsRepository;
            _base36Service = base36Service;
        }

        public async Task<GenerateUrlResult> Handle(GenerateUrlCommand request, CancellationToken ct)
        {
            var id = await _urlsRepository.GetNextShortUrlId(ct);
            var shortUrl = _base36Service.Encode(id);

            var url = new Url
            {
                Id = id,
                Short = shortUrl,
                Full = request.Url
            };

            await _urlsRepository.CreateShortUrl(url, ct);

            return new GenerateUrlResult { ShortUrl = shortUrl } ;
        }
    }
}
