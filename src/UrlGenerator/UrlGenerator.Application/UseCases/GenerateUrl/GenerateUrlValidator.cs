using FluentValidation;

namespace Volkin.UrlGenerator.Application.UseCases.GenerateUrl;

internal class GenerateUrlValidator : AbstractValidator<GenerateUrlCommand>
{
    public GenerateUrlValidator()
    {
        RuleFor(c => c.Url)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out var uriResult)
                         && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps));
    }
}