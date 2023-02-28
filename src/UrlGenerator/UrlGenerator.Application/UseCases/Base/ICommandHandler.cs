using MediatR;

namespace Volkin.UrlGenerator.Application.UseCases.Base
{
    public interface ICommandHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}