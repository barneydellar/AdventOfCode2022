namespace Rucksacks
{
    internal class Program
    {
        private static void Main()
        {
            var lines = FileReader.Lines("rucksacks.txt");

            var score = lines.Sum(line => Letter.Score(LineSplitter.Split(line).CommonLetter));

            Console.WriteLine($"Total Score = {score}");
        }
    }
}