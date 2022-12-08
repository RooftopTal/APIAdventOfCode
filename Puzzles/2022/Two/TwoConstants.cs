using AdventOfCode._2022.Two.Objects;

namespace AdventOfCode._2022.Two;

public class TwoConstants
{
    public static readonly IDictionary<RPSEnum, int> ChoiceMap = new Dictionary<RPSEnum, int>() {
        { RPSEnum.Rock , 1 },
        { RPSEnum.Paper , 2 },
        { RPSEnum.Scissors , 3 }
    };

    public static IDictionary<ScoreEnum, int> ScoreMap = new Dictionary<ScoreEnum, int>()
    {
        { ScoreEnum.Win, 6 },
        { ScoreEnum.Draw, 3 },
        { ScoreEnum.Loss, 0 }
    };
}