using AdventOfCode._2022.Two.Objects;
using AdventOfCode.Common;

namespace AdventOfCode._2022.Two;

public class ChallengeTwo2022
{
    public static string GetScore()
    {
        IEnumerable<CheatEntry> cheatSheet = ReadCheatSheet();
        return cheatSheet.Select(x => x.MatchPoints).Sum().ToString();
    }
    
    private static IEnumerable<CheatEntry> ReadCheatSheet()
    {
        string inputFilePath = "2022\\Two\\TwoInput.txt";
        return FileService.ReadStringInput(inputFilePath)
            .Select(x => x.Split(' '))
            .Select(x => new CheatEntry(x[0], x[1]));
    }
}