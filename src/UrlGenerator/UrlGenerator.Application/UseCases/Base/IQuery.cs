using MediatR;

namespace Volkin.UrlGenerator.Application.UseCases.Base
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}