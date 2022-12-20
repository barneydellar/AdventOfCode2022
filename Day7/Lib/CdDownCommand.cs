namespace Lib;

public class CdDownCommand : Content
{
    public CdDownCommand(string command)
    {
        Folder = command[5..];
    }
    public string Folder { get; }
}