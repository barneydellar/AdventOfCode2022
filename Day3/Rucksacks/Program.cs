namespace Rucksacks
{
    internal class Program
    {
        private static void Main()
        {
            var lines = FileReader.Lines("rucksacks.txt");

            var groups = TripleLine.Grouper(lines);
            var score = groups.Sum(group => Letter.Score(group.CommonLetter));
            Console.WriteLine(score);
        }
    }
}