using Volkin.UrlRedirector.Domain.Models;

namespace Volkin.UrlRedirector.Domain.DataAccess.Repositories.Actors
{
    public interface IUrlsRepository
    {
        public Task<Url?> GetFullUrl(Url shortUrl, CancellationToken ct);
    }
}
