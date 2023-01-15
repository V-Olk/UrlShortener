using MediatR;

namespace Volkin.UrlGenerator.Domain.UseCases.Handlers
{
    public interface ICommandHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}