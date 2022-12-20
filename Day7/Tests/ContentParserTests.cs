using FluentAssertions;
using Lib;

namespace Tests;

public class ContentParserTests
{
    [Test]
    public void TakesInContent()
    {
        var contents = new List<Content>();
        var parser = new ContentParser();
        parser.Parse(contents);
    }
    
    [Test]
    public void InitiallyHasNoCurrentDirectory()
    {
        var parser = new ContentParser();
        parser.Cwd.Should().BeEmpty();
    }
    
    [Test]
    public void TheRootDirectoryMustComeFirst()
    {
        var contents = new List<Content> {new CdTopCommand()};
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Cwd.Count.Should().Be(1);
        parser.Cwd.First().Should().Be("/");
    }
    
    [Test]
    public void ANonRootDirectoryCannotBeFirst()
    {
        var contents = new List<Content> {new CdDownCommand("d")};
        var parser = new ContentParser();
        var parse = () => { parser.Parse(contents); };
        parse.Should().Throw<Exception>();
        parser.Cwd.Should().BeEmpty();
    }
    
    [TestCase("d")]
    [TestCase("Next")]
    [TestCase("﷽")]
    public void ASecondDirectoryCanBeSet(string folder)
    {
        var contents = new List<Content>
        {
            new CdTopCommand(),
            new LsCommand(), 
            new DirectoryContent(folder),
            new CdDownCommand(folder)
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Cwd.Count.Should().Be(2);
        parser.Cwd[0].Should().Be("/");
        parser.Cwd[1].Should().Be(folder);
    }
    
    [TestCase("d", "e")]
    [TestCase("This", "Next")]
    [TestCase("﷽", "﷽")]
    public void AThirdDirectoryCanBeSet(string f, string g)
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new DirectoryContent(f),
            new CdDownCommand(f), 
            new LsCommand(), 
            new DirectoryContent(g),
            new CdDownCommand(g)
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Cwd.Count.Should().Be(3);
        parser.Cwd[0].Should().Be("/");
        parser.Cwd[1].Should().Be(f);
        parser.Cwd[2].Should().Be(g);
    }
    
    [Test]
    public void DirectoriesCanGoUp()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(),
            new LsCommand(), 
            new DirectoryContent("f"),
            new CdDownCommand("f"), 
            new CdUpCommand()
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Cwd.Count.Should().Be(1);
        parser.Cwd[0].Should().Be("/");
    }
    
    [Test]
    public void DirectoriesCanGoUp_MoreComplicated()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new DirectoryContent("f"),
            new CdDownCommand("f"), 
            new DirectoryContent("h"),
            new LsCommand(), 
            new DirectoryContent("g"),
            new CdDownCommand("g"), 
            new CdUpCommand(),
            new CdDownCommand("h"), 
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Cwd.Count.Should().Be(3);
        parser.Cwd[0].Should().Be("/");
        parser.Cwd[1].Should().Be("f");
        parser.Cwd[2].Should().Be("h");
    }
    
    [Test]
    public void DirectoriesCanGoBackToRoot()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new DirectoryContent("f"),
            new CdDownCommand("f"), 
            new LsCommand(), 
            new DirectoryContent("g"),
            new DirectoryContent("h"),
            new CdDownCommand("g"), 
            new CdUpCommand(),
            new CdDownCommand("h"), 
            new CdTopCommand(), 
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Cwd.Count.Should().Be(1);
        parser.Cwd[0].Should().Be("/");
    }

    [Test]
    public void InitiallyRootIsNull()
    {
        var parser = new ContentParser();
        parser.Root.Should().BeNull();
    }

    [Test]
    public void RootHasNoParent()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Parent.Should().BeNull();
    }

    [Test]
    public void RootHasTheRightName()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Name.Should().Be("/");
    }

    [Test]
    public void LsPopulatesADirectory()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new DirectoryContent("a")
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Children.Count.Should().Be(1);
        parser.Root.Children[0].Name.Should().Be("a");
    }

    [Test]
    public void LsPopulatesDirectories()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new DirectoryContent("a"),
            new DirectoryContent("b"),
            new DirectoryContent("c")
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Children.Count.Should().Be(3);
        parser.Root.Children[0].Name.Should().Be("a");
        parser.Root.Children[1].Name.Should().Be("b");
        parser.Root.Children[2].Name.Should().Be("c");
    }

    [Test]
    public void DirectoriesStartWithNoFiles()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Files.Count.Should().Be(0);
    }

    [Test]
    public void LsPopulatesFiles()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new FileContent(132, "log.txt")
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Files.Count.Should().Be(1);
    }
    
    [Test]
    public void LsPopulatesFilesWithTheRightNameAndSize()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new FileContent(132, "log.txt")
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Files[0].Name.Should().Be("log.txt");
        parser.Root.Files[0].Size.Should().Be(132);
    }
    
    [Test]
    public void DirectorySizeIsTheSumOfTheFilesWhenThereAreNoChildren()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new FileContent(1, "log.1"),
            new FileContent(2, "log.2"),
            new FileContent(3, "log.3"),
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Size.Should().Be(6);
    }
    
    [Test]
    public void DirectorySizeIncludesChildren()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new DirectoryContent("X"),
            new CdDownCommand("X"),
            new LsCommand(), 
            new FileContent(1, "log.1"),
            new FileContent(2, "log.2"),
            new FileContent(3, "log.3"),
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Size.Should().Be(6);
    }
    
    [Test]
    public void DirectorySizeIncludesFilesAndChildren()
    {
        var contents = new List<Content>
        {
            new CdTopCommand(), 
            new LsCommand(), 
            new FileContent(10, "log.1"),
            new DirectoryContent("X"),
            new CdDownCommand("X"),
            new LsCommand(), 
            new FileContent(1, "log.1"),
            new FileContent(2, "log.2"),
            new FileContent(3, "log.3"),
        };
        var parser = new ContentParser();
        parser.Parse(contents);
        parser.Root.Size.Should().Be(16);
    }

    [Test]
    public void IntegrationSizeTest()
    {
        var input = LineBreaker.Break(Test.Input);
        var contents = ContentsReader.Read(input);
        var parser = new ContentParser();
        
        parser.Parse(contents);

        parser.Root["a"]["e"].Size.Should().Be(584);
        parser.Root["a"].Size.Should().Be(94853);
        parser.Root["d"].Size.Should().Be(24933642);
        parser.Root.Size.Should().Be(48381165);
    }

    [Test]
    public void DirectoriesCanBeEnumerated()
    {
        var input = LineBreaker.Break(Test.Input);
        var contents = ContentsReader.Read(input);
        var parser = new ContentParser();
        
        parser.Parse(contents);

        parser.Directories.Count().Should().Be(4);
    }

    [Test]
    public void DirectoriesWithSizeUnder100000CanBeFound()
    {
        var input = LineBreaker.Break(Test.Input);
        var contents = ContentsReader.Read(input);
        var parser = new ContentParser();
        
        parser.Parse(contents);

        var smallDirectories = parser.Directories.Where(d => d.Size < 100000);
        smallDirectories.Count().Should().Be(2);
        smallDirectories.Any(d => d.Name == "a").Should().BeTrue();
        smallDirectories.Any(d => d.Name == "e").Should().BeTrue();
    }

    [Test]
    public void DirectoriesWithSizeUnder100000CanBeFoundAmdSummed()
    {
        var input = LineBreaker.Break(Test.Input);
        var contents = ContentsReader.Read(input);
        var parser = new ContentParser();
        
        parser.Parse(contents);

        var smallDirectories = parser.Directories.Where(d => d.Size < 100000);
        smallDirectories.Sum(d => d.Size).Should().Be(95437);
    }
    
}