namespace Library;

public class MovementFactory
{
    public static List<Movement> CreateMoves(List<string> lines)
    {
        return (
            from line in lines where line.StartsWith("move ")
            select line.Split(' ') into words 
            let amount = int.Parse(words[1])
            let source = int.Parse(words[3]) 
            let destination = int.Parse(words[5])
            select new Movement(amount, source, destination)
        ).ToList();
    }
}