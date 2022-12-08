namespace AdventOfCode._2022.Two.Objects;

public class CheatEntry
{
    private readonly RPSEnum _opponentMove;
    private readonly RPSEnum _requiredPlayerMove;
    private readonly ScoreEnum _requiredResult;

    public CheatEntry(string opponentMove, string requiredResult)
    {
        _opponentMove = ToRPSMove(opponentMove);
        _requiredPlayerMove = ToRPSMove(opponentMove);
        _requiredResult = ToRequiredResult(requiredResult);
        _requiredPlayerMove = GetRequiredPlayerMove();
        MatchPoints = GetMatchPoints();
    }

    public int MatchPoints { get; }

    private int GetMatchPoints()
    {
        TwoConstants.ChoiceMap.TryGetValue(_requiredPlayerMove, out var choicePoints);
        TwoConstants.ScoreMap.TryGetValue(_requiredResult, out var scorePoints);

        return choicePoints + scorePoints;
    }

    private RPSEnum GetRequiredPlayerMove()
    {
        switch (_requiredResult)
        {
            case ScoreEnum.Win:
                switch (_opponentMove)
                {
                    case RPSEnum.Rock:
                        return RPSEnum.Paper;
                    case RPSEnum.Paper:
                        return RPSEnum.Scissors;
                    case RPSEnum.Scissors:
                        return RPSEnum.Rock;
                    default:
                        throw new Exception("Unknown opponent move: " + _opponentMove);
                }
            case ScoreEnum.Draw:
                return _opponentMove;
            case ScoreEnum.Loss:
                switch (_opponentMove)
                {
                    case RPSEnum.Rock:
                        return RPSEnum.Scissors;
                    case RPSEnum.Paper:
                        return RPSEnum.Rock;
                    case RPSEnum.Scissors:
                        return RPSEnum.Paper;
                    default:
                        throw new Exception("Unknown opponent move: " + _opponentMove);
                }
            default:
                throw new Exception("Unknown result: " + _requiredResult);
        }
    }

    private RPSEnum ToRPSMove(string input)
    {
        switch (input)
        {
            case "A":
                return RPSEnum.Rock;
            case "B":
                return RPSEnum.Paper;
            case "C":
                return RPSEnum.Scissors;
            default:
                throw new Exception("Unknown RPS mapping: " + input);
        }
    }
    
    private ScoreEnum ToRequiredResult(string input)
    {
        switch (input)
        {
            case "X":
                return ScoreEnum.Loss;
            case "Y":
                return ScoreEnum.Draw;
            case "Z":
                return ScoreEnum.Win;
            default:
                throw new Exception("Unknown RPS mapping: " + input);
        }
    }
}