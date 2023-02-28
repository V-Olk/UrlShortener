using Volkin.UrlRedirector.Domain.Models;

namespace Volkin.UrlRedirector.Domain.DataAccess.Repositories
{
    public interface IUrlRepository
    {
        public Task<Url?> GetFullUrl(Url shortUrl, CancellationToken ct);
    }
}
