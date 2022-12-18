namespace Lib;

public class FileContent : Content
{
    public FileContent(string input)
    {
        Size = int.Parse(input.Split(" ").First());
    }
    public int Size { get; }
}