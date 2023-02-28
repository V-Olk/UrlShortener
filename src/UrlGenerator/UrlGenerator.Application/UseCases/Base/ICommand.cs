using MediatR;

namespace Volkin.UrlGenerator.Application.UseCases.Base
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}