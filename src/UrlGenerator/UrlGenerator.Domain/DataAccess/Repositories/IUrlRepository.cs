using Volkin.UrlGenerator.Domain.Models;

namespace Volkin.UrlGenerator.Domain.DataAccess.Repositories
{
    public interface IUrlRepository
    {
        public Task<Url?> CreateShortUrl(Url shortUrl, CancellationToken ct);

        public Task<long> GetNextShortUrlId(CancellationToken ct);
    }
}
