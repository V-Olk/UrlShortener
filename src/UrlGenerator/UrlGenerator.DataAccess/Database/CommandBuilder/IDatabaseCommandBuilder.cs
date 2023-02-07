using Dapper;
using Volkin.UrlGenerator.Domain.Models;

namespace Volkin.UrlGenerator.DataAccess.Database.CommandBuilder
{
    internal interface IDatabaseCommandBuilder
    {
        public CommandDefinition BuildSelectNewUrlIdCommand(CancellationToken ct);

        public CommandDefinition BuildInsertUrlCommand(Url shortUrl, CancellationToken ct);
    }
}
