using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using Volkin.UrlGenerator.DataAccess.Database.CommandBuilder;
using Volkin.UrlGenerator.Domain.DataAccess.Repositories.Actors;
using Volkin.UrlGenerator.Domain.Models;
using Volkin.UrlGenerator.Domain.Options;

namespace Volkin.UrlGenerator.DataAccess.Database.Repositories.Actors
{
    internal class UrlsRepository : IUrlsRepository
    {
        private readonly DatabaseOptions _databaseOptions;
        private readonly IDatabaseCommandBuilder _dbCommandBuilder;

        public UrlsRepository(IOptions<DatabaseOptions> databaseOptions, IDatabaseCommandBuilder dbCommandBuilder)
        {
            _dbCommandBuilder = dbCommandBuilder;
            _databaseOptions = databaseOptions.Value;
        }

        public async Task<Url?> CreateShortUrl(Url url, CancellationToken ct)
        {
            await using var connection = new NpgsqlConnection(_databaseOptions.ConnectionString);
            await connection.OpenAsync(ct);

            return await connection.QuerySingleAsync<Url>(_dbCommandBuilder.BuildInsertUrlCommand(url, ct));
        }

        public async Task<long> GetNextShortUrlId(CancellationToken ct)
        {
            await using var connection = new NpgsqlConnection(_databaseOptions.ConnectionString);
            await connection.OpenAsync(ct);

            return await connection.QueryFirstAsync<long>(_dbCommandBuilder.BuildSelectNewUrlIdCommand(ct));
        }
    }
}
