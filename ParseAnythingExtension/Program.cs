
using ParseAnything;

var numberAsText = "123".AsSpan();

var point2d = Point2d.Parse(numberAsText);

Console.WriteLine(point2d);


public static class ParsableExtensions
{
    public static T Parse<T>(this string input, IFormatProvider? formatProvider = null)
        where T : IParsable<T>
    {
        return T.Parse(input, formatProvider);
    }
}