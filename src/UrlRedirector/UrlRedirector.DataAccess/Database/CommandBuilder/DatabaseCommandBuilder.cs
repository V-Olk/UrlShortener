using Dapper;
using Volkin.UrlRedirector.Domain.Models;

namespace Volkin.UrlRedirector.DataAccess.Database.CommandBuilder
{
    internal sealed class DatabaseCommandBuilder : IDatabaseCommandBuilder
    {
        private const string SelectFullUrlById = $"SELECT \"{nameof(Url.Full)}\" FROM url WHERE \"{nameof(Url.Id)}\" = @{nameof(Url.Id)} LIMIT 1";

        public CommandDefinition BuildSelectFullUrlByIdCommand(Url url, CancellationToken ct)
            => new(SelectFullUrlById, url, cancellationToken: ct);
    }
}
