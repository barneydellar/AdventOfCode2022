namespace Lib;

public class Directory
{   
    public static Directory RootDirectory()
    {
        return new Directory("/", null);
    }

    private Directory(string name, Directory parent)
    {
        Name = name;
        Parent = parent;
        Children = new List<Directory>();
        Files = new List<File>();
    }

    public void AddChild(string name)
    {
        Children.Add(new Directory(name, this));
    }
    public void AddFile(int size, string name)
    {
        Files.Add(new File(size, name));
    }
    
    public string Name { get; init; }
    public Directory Parent { get; init; }
    public List<Directory> Children { get; init; }
    public List<File> Files { get; init; }

    public Directory this[string name]
    {
        get
        {
            return Children.First(c => c.Name == name);
        }
    }
    
    public int Size
    {
        get
        {
            var files =  Files.Sum(f => f.Size);
            var children = Children.Sum((c => c.Size));
            return files + children;
        }
    }
}