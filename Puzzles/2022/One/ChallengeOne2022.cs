using AdventOfCode.Common;

namespace AdventOfCode._2022.One;

public static class ChallengeOne2022
{
    public static string GetCalories()
    {
        IEnumerable<IEnumerable<int>> elfList = ReadElfList();
        IEnumerable<int> caloriesPerElf = elfList.Select(x => x.Sum());
        int topThreeCalories = caloriesPerElf
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return topThreeCalories.ToString();
    }

    private static IEnumerable<IEnumerable<int>> ReadElfList()
    {
        string inputFilePath = "2022\\One\\OneInput.txt";
        IEnumerable<string> rawCalories = FileService.ReadStringInput(inputFilePath);
        return rawCalories.ToList()
            .Split(String.IsNullOrEmpty)
            .Select(x => x.Select(int.Parse));
    }
}