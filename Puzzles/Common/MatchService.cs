using System.Text.RegularExpressions;

namespace APIAdventOfCode.Puzzles.Common
{
    public class MatchService
    {
        public static int ParseInt(Match match)
        {
            int parsed;
            int.TryParse(match.ToString(), out parsed);
            return parsed;
        }
    }
}
