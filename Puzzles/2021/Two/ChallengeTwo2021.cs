using AdventOfCode._2021.Two.Objects;
using AdventOfCode.Common;

namespace AdventOfCode._2021.Two;

internal class ChallengeTwo2021
{
    public static string GetDepthXHorizontal()
    {
        IEnumerable<DirectionReading> directionReadings = ReadDirections();

        int horizontalDistance = 0;
        int verticalDistance = 0;
        int aim = 0;

        foreach (DirectionReading reading in directionReadings)
        {
            switch (reading.Bearing)
            {
                case BearingEnum.forward:
                    horizontalDistance += reading.Change;
                    verticalDistance += aim * reading.Change;
                    break;
                case BearingEnum.up:
                    aim -= reading.Change;
                    break;
                case BearingEnum.down:
                    aim += reading.Change;
                    break;
            }
        }

        int distanceMultiplied = horizontalDistance * verticalDistance;
        return distanceMultiplied.ToString();
    }

    private static IEnumerable<DirectionReading> ReadDirections()
    {
        IEnumerable<string> baseDirections = ReadSourceDirections();
        return InterpretReadings(baseDirections);
    }
    
    private static IEnumerable<DirectionReading> InterpretReadings(IEnumerable<string> baseReadings)
    {
        return baseReadings
            .Select(x => x.Split(" "))
            .Select(x => new DirectionReading(x[0], x[1]));
    }

    private static IEnumerable<string> ReadSourceDirections()
    {
        string inputFilePath = "2021\\Two\\TwoInput.txt";
        return FileService.ReadStringInput(inputFilePath);
    }
}