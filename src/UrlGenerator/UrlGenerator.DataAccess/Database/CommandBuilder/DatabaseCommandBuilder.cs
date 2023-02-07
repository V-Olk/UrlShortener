using Dapper;
using Volkin.UrlGenerator.Domain.Models;

namespace Volkin.UrlGenerator.DataAccess.Database.CommandBuilder
{
    internal sealed class DatabaseCommandBuilder : IDatabaseCommandBuilder
    {
        private const string SelectNewUrlCommand = "SELECT nextval('url_id')";

        public CommandDefinition BuildSelectNewUrlIdCommand(CancellationToken ct) => new(SelectNewUrlCommand, ct);

        public CommandDefinition BuildInsertUrlCommand(Url shortUrl, CancellationToken ct)
        {
            return new CommandDefinition(
                $"INSERT INTO url(\"{nameof(Url.Id)}\", \"{nameof(Url.Full)}\", \"{nameof(Url.Short)}\") " + 
                $"VALUES(@{nameof(Url.Id)}, @{nameof(Url.Full)}, @{nameof(Url.Short)}) " +
                "RETURNING *",
                shortUrl, cancellationToken: ct);
        }
    }
}
