using MediatR;

namespace Volkin.UrlRedirector.Domain.UseCases
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}