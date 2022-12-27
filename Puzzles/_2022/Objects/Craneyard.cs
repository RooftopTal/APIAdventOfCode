using AdventOfCode.Common;
using System.Collections.Generic;

namespace APIAdventOfCode.Puzzles._2022.Objects
{
    public class Craneyard
    {
        private readonly int _crateSpaces = 9;
        private Dictionary<int, List<char>> _crateyardContents;

        public Craneyard(IEnumerable<String> startingSetup)
        {
            _crateyardContents = GetStartingCraneyard(ParseStartingSetup(startingSetup));
            Console.WriteLine("Done");
        }

        public void ApplyMove9000(CraneMove move)
        {
            for (int i = 0; i < move.NumberToMove; i++) {
                List<char> fromPile = _crateyardContents[move.From];
                List<char> toPile = _crateyardContents[move.To];
                char movedCrate = fromPile.Last();

                _crateyardContents[move.To].Add(movedCrate);

                int lastIndex = fromPile.Count() - 1;
                _crateyardContents[move.From].RemoveAt(lastIndex);
            }
        }

        public void ApplyMove9001(CraneMove move)
        {
            List<char> fromPile = _crateyardContents[move.From];
            List<char> toPile = _crateyardContents[move.To];
            IEnumerable<char> movedCrates = fromPile.TakeLast(move.NumberToMove);

            _crateyardContents[move.To].AddRange(movedCrates);

            int removeFrom = fromPile.Count() - move.NumberToMove;
            _crateyardContents[move.From].RemoveRange(removeFrom, move.NumberToMove);
        }

        public IEnumerable<char> GetTopCrates()
        {
            foreach (var cratePillar in _crateyardContents)
            {
                yield return cratePillar.Value.Last();
            }
        }

        private Dictionary<int, List<char>> GetStartingCraneyard(IEnumerable<IEnumerable<char>> crateManifest)
        {
            Dictionary<int, List<char>> craneyardContents = new Dictionary<int, List<char>>();
            for (int i = 1; i <= _crateSpaces; i++)
            {
                craneyardContents.Add(i, new List<char>());
            }


            foreach (IEnumerable<char> levelOfCrates in crateManifest.Reverse())
            {
                int pileIndex = 1;

                foreach (char crate in levelOfCrates)
                {
                    if (crate != ' ')
                    {
                        craneyardContents[pileIndex].Add(crate);
                    }

                    pileIndex++;
                }
            }

            return craneyardContents;
        }

        private IEnumerable<IEnumerable<char>> ParseStartingSetup(IEnumerable<String> startingSetup)
        {
            return startingSetup
                //need to add padding so formatted list works
                .Select(x => x + ' ')
                .Select(x => x.ToCharArray())
                .Select(x => x.ToFormattedList(4, args => args[1]));
        }
    }
}