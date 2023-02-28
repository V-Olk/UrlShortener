using MediatR;

namespace Volkin.UrlRedirector.Application.UseCases.Base
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}