namespace Lib;

public class CdDownCommand : Content
{
    public CdDownCommand(string folder)
    {
        Folder = folder;
    }
    public string Folder { get; }
}