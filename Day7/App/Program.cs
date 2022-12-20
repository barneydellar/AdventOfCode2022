// See https://aka.ms/new-console-template for more information


using Lib;
using File = System.IO.File;

namespace App;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = File.ReadLines("input.txt").ToList();
        var contents = ContentsReader.Read(input);
        var parser = new ContentParser();
        
        parser.Parse(contents);

        const int freeSpace = 70000000;
        const int totalSpaceNeeded = 30000000;
        var totalSpaceUsed = parser.Root.Size;
        var currentFreeSpace = freeSpace - totalSpaceUsed;
        var spaceNeeded = totalSpaceNeeded - currentFreeSpace;
        
        var smallDirectories = parser.Directories.Where(d => d.Size >= spaceNeeded);
        
        var orderedDirectories = smallDirectories.OrderBy(d => d.Size);
        
        Console.WriteLine($"{orderedDirectories.First().Name} - {orderedDirectories.First().Size}. ");
    }
}