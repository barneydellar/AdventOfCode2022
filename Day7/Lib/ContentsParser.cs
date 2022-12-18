namespace Lib;

public class ContentsParser
{
    public static IEnumerable<Content> Parse(IEnumerable<string> input)
    {
        return input.Where(L => !L.StartsWith("$ ")).Select(Parse);
    }

    private static Content Parse(string s)
    {
        if (s.StartsWith("dir "))
        {
            return new DirectoryContent();
        }

        return new FileContent(s);
    }
}