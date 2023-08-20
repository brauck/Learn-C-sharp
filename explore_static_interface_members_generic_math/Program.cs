// Note: Not complete. This won't compile yet.
using System.Numerics;

var pt = new Point<int>(3, 4);

var translate = new Translation<int>(5, 10);

var final = pt + translate;

//Console.WriteLine("фывпвыфв");

Console.WriteLine(pt);
Console.WriteLine(translate);
Console.WriteLine(final);

public record Translation<T>(T XOffset, T YOffset) : IAdditiveIdentity<Translation<T>, Translation<T>>
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
{
    public static Translation<T> AdditiveIdentity =>
        new Translation<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
}

public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Translation<T>, Point<T>>
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
{
    public static Point<T> operator +(Point<T> left, Translation<T> right) =>
        left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
}

/*class Program
{
    static void Main(string[] args)
    {
        var pt = new Point<int>(3, 4);

        var translate = new Translation<int>(5, 10);

        var final = pt + translate;

        Console.WriteLine(pt);
        Console.WriteLine(translate);
        Console.WriteLine(final);
        // Display the number of command line arguments.
        Console.WriteLine(args.Length);
    }
}*/