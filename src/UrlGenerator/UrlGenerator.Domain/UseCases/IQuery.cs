using MediatR;

namespace Volkin.UrlGenerator.Domain.UseCases
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}