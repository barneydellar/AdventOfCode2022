namespace Rucksacks;

public static class FileReader
{
    public static List<string> Lines(string path)
    {
        return File.ReadLines(path).ToList();
    }
}