using AdventOfCode.Common;

namespace AdventOfCode.Puzzles._2022.Challenges;

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
        string inputFilePath = "_2022\\Input\\OneInput.txt";
        IEnumerable<string> rawCalories = FileService.ReadStringInput(inputFilePath);
        return rawCalories.ToList()
            .Split(String.IsNullOrEmpty)
            .Select(x => x.Select(int.Parse));
    }
}