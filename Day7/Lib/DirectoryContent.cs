namespace Lib;

public class DirectoryContent : Content
{
    public DirectoryContent(string name)
    {
        Name = name;
    }

    public string Name { get; }
}