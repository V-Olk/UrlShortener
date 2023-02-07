using MediatR;

namespace Volkin.UrlRedirector.Domain.UseCases.Handlers
{
    public interface ICommandHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}