using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Volkin.UrlGenerator.Webhost.Controllers;

public class MediatRControllerBase : ControllerBase
{
    private IMediator Mediator =>
        HttpContext.RequestServices.GetService<IMediator>() 
        ?? throw new InvalidOperationException("Mediator is not registered");

    protected Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken ct)
        => Mediator.Send(request, ct);
}