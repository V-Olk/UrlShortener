using MediatR;

namespace Volkin.UrlGenerator.Application.UseCases.Base
{
    public interface IQueryHandler<in TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}