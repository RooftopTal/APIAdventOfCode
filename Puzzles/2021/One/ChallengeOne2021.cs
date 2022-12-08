using AdventOfCode._2021.One.Objects;
using AdventOfCode.Common;

namespace AdventOfCode._2021.One;

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
        string inputFilePath = "2021\\One\\OneInput.txt";
        return FileService.ReadIntInput(inputFilePath);
    }
}