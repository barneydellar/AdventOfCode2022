namespace Lib;

public class CdDownCommand : Command
{
    public CdDownCommand(string command)
    {
        Folder = command[5..];
    }
    public string Folder { get; }
}