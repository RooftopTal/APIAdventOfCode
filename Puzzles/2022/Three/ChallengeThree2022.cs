using AdventOfCode._2022.Two.Objects;
using AdventOfCode.Common;
using APIAdventOfCode.Puzzles._2022.Three;

namespace AdventOfCode._2022.Three;

public class ChallengeThree2022
{
    public static string GetTotalPriority()
    {
        IEnumerable<Rucksack> rucksacks = ReadCheatSheet();
        return rucksacks.Select(x => x.GetRucksackPriority()).Sum().ToString();
    }
    
    private static IEnumerable<Rucksack> ReadCheatSheet()
    {
        string inputFilePath = "2022\\Three\\ThreeInput.txt";
        return FileService.ReadStringInput(inputFilePath)
            .Select(x => new Rucksack(x));
    }
}