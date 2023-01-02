using AdventOfCode.Common;
using APIAdventOfCode.Puzzles._2022.Objects;

namespace AdventOfCode.Puzzles._2022.Challenges;

public class ChallengeSix2022
{
    public static string GetPacket()
    {
        Communique elfCommunique = GetCommunique();
        CommsMarker firstMarker = elfCommunique.FirstMarker;

        return firstMarker.CharsToMarker + " : " + firstMarker.Marker;
    }

    private static Communique GetCommunique()
    {
        String inputFilePath = "Puzzles\\_2022\\Input\\SixInput.txt";
        IEnumerable<String> fullCommunique = FileService.ReadStringInput(inputFilePath);
        ValidateCommunique(fullCommunique);
        return new Communique(fullCommunique.First());
    }

    private static void ValidateCommunique(IEnumerable<String> fullCommunique)
    {
        if (fullCommunique.Count() != 1)
        {
            throw new Exception("Expecting only a single communique in packet; found " + fullCommunique.Count());
        }
    }
}


