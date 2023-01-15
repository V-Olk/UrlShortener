using MediatR;

namespace Volkin.UrlGenerator.Domain.UseCases
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}