using AdventOfCode.Common;
using APIAdventOfCode.Puzzles._2022.Objects;

namespace AdventOfCode.Puzzles._2022.Challenges;

public class ChallengeFour2022
{
    public static string GetMatchingIDs()
    {
        IEnumerable<ElfAssignment> elfAssignments = GetElfAssignments();
        return elfAssignments
            .Where(x => x.ElvesOverlap())
            .Count()
            .ToString();
    }

    private static IEnumerable<ElfAssignment> GetElfAssignments()
    {
        string inputFilePath = "Puzzles\\_2022\\Input\\FourInput.txt";
        return FileService.ReadStringInput(inputFilePath)
            .Select(x => new ElfAssignment(x));
          
    }
}

