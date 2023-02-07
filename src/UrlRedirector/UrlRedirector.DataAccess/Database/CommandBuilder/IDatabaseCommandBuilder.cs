using Dapper;
using Volkin.UrlRedirector.Domain.Models;

namespace Volkin.UrlRedirector.DataAccess.Database.CommandBuilder
{
    internal interface IDatabaseCommandBuilder
    {
        public CommandDefinition BuildSelectFullUrlByIdCommand(Url url, CancellationToken ct);
    }
}
