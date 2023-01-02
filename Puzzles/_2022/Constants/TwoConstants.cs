using APIAdventOfCode.Puzzles._2022.Objects.Enums;

namespace APIAdventOfCode.Puzzles._2022.Constants;

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