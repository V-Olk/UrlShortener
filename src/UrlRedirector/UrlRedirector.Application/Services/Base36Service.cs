namespace Volkin.UrlRedirector.Application.Services;

internal class Base36Service : IBase36Service
{
    private const long StartIndex = 2_180_000_000;

    private readonly char[] _charList = {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    public long Decode(string input)
    {
        var reversed = input.ToLower().Reverse();

        long result = 0;
        int pos = 0;

        foreach (char c in reversed)
        {
            result += Array.IndexOf(_charList, c) * (long)Math.Pow(36, pos);
            pos++;
        }

        return result - StartIndex;
    }
}