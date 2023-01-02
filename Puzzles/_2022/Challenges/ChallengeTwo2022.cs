using AdventOfCode.Common;
using APIAdventOfCode.Puzzles._2022.Objects;

namespace AdventOfCode.Puzzles._2022.Challenges;

public class ChallengeTwo2022
{
    public static string GetScore()
    {
        IEnumerable<CheatEntry> cheatSheet = ReadCheatSheet();
        return cheatSheet.Select(x => x.MatchPoints).Sum().ToString();
    }

    private static IEnumerable<CheatEntry> ReadCheatSheet()
    {
        string inputFilePath = "Puzzles\\_2022\\Input\\TwoInput.txt";
        return FileService.ReadStringInput(inputFilePath)
            .Select(x => x.Split(' '))
            .Select(x => new CheatEntry(x[0], x[1]));
    }
}