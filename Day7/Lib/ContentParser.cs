using System.Collections;

namespace Lib;

public class ContentParser
{
    public IList<string> Cwd
    {
        get
        {
            var list = new List<string>();
            var node = CurrentDirectory;
            while (node is not null)
            {
                list.Add(node.Name);
                node = node.Parent;
            }

            list.Reverse();
            return list;
        }
    }

    public Directory Root { get; private set; }
    private Directory CurrentDirectory { get; set; }

    public IEnumerable<Directory> Directories
    {
        get
        {
            var nodes = new Queue<Directory>();
            nodes.Enqueue(Root);
            
            while (nodes.Count > 0)
            {
                var directory = nodes.Dequeue();
                yield return directory;
                foreach (var subDirectory in directory.Children)
                {
                    nodes.Enqueue(subDirectory);
                }
            }
        }
    }

    public void Parse(IEnumerable<Content> contents)
    {
        if (!contents.Any())
        {
            return;
        }

        if (contents.First() is not CdTopCommand)
        {
            throw new Exception("uh uh");
        }

        Root = Directory.RootDirectory();
        CurrentDirectory = Root;
        foreach (var content in contents.Skip(1))
        {
            switch (content)
            {
                case LsCommand:
                    break;
                case DirectoryContent directoryContent:
                    CurrentDirectory.AddChild(directoryContent.Name);
                    break;
                case FileContent fileContent:
                    CurrentDirectory.AddFile(fileContent.Size, fileContent.Name);
                    break;
                case CdDownCommand downCommand:
                    CurrentDirectory = CurrentDirectory[downCommand.Folder];
                    break;
                case CdUpCommand:
                    CurrentDirectory = CurrentDirectory.Parent;
                    break;
                case CdTopCommand:
                    CurrentDirectory = Root;
                    break;
            }
        }
    }
}
