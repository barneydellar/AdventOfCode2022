using FluentAssertions;
using Library;

namespace Tests;

public class MovementFactoryTests
{
    /*
     * move 1 from 2 to 1
     * move 3 from 1 to 3
     * move 2 from 2 to 1
     * move 1 from 1 to 2
     */
    
    [Test]
    public void TakesInAListOfStrings()
    {
        MovementFactory.CreateMoves(new List<string>());
    }
    
    [Test]
    public void ReturnsAListOfMoves()
    {
        List<Movement> moves = MovementFactory.CreateMoves(new List<string>());
    }
    
    [Test]
    public void ReturnsAnEmptyListForIrrelevantData()
    {
        var input = new List<string>
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 "
        };
        var moves = MovementFactory.CreateMoves(input);
        moves.Count.Should().Be(0);
    }
    
    [Test]
    public void ReturnsAnSingleMoveForOneLine()
    {
        var input = new List<string> {"move 1 from 2 to 1"};
        var moves = MovementFactory.CreateMoves(input);
        moves.Count.Should().Be(1);
    }
    
    [Test]
    public void ReturnsTwoMovesForTwoLines() 
    {
        var input = new List<string>
        {
            "move 1 from 2 to 1",
            "move 3 from 1 to 3"
        };
        var moves = MovementFactory.CreateMoves(input);
        moves.Count.Should().Be(2);
    }
    
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(12)]
    public void MovementsHaveTheCorrectAmount(int amount)
    {
        var input = new List<string> {$"move {amount} from 2 to 1"};
        var moves = MovementFactory.CreateMoves(input);
        moves[0].Amount.Should().Be(amount);
    }
    
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(15)]
    public void MovementsHaveTheCorrectSourceStack(int source)
    {
        var input = new List<string> {$"move 5 from {source} to 1"};
        var moves = MovementFactory.CreateMoves(input);
        moves[0].Source.Should().Be(source);
    }
    
    [TestCase(2)]
    public void MovementsHaveTheCorrectDestinationStack(int destination)
    {
        var input = new List<string> {$"move 5 from 2 to {destination}"};
        var moves = MovementFactory.CreateMoves(input);
        moves[0].Destination.Should().Be(destination);
    }
    
    [Test]
    public void MovementsHaveTheCorrectValues()
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
        var moves = MovementFactory.CreateMoves(input);
        moves.Count.Should().Be(4);

        moves[0].Amount.Should().Be(1);
        moves[0].Source.Should().Be(2);
        moves[0].Destination.Should().Be(1);
        
        moves[1].Amount.Should().Be(3);
        moves[1].Source.Should().Be(1);
        moves[1].Destination.Should().Be(3);
        
        moves[2].Amount.Should().Be(2);
        moves[2].Source.Should().Be(2);
        moves[2].Destination.Should().Be(1);
        
        moves[3].Amount.Should().Be(1);
        moves[3].Source.Should().Be(1);
        moves[3].Destination.Should().Be(2);
    }
}