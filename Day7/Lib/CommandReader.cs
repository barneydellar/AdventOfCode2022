namespace Lib;

public class CommandReader
{
    public static IEnumerable<Command> Read(IEnumerable<string> input)
    {
        return input.Where(L => L.StartsWith("$ ")).Select(Read);
    }

    private static Command Read(string s)
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