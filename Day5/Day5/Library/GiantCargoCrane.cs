namespace Library;

public class GiantCargoCrane
{
    private readonly Dictionary<int, Stack<char>> _stacks;
    private readonly List<Movement> _moves;

    public GiantCargoCrane(Dictionary<int, Stack<char>> stacks, List<Movement> moves)
    {
        _stacks = stacks;
        _moves = moves;
    }

    public Dictionary<int, Stack<char>> Run()
    {
        var newStacks = CopyInput();

        foreach (var move in _moves)
        {
            var craneStack = new Stack<char>();
            for (var i = 0; i < move.Amount; i++) {
                craneStack.Push(newStacks[move.Source].Pop());
            }
            for (var i = 0; i < move.Amount; i++) {
                newStacks[move.Destination].Push(craneStack.Pop());
            }
        }
        
        return newStacks;
    }

    private Dictionary<int, Stack<char>> CopyInput()
    {
        var newStacks = new Dictionary<int, Stack<char>>();
        foreach (var (index, stack) in _stacks)
        {
            newStacks.Add(index, new Stack<char>(stack.Reverse()));
        }
        return newStacks;
    }
}