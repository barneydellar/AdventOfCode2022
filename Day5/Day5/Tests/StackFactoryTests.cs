using FluentAssertions;
using Library;

namespace Tests;

public class StackFactoryTests
{
    /*
     *     [D] 
     * [N] [C] 
     * [Z] [M] [P]
     *  1   2   3
     */

    [Test]
    public void TakesInAListOfStrings()
    {
        StackFactory.CreateStacks(new List<string>());
    }
    
    [Test]
    public void ReturnsADictionaryOfStacks()
    {
        Dictionary<int, Stack<char>> stacks = StackFactory.CreateStacks(new List<string>());
    }
    
    [Test]
    public void CanParseASingleEntryIntoASingleStackWithTheIndex_1()
    {
        var stacks = StackFactory.CreateStacks(new List<string>{"[X]"});
        stacks.Count.Should().Be(1);
        stacks.Keys.First().Should().Be(1);
    }
    
    [Test]
    public void CanParseASingleEntryIntoASingleStackWithTheRightSize()
    {
        var stacks = StackFactory.CreateStacks(new List<string>{"[X]"});
        stacks[1].Count.Should().Be(1);
    }
    
    [Test]
    public void CanParseASingleEntryIntoASingleStackWithTheRightContent()
    {
        const char c = 'X';
        var stacks = StackFactory.CreateStacks(new List<string>{$"[{c}]"});
        stacks[1].Peek().Should().Be(c);
    }
    
    [Test]
    public void CanParseASingleLineIntoTwoStacksWithTheRightContent()
    {
        const char c1 = 'X';
        const char c2 = 'y';
        var stacks = StackFactory.CreateStacks(new List<string>{$"[{c1}] [{c2}]"});
        stacks.Count.Should().Be(2);
        stacks[1].Count.Should().Be(1);
        stacks[2].Count.Should().Be(1);
        stacks[1].Peek().Should().Be(c1);
        stacks[2].Peek().Should().Be(c2);
    }
    
    [Test]
    public void CanParseASingleLineWithAnInitialGap()
    {
        const char c = 'X';
        var stacks = StackFactory.CreateStacks(new List<string>{$"    [{c}]"});
        stacks.Count.Should().Be(2);
        stacks[1].Count.Should().Be(0);
        stacks[2].Count.Should().Be(1);
        stacks[2].Peek().Should().Be(c);
    }
    
    [Test]
    public void CanParseMultipleLines()
    {
        var stacks = StackFactory.CreateStacks(new List<string>{
        "    [D]    ", 
        "[N] [C]    ",
        "[Z] [M] [P]"
        });
        stacks.Count.Should().Be(3);
        stacks[1].Count.Should().Be(2);
        stacks[2].Count.Should().Be(3);
        stacks[3].Count.Should().Be(1);

        stacks[1].Pop().Should().Be('N');
        stacks[1].Pop().Should().Be('Z');
        
        stacks[2].Pop().Should().Be('D');
        stacks[2].Pop().Should().Be('C');
        stacks[2].Pop().Should().Be('M');
        
        stacks[3].Pop().Should().Be('P');

    }
    
    [Test]
    public void StopsParsingWhenItReachesTheEnd()
    {
        var stacks = StackFactory.CreateStacks(new List<string>{
            "    [D]    ", 
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 "
        });
        stacks.Count.Should().Be(3);
        stacks[1].Count.Should().Be(2);
        stacks[2].Count.Should().Be(3);
        stacks[3].Count.Should().Be(1);

        stacks[1].Pop().Should().Be('N');
        stacks[1].Pop().Should().Be('Z');
        
        stacks[2].Pop().Should().Be('D');
        stacks[2].Pop().Should().Be('C');
        stacks[2].Pop().Should().Be('M');
        
        stacks[3].Pop().Should().Be('P');
    }
}