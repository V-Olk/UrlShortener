using MediatR;

namespace Volkin.UrlRedirector.Domain.UseCases.Handlers
{
    public interface IQueryHandler<in TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}