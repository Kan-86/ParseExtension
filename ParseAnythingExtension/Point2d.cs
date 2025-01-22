
using System.Diagnostics.CodeAnalysis;

namespace ParseAnything;

public record Point2d(int X, int Y) : ISpanParsable<Point2d>
{
    public static Point2d Parse(string input, IFormatProvider? formatProvider = null)
    {
        var parts = input.Split(',');
        if (parts.Length != 2)
        {
            throw new FormatException("Input must be in the format 'x,y'");
        }

        var x = parts[0].Parse<int>();
        var y = parts[1].Parse<int>();

        return new Point2d(x, y);
    }

    public static Point2d Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null)
    {
        Span<Range> dest = stackalloc Range[2];
        var splitText = s.Split(dest, ',');
        var x = int.Parse(s[dest[0]]);
        var y = int.Parse(s[dest[1]]);
        return new Point2d(x, y);
    }

    public static bool TryParse([NotNullWhen(true)] string? input, IFormatProvider? provider, [MaybeNullWhen(false)] out Point2d result)
    {
        result = default;

        var parts = input.Split(',');
        if (parts.Length != 2)
        {
            return false;
        }

        if (!int.TryParse(parts[0], out var x))
        {
            return false;
        }

        if (!int.TryParse(parts[1], out var y))
        {
            return false;
        }

        result = new Point2d(x, y);
        return true;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Point2d result)
    {
        try
        {
            Span<Range> dest = stackalloc Range[2];
            var splitText = s.Split(dest, ',');
            var x = int.Parse(s[dest[0]]);
            var y = int.Parse(s[dest[1]]);
            result = new Point2d(x, y);
            return true;
        }
        catch (Exception)
        {
            result = new Point2d(-1, -1);
            return false;
        }
    }
}
