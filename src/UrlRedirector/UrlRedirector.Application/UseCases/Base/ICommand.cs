using MediatR;

namespace Volkin.UrlRedirector.Application.UseCases.Base
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}