namespace Lib;

public class CommandParser
{
    public static IEnumerable<Command> Parse(IEnumerable<string> input)
    {
        return input.Where(L => L.StartsWith("$ ")).Select(Parse);
    }

    private static Command Parse(string s)
    {
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
        return new CdDownCommand(s);
        
    }
}