using System.Reflection;

namespace AdventOfCode.Common;

public class FileService
{
    public static IEnumerable<string> ReadStringInput(string inputPath)
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string path = Path.Combine(baseDirectory, inputPath);
        return File.ReadLines(path);
    }

    public static IEnumerable<int> ReadIntInput(string inputPath)
    {
        return ReadStringInput(inputPath).Select(Int32.Parse);
    }
    
    public static IEnumerable<T> ReadEnumInput<T>(string inputPath) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum) 
        {
            throw new ArgumentException("T must be an enumerated type");
        }

        return ReadStringInput(inputPath)
            .Select(x => (T)Enum.Parse(typeof(T), x));
    }
}