using Volkin.UrlGenerator.Domain.UseCases;

namespace Volkin.UrlGenerator.Application.UseCases.GenerateUrl
{
    public class GenerateUrlCommand : ICommand<GenerateUrlResult>
    {
        public string Url { get; init; } = String.Empty;
    }
}
