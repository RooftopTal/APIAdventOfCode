using AdventOfCode._2021.One;
using AdventOfCode._2021.Two;
using AdventOfCode._2022.One;
using AdventOfCode._2022.Two;
using APIAdventOfCode.Models;

namespace APIAdventOfCode.Puzzles
{
    public interface IAdventofCodeService
    {
        AOCResponse GetAOCAnswer(int year, int day);
    }

    public class AdventOfCodeService : IAdventofCodeService
    {
        public AOCResponse GetAOCAnswer(int year, int day)
        {
            return new AOCResponse(FindAnswer(year, day));
        }

        private string FindAnswer(int year, int day)
        {
            switch (year)
            {
                case 2021:
                    switch (day)
                    {
                        case 1:
                            return ChallengeOne2021.GetIncreases();
                        case 2:
                            return ChallengeTwo2021.GetDepthXHorizontal();
                        default:
                            throw new Exception("Invalid day");

                    }
                case 2022:
                    switch (day)
                    {
                        case 1:
                            return ChallengeOne2022.GetCalories();
                        case 2:
                            return ChallengeTwo2022.GetScore();
                        default:
                            throw new Exception("Invalid day");
                    }
                default:
                    throw new Exception("Invalid year");
            }

        }
    }
}
