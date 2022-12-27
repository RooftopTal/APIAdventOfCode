using AdventOfCode.Common;
using APIAdventOfCode.Puzzles._2022.Four.Objects;

namespace APIAdventOfCode.Puzzles._2022.Four
{
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
            string inputFilePath = "2022\\Four\\FourInput.txt";
            return FileService.ReadStringInput(inputFilePath)
                .Select(x => new ElfAssignment(x));
          
        }
    }
}

