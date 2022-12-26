using System;
using System.Runtime.CompilerServices;

namespace APIAdventOfCode.Puzzles._2022.Three
{
    public class ThreeElves
    {
        private readonly String _elfOne;
        private readonly String _elfTwo;
        private readonly String _elfThree;

        private readonly char _groupBadge;

        private readonly String _characterPriority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        public ThreeElves(String firstContents,
            String secondContents,
            String thirdContents)
        {
            _elfOne = firstContents;
            _elfTwo = secondContents;
            _elfThree = thirdContents;

            _groupBadge = FindBadge();
        }

        private char FindBadge()
        {
            IEnumerable<IEnumerable<char>> elfChars = GetElfContents().Select(x => x.AsEnumerable());
            IEnumerable<char> commonChars = elfChars
              .Aggregate((s, a) => s.Intersect(a));

            if (commonChars.Count() != 1)
            {
                throw new Exception("Found " + commonChars.Count() + " shared characters.");
            }
            return commonChars.First();
        }

        private List<String> GetElfContents()
        {
            return new List<string>() {
                _elfOne, 
                _elfTwo, 
                _elfThree
            };
        }

        public int GetBadgePriority()
        {
            return _characterPriority.IndexOf(_groupBadge) + 1;
        }

    }
}
