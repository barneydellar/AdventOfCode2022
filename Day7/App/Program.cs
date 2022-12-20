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
        
        var smallDirectories = parser.Directories.Where(d => d.Size < 100000);
        Console.WriteLine(smallDirectories.Sum(d => d.Size));
    }
}