using FluentAssertions;
using Lib;

namespace Tests;

public class CommandParserTests
{
    private readonly string[] input = LineBreaker.Break(Test.Input);

    [Test]
    public void BreaksLines()
    {
        CommandParser.Parse(input).Count().Should().Be(10);
    }

    [Test]
    public void RecognisesLs()
    {
        CommandParser.Parse(new string[] {"$ ls"}).First().Should().BeOfType<LsCommand>();
    }

    [Test]
    public void RecognisesCd()
    {
        CommandParser.Parse(new string[] {"$ cd .."}).First().Should().BeAssignableTo(typeof(CdCommand));
    }

    [Test]
    public void RecognisesCdDirections()
    {
        CommandParser.Parse(new string[] {"$ cd .."}).First().Should().BeOfType<CdUpCommand>();
        CommandParser.Parse(new string[] {"$ cd a"}).First().Should().BeOfType<CdDownCommand>();
        CommandParser.Parse(new string[] {"$ cd /"}).First().Should().BeOfType<CdTopCommand>();
    }

    [Test]
    public void CdDownHasAName()
    {
        (CommandParser.Parse(new string[] {"$ cd subfolder"}).First() as CdDownCommand).Folder.Should().Be("subfolder");
    }
}