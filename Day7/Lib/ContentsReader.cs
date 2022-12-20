namespace Lib;

public class ContentsReader
{
    public static IEnumerable<Content> Read(IEnumerable<string> input)
    {
        return input.Select(Read);
    }

    private static Content Read(string s)
    {
        if (s.StartsWith("$ ")) {
            if (s.Equals("$ ls"))
            {
                return new LsCommand();
            }
            if (s.EndsWith(" .."))
            {
                return new CdUpCommand();
            }
            if (s.EndsWith(" /"))
            {
                return new CdTopCommand();
            }
            return new CdDownCommand(s[5..]);
        }
        
        if (s.StartsWith("dir "))
        {
            return new DirectoryContent(s[4..]);
        }

        var fileNameAndSize = s.Split(" ");
        return new FileContent(int.Parse(fileNameAndSize.First()), fileNameAndSize.Last());
    }
}