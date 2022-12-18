using FluentAssertions;
using Lib;

namespace Tests;

public class ContentsParserTest
{
    private readonly string[] input = LineBreaker.Break(Test.Input);
    
    [Test]
    public void ContentsCanBeFound()
    {
        ContentsParser.Parse(input).Count().Should().Be(13);
    }
    
    [Test]
    public void ContentsCanBeFiles()
    {
        ContentsParser.Parse(new string[] {"29116 f"}).First().Should().BeOfType<FileContent>();
    }
    
    [Test]
    public void ContentsCanBeDirectories()
    {
        ContentsParser.Parse(new string[] {"dir f"}).First().Should().BeOfType<DirectoryContent>();
    }
    
    [Test]
    public void FilesHaveASize()
    {
        (ContentsParser.Parse(new string[] {"29116 f"}).First() as FileContent)?.Size.Should().Be(29116);
        (ContentsParser.Parse(new string[] {"3 log.log"}).First() as FileContent)?.Size.Should().Be(3);
    }
}