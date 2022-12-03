namespace Rucksacks;

public static class LineSplitter
{
    public static SplitLine Split(string s)
    {
        var length = s.Length;
        if (length % 2 != 0)
        {
            throw new Exception("Only lines of even length can be split");
        }

        var halfLength = length / 2;
        var firstHalf = s[..halfLength];
        var secondHalf = s.Substring(halfLength, halfLength);

        return new SplitLine(firstHalf, secondHalf);
    }
}