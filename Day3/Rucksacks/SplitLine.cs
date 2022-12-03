namespace Rucksacks;

public class SplitLine
{
    public readonly string First;
    public readonly string Second;

    public SplitLine(string first, string second)
    {
        First = first;
        Second = second;
    }

    public char CommonLetter => First.Intersect(Second).First();
}