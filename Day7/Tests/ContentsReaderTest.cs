using FluentAssertions;
using Lib;

namespace Tests;

public class ContentsReaderTest
{
    
    [Test]
    public void ContentsCanBeFound()
    {
        var input = LineBreaker.Break(Test.Input);
        ContentsReader.Read(input).Count().Should().Be(23);
    }
    
    [Test]
    public void ContentsCanBeFiles()
    {
        ContentsReader.Read(new[] {"29116 f"}).First().Should().BeOfType<FileContent>();
    }
    
    [Test]
    public void ContentsCanBeDirectories()
    {
        ContentsReader.Read(new[] {"dir f"}).First().Should().BeOfType<DirectoryContent>();
    }
    
    [Test]
    public void DirectoriesHaveNames()
    {
        (ContentsReader.Read(new[] {"dir f"}).First() as DirectoryContent).Name.Should().Be("f");
    }
    
    [Test]
    public void FilesHaveASize()
    {
        (ContentsReader.Read(new[] {"29116 f"}).First() as FileContent)?.Size.Should().Be(29116);
        (ContentsReader.Read(new[] {"3 log.log"}).First() as FileContent)?.Size.Should().Be(3);
    }

    [Test]
    public void RecognisesLs()
    {
        ContentsReader.Read(new[] {"$ ls"}).First().Should().BeOfType<LsCommand>();
    }

    [Test]
    public void RecognisesCd()
    {
        ContentsReader.Read(new[] {"$ cd .."}).First().Should().BeAssignableTo(typeof(CdUpCommand));
    }

    [Test]
    public void RecognisesCdDirections()
    {
        ContentsReader.Read(new[] {"$ cd .."}).First().Should().BeOfType<CdUpCommand>();
        ContentsReader.Read(new[] {"$ cd a"}).First().Should().BeOfType<CdDownCommand>();
        ContentsReader.Read(new[] {"$ cd /"}).First().Should().BeOfType<CdTopCommand>();
    }

    [Test]
    public void CdDownHasAName()
    {
        (ContentsReader.Read(new[] {"$ cd subfolder"}).First() as CdDownCommand)?.Folder.Should().Be("subfolder");
    }
}