using FluentAssertions;
using Library;

namespace Tests;

using Stacks = Dictionary<int, Stack<char>>;

public class GiantCargoCraneTest
{
    [Test]
    public void TakesInStacksAndMoves()
    {
        var stacks = new Stacks();
        var moves = new List<Movement>();
        var crane = new GiantCargoCrane(stacks, moves);
    }
    
    [Test]
    public void RunAndProducesNewStacks()
    {
        var stacks = new Stacks();
        var moves = new List<Movement>();
        var crane = new GiantCargoCrane(stacks, moves);
        
        Stacks newStacks = crane.Run();
    }
    
    [Test]
    public void GeneratedStacksAreTheSameSizeAsTheInput()
    {
        var stacks = new Stacks{{1, new Stack<char>()}, {2, new Stack<char>()}};
        var moves = new List<Movement>();
        var crane = new GiantCargoCrane(stacks, moves);
        
        var newStacks = crane.Run();
        
        newStacks.Count.Should().Be(2);
    }
    
    [Test]
    public void GeneratedStacksHaveTheSameIndicesAsTheInput()
    {
        var stacks = new Stacks{{3, new Stack<char>()}, {5, new Stack<char>()}};
        var moves = new List<Movement>();
        var crane = new GiantCargoCrane(stacks, moves);
        
        var newStacks = crane.Run();
        
        newStacks.First().Key.Should().Be(3);
        newStacks.Last().Key.Should().Be(5);
    }
    
    [Test]
    public void IfThereAreNoMovesThenTheGeneratedStacksAreTheSameAsTheInput()
    {
        var stacks = new Stacks{{3, new Stack<char>(new []{'a', 'b'})}, {5, new Stack<char>(new []{'c', 'd', 'e'})}};
        var moves = new List<Movement>();
        var crane = new GiantCargoCrane(stacks, moves);
        
        var newStacks = crane.Run();
        
        newStacks[3].Pop().Should().Be('b');
        newStacks[3].Pop().Should().Be('a');
        newStacks[5].Pop().Should().Be('e');
        newStacks[5].Pop().Should().Be('d');
        newStacks[5].Pop().Should().Be('c');
    }
    
    [Test]
    public void MovesHaveAnEffect()
    {
        var stacks = new Stacks{{3, new Stack<char>(new []{'a', 'b'})}, {5, new Stack<char>(new []{'c', 'd', 'e'})}};
        var moves = new List<Movement>{new(1, 5, 3)};
        var crane = new GiantCargoCrane(stacks, moves);
        
        var newStacks = crane.Run();
        
        newStacks[3].Count.Should().Be(3);
        newStacks[3].Pop().Should().Be('e');
        newStacks[3].Pop().Should().Be('b');
        newStacks[3].Pop().Should().Be('a');
        newStacks[5].Count.Should().Be(2);
        newStacks[5].Pop().Should().Be('d');
        newStacks[5].Pop().Should().Be('c');
    }
    
    [Test]
    public void MovesWithMultipleAmountsHaveAnEffect()
    {
        var stacks = new Stacks{{3, new Stack<char>(new []{'a', 'b'})}, {5, new Stack<char>(new []{'c', 'd', 'e'})}};
        var moves = new List<Movement>{new(3, 5, 3)};
        var crane = new GiantCargoCrane(stacks, moves);
        
        var newStacks = crane.Run();
        
        newStacks[3].Count.Should().Be(5);
        newStacks[3].Pop().Should().Be('e');
        newStacks[3].Pop().Should().Be('d');
        newStacks[3].Pop().Should().Be('c');
        newStacks[3].Pop().Should().Be('b');
        newStacks[3].Pop().Should().Be('a');
        newStacks[5].Count.Should().Be(0);
    }
    
    [Test]
    public void FullTest()
    {
        var input = new List<string>
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",    
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };
        var stacks = StackFactory.CreateStacks(input);
        var moves = MovementFactory.CreateMoves(input);
        var crane = new GiantCargoCrane(stacks, moves);
        
        var newStacks = crane.Run();
        
        newStacks[1].Count.Should().Be(1);
        newStacks[2].Count.Should().Be(1);
        newStacks[3].Count.Should().Be(4);
    
        newStacks[1].Pop().Should().Be('M');
        newStacks[2].Pop().Should().Be('C');
        newStacks[3].Pop().Should().Be('D');
        newStacks[3].Pop().Should().Be('N');
        newStacks[3].Pop().Should().Be('Z');
        newStacks[3].Pop().Should().Be('P');
    }
}