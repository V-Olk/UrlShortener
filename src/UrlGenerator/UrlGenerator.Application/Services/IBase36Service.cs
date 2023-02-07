namespace Volkin.UrlGenerator.Application.Services;

internal interface IBase36Service
{
    public string Encode(long input);
}