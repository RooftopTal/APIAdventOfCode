using AdventOfCode.Puzzles._2021.Objects;
using AdventOfCode.Common;

namespace AdventOfCode.Puzzles._2021.Challenges;

using System;
using System.Collections.Generic;

public class ChallengeOne2021
{
    public static string GetIncreases()
    {
        IEnumerable<int> inputDepths = ReadDepths();
        return TrackDepthChanges(inputDepths).ToString();
    }

    private static int TrackDepthChanges(IEnumerable<int> inputDepths)
    {
        int increaseCount = 0;
        DepthTracker trackedDepths = new DepthTracker();
        
        foreach (int currentDepth in inputDepths)
        {
            trackedDepths.UpdateDepths(currentDepth);

            if (trackedDepths.IsTrackable() && trackedDepths.DepthIncreased())
            {
                increaseCount++;
            }
        }
        
        return increaseCount;
    }

    private static IEnumerable<int> ReadDepths()
    {
        string inputFilePath = "Puzzles\\_2021\\Input\\OneInput.txt";
        return FileService.ReadIntInput(inputFilePath);
    }
}