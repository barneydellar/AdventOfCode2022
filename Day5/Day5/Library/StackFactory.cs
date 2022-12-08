namespace Library;

using Stacks = Dictionary<int, Stack<char>>;

public class StackFactory
{
    public static Stacks CreateStacks(List<string> lines)
    {
        var stacks = new Stacks();

        if (!lines.Any())
        {
            return stacks;
        }
        var numberOfStacks = NumberOfStacks(lines);
        InitialiseStacks(numberOfStacks, stacks);
        ReadStackData(lines, numberOfStacks, stacks);
        ReverseStacks(numberOfStacks, stacks);

        return stacks;
    }

    private static void ReverseStacks(int numberOfStacks, Stacks stacks)
    {
        for (var i = 1; i < numberOfStacks + 1; i++)
        {
            var newStack = new Stack<char>();
            foreach (var c in stacks[i])
            {
                newStack.Push(c);
            }

            stacks[i] = newStack;
        }
    }

    private static void ReadStackData(List<string> lines, int numberOfStacks, Stacks stacks)
    {
        foreach (var line in lines.TakeWhile(line => !line.StartsWith(" 1")))
        {
            for (var i = 1; i < numberOfStacks + 1; i++)
            {
                var entry = line.Substring((i - 1) * 4, 3);
                if (entry != "   ")
                {
                    stacks[i].Push(entry[1]);
                }
            }
        }
    }

    private static void InitialiseStacks(int numberOfStacks, Stacks stacks)
    {
        for (var i = 1; i < numberOfStacks + 1; i++)
        {
            stacks.Add(i, new Stack<char>());
        }
    }

    private static int NumberOfStacks(List<string> lines)
    {
        var numberOfStacks = (lines[0].Length + 1) / 4;
        return numberOfStacks;
    }
}