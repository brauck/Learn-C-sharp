var str = new RepeatSequence();

for (int i = 0; i < 10; i++)
    Console.WriteLine(str++);

Console.WriteLine(str);
Console.WriteLine(str);

public interface IGetNext<T> where T : IGetNext<T>
{
    static abstract T operator ++(T other);
}

public struct RepeatSequence : IGetNext<RepeatSequence>
{
    private const char Ch = 'A';
    private string Text = new string(Ch, 1);

    public RepeatSequence() { }

    public static RepeatSequence operator ++(RepeatSequence other)
        => other with { Text = other.Text + Ch };

    public override string ToString() => Text;
}

