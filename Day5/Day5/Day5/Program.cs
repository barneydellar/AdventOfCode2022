using Library;

namespace Day5;

internal class Program
{
    private static void Main()
    {
        var lines = FileReader.Lines("input.txt");
        
        var stacks = StackFactory.CreateStacks(lines);
        var moves = MovementFactory.CreateMoves(lines);
        var crane = new GiantCargoCrane(stacks, moves);
        
        var newStacks = crane.Run();

        foreach (var (_, stack) in newStacks) 
        {
            Console.Write(stack.Pop());
        }
    }
}