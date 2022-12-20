namespace Lib;

public class ContentsReader
{
    public static IEnumerable<Content> Read(IEnumerable<string> input)
    {
        return input.Where(L => !L.StartsWith("$ ")).Select(Read);
    }

    private static Content Read(string s)
    {
        if (s.StartsWith("dir "))
        {
            return new DirectoryContent();
        }

        return new FileContent(s);
    }
}