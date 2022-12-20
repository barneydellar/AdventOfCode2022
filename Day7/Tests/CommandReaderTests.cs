using FluentAssertions;
using Lib;

namespace Tests;

public class CommandParserTests
{
    private readonly string[] input = LineBreaker.Break(Test.Input);

    [Test]
    public void BreaksLines()
    {
        CommandReader.Read(input).Count().Should().Be(10);
    }

    [Test]
    public void RecognisesLs()
    {
        CommandReader.Read(new[] {"$ ls"}).First().Should().BeOfType<LsCommand>();
    }

    [Test]
    public void RecognisesCd()
    {
        CommandReader.Read(new[] {"$ cd .."}).First().Should().BeAssignableTo(typeof(CdCommand));
    }

    [Test]
    public void RecognisesCdDirections()
    {
        CommandReader.Read(new[] {"$ cd .."}).First().Should().BeOfType<CdUpCommand>();
        CommandReader.Read(new[] {"$ cd a"}).First().Should().BeOfType<CdDownCommand>();
        CommandReader.Read(new[] {"$ cd /"}).First().Should().BeOfType<CdTopCommand>();
    }

    [Test]
    public void CdDownHasAName()
    {
        (CommandReader.Read(new[] {"$ cd subfolder"}).First() as CdDownCommand)?.Folder.Should().Be("subfolder");
    }
}