namespace Rucksacks;

public class LineGroup
{
    public readonly string First;
    public readonly string Second;
    public readonly string Third;

    public LineGroup(IReadOnlyList<string> lines)
    {
        First = lines[0];
        Second = lines[1];
        Third = lines[2];
    }

    public char CommonLetter => First.Intersect(Second).Intersect(Third).First();
}

public class TripleLine
{
    public static List<LineGroup> Grouper(List<string> lines)
    {
        var groups = new List<LineGroup>();
        var index = 0;
        var readLines = new[] {"", "", ""};
        foreach (var line in lines)
        {
            readLines[index++] = line;
            if (index == 3)
            {
                groups.Add(new LineGroup(readLines));
                index = 0;
            }
        }

        return groups;
    }
}