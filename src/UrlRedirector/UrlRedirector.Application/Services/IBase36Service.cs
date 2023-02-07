namespace Volkin.UrlRedirector.Application.Services;

internal interface IBase36Service
{
    public long Decode(string input);
}