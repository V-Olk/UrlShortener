using Volkin.UrlGenerator.Domain.Models;

namespace Volkin.UrlGenerator.Domain.DataAccess.Repositories.Actors
{
    public interface IUrlsRepository
    {
        public Task<Url?> CreateShortUrl(Url shortUrl, CancellationToken ct);

        public Task<long> GetNextShortUrlId(CancellationToken ct);
    }
}
