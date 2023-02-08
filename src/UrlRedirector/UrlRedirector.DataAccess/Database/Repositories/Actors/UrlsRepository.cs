using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using Volkin.UrlRedirector.DataAccess.Database.CommandBuilder;
using Volkin.UrlRedirector.Domain.DataAccess.Repositories.Actors;
using Volkin.UrlRedirector.Domain.Models;
using Volkin.UrlRedirector.Domain.Options;

namespace Volkin.UrlRedirector.DataAccess.Database.Repositories.Actors
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

        public async Task<Url?> GetFullUrl(Url url, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return null;

            await using var connection = new NpgsqlConnection(_databaseOptions.ConnectionString);

            if (ct.IsCancellationRequested)
                return null;

            await connection.OpenAsync(ct);

            if (ct.IsCancellationRequested)
                return null;

            return await connection.QueryFirstOrDefaultAsync<Url>(_dbCommandBuilder.BuildSelectFullUrlByIdCommand(url, ct));
        }
    }
}
