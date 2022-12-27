using APIAdventOfCode.Puzzles._2022.Objects;
using APIAdventOfCode.Puzzles.Common;
using System.Text.RegularExpressions;

namespace APIAdventOfCode.Puzzles._2022.Objects
{
    public class CraneMove
    {
        private readonly string _assignmentPattern = @"(\d)+";

        public CraneMove(String individualMove)
        {
            Regex assignmentRegex = new Regex(_assignmentPattern);
            MatchCollection moveKeys = assignmentRegex.Matches(individualMove);

            ValidateMoves(moveKeys);

            NumberToMove = MatchService.ParseInt(moveKeys[0]);
            From = MatchService.ParseInt(moveKeys[1]);
            To = MatchService.ParseInt(moveKeys[2]);
        }

        public int NumberToMove { get; }
        public int From { get; }
        public int To { get; }

        private void ValidateMoves(MatchCollection moveKeys)
        {
            if (moveKeys.Count() != 3)
            {
                throw new Exception("Expected 3 move numbers; found " + moveKeys.Count());
            }
        }
    }
}