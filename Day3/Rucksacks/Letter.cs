namespace Rucksacks;

public static class Letter
{
    private static int s = 1;
    private static Dictionary<char, int> scores = new Dictionary<char, int>()
    {
        {'a', s++},
        {'b', s++},
        {'c', s++},
        {'d', s++},
        {'e', s++},
        {'f', s++},
        {'g', s++},
        {'h', s++},
        {'i', s++},
        {'j', s++},
        {'k', s++},
        {'l', s++},
        {'m', s++},
        {'n', s++},
        {'o', s++},
        {'p', s++},
        {'q', s++},
        {'r', s++},
        {'s', s++},
        {'t', s++},
        {'u', s++},
        {'v', s++},
        {'w', s++},
        {'x', s++},
        {'y', s++},
        {'z', s++},
        {'A', s++},
        {'B', s++},
        {'C', s++},
        {'D', s++},
        {'E', s++},
        {'F', s++},
        {'G', s++},
        {'H', s++},
        {'I', s++},
        {'J', s++},
        {'K', s++},
        {'L', s++},
        {'M', s++},
        {'N', s++},
        {'O', s++},
        {'P', s++},
        {'Q', s++},
        {'R', s++},
        {'S', s++},
        {'T', s++},
        {'U', s++},
        {'V', s++},
        {'W', s++},
        {'X', s++},
        {'Y', s++},
        {'Z', s++}
    };

    public static int Score(char i)
    {
        return scores[i];
    } 
}