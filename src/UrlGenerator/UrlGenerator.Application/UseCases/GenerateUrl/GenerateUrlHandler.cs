using Volkin.UrlGenerator.Domain.UseCases.Handlers;

namespace Volkin.UrlGenerator.Application.UseCases.GenerateUrl
{
    internal class GenerateUrlHandler : ICommandHandler<GenerateUrlCommand, GenerateUrlResult>
    {
        public Task<GenerateUrlResult> Handle(GenerateUrlCommand request, CancellationToken cancellationToken)
        {


            return Task.FromResult(new GenerateUrlResult());
        }
    }
}
