using AdventOfCode.Common;
using APIAdventOfCode.Puzzles._2022.Objects;

namespace AdventOfCode.Puzzles._2022.Challenges;

public class ChallengeFive2022
{
    public static string GetCraneMovements()
    {
        Craneyard craneyard = GetCraneSetup();
        IEnumerable<CraneMove> moves = GetMoves();

        foreach (CraneMove move in moves)
        {
            craneyard.ApplyMove9001(move);
        }
        IEnumerable<char> topCrates = craneyard.GetTopCrates();

        return String.Concat(topCrates);
    }

    private static Craneyard GetCraneSetup()
    {
        string inputFilePath = "_2022\\Input\\FiveInputCrane.txt";
        IEnumerable<String> craneyardLevels = FileService.ReadStringInput(inputFilePath);
        return new Craneyard(craneyardLevels);
    }

    private static IEnumerable<CraneMove> GetMoves()
    {
        string inputFilePath = "_2022\\Input\\FiveInputMoves.txt";
        return FileService.ReadStringInput(inputFilePath)
            .Select(x => new CraneMove(x));
    }
}


