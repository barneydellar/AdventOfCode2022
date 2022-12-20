namespace Lib;

public class File
{

    public File(int size, string name)
    {
        Size = size;
        Name = name;
    }

    public string Name { get; }
    public int Size { get; }
}