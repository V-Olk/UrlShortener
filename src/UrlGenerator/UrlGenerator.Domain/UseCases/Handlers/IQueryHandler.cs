using MediatR;

namespace Volkin.UrlGenerator.Domain.UseCases.Handlers
{
    public interface IQueryHandler<in TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}