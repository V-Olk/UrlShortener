namespace Volkin.UrlGenerator.Domain.Models;

public class Url
{
    public long Id { get; init; }
    public string Full { get; init; } = String.Empty;
    public string Short { get; init; } = String.Empty;
}