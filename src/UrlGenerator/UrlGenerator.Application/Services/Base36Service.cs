namespace Volkin.UrlGenerator.Application.Services;

internal class Base36Service : IBase36Service
{
    private const long StartIndex = 2_180_000_000;

    private readonly char[] _charList = {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    public string Encode(long input)
    {
        if (input < 0)
            throw new ArgumentOutOfRangeException(nameof(input), input, "Input cannot be negative");

        input += StartIndex;

        var result = new Stack<char>();

        while (input != 0)
        {
            result.Push(_charList[input % 36]);
            input /= 36;
        }

        return String.Concat(result);
    }
}