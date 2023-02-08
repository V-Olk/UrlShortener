using StackExchange.Redis;
using Volkin.UrlRedirector.Domain.DataAccess.Cache;

namespace Volkin.UrlRedirector.DataAccess.Database.Cache
{
    internal class RedisStore : IRedisStore
    {
        private readonly IDatabase _database;

        public RedisStore(IConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();
        }

        public async Task<string?> GetString(string key, CancellationToken ct)
            => await _database.StringGetAsync(key);

        public async Task<bool> SetString(string key, string value, CancellationToken ct)
            => await _database.StringSetAsync(key, value);
    }
}