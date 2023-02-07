using MediatR;

namespace Volkin.UrlRedirector.Domain.UseCases
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}