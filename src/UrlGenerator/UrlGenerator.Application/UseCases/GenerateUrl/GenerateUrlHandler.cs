using Volkin.UrlGenerator.Application.Services;
using Volkin.UrlGenerator.Application.UseCases.Base;
using Volkin.UrlGenerator.Domain.DataAccess.Repositories;
using Volkin.UrlGenerator.Domain.Models;

namespace Volkin.UrlGenerator.Application.UseCases.GenerateUrl
{
    internal class GenerateUrlHandler : ICommandHandler<GenerateUrlCommand, GenerateUrlResult>
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IBase36Service _base36Service;

        public GenerateUrlHandler(IUrlRepository urlRepository, IBase36Service base36Service)
        {
            _urlRepository = urlRepository;
            _base36Service = base36Service;
        }

        public async Task<GenerateUrlResult> Handle(GenerateUrlCommand request, CancellationToken ct)
        {
            var id = await _urlRepository.GetNextShortUrlId(ct);
            var shortUrl = _base36Service.Encode(id);

            var url = new Url
            {
                Id = id,
                Short = shortUrl,
                Full = request.Url
            };

            await _urlRepository.CreateShortUrl(url, ct);

            return new GenerateUrlResult { ShortUrl = shortUrl } ;
        }
    }
}
