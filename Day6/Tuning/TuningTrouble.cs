namespace Tuning;

public class TuningTrouble
{
    private string _input;
    private const int Size = 14;
    public void Process(string input)
    {
        _input = input;
    }

    public int FirstMarker  {
        get
        {
            var gs = Groups(_input);
            var i = Size;
            foreach (var g in gs)
            {
                if (AllUnique(g))
                {
                    return i;
                }

                i++;
            }

            return 0;
        }
    }

    public string[] Groups(string input)
    {
        var groups = new List<string>();
        var length = input.Length;
        for (var i = 0; i <= length - Size; i++)
        {
            var skipped = input.Skip(i);
            var taken = skipped.Take(Size);
            groups.Add(new string(taken.ToArray(), 0, Size));
        }

        return groups.ToArray();
    }

    public bool AllUnique(string input)
    {
        return input.Distinct().Count() == input.Length;
    }
}