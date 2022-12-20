using FluentAssertions;
using Lib;

namespace Tests;

public class ContentsReaderTest
{
    private readonly string[] input = LineBreaker.Break(Test.Input);
    
    [Test]
    public void ContentsCanBeFound()
    {
        ContentsReader.Read(input).Count().Should().Be(13);
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
    public void FilesHaveASize()
    {
        (ContentsReader.Read(new[] {"29116 f"}).First() as FileContent)?.Size.Should().Be(29116);
        (ContentsReader.Read(new[] {"3 log.log"}).First() as FileContent)?.Size.Should().Be(3);
    }
}