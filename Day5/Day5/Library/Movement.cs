namespace Library;

public class Movement
{
    public Movement(int amount, int source, int destination)
    {
        Amount = amount;
        Source = source;
        Destination = destination;
    }
    public int Amount { get; }
    public int Source { get; }
    public int Destination { get; }
    
}