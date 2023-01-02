using AdventOfCode.Common;
using APIAdventOfCode.Puzzles._2022.Objects;

namespace AdventOfCode.Puzzles._2022.Challenges;

public class ChallengeSeven2022
{
    public static string GetDirectorySizes()
    {
        FileSystem fileSystem = GetFileSystem();
        //return fileSystem.GetTotalDirectorySizeUnderCutoff().ToString();
        APIAdventOfCode.Puzzles._2022.Objects.Directory dirToDelete = fileSystem.GetBestDirectoryToDelete();
        return dirToDelete.FindDirectorySize().ToString();
    }

    private static FileSystem GetFileSystem()
    {
        String inputFilePath = "_2022\\Input\\SevenInput.txt";
        IEnumerable<String> consoleInput = FileService.ReadStringInput(inputFilePath);
        return new FileSystem(consoleInput);
    }
}


