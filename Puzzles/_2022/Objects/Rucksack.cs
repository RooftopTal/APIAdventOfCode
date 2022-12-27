using System;

namespace APIAdventOfCode.Puzzles._2022.Objects
{
    public class Rucksack
    {
        private readonly String _compartmentLeft;
        private readonly String _compartmentRight;
        private readonly char _sharedCharacter;

        private readonly String _characterPriority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        public Rucksack(String contents)
        {
            int halfLength = (int)(contents.Length / 2);
            _compartmentLeft = contents.Substring(0, halfLength);
            _compartmentRight = contents.Substring(halfLength, halfLength);

            _sharedCharacter = FindSharedCharacter();
        }

        private char FindSharedCharacter()
        {
            IEnumerable<char> commonChars = _compartmentLeft.Intersect(_compartmentRight);
            if (commonChars.Count() != 1)
            {
                throw new Exception("Found " + commonChars.Count() + " shared characters.");
            }
            return commonChars.First();
        }

        public int GetRucksackPriority()
        {
            return _characterPriority.IndexOf(_sharedCharacter) + 1;
        }

    }
}
