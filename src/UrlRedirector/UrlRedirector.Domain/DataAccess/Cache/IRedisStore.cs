namespace Volkin.UrlRedirector.Domain.DataAccess.Cache
{
    public interface IRedisStore
    {
        public Task<string?> GetString(string key, CancellationToken ct);

        public Task<bool> SetString(string key, string value, CancellationToken ct);
    }
}