using APIAdventOfCode.Puzzles.Common;
using System.Text.RegularExpressions;

namespace APIAdventOfCode.Puzzles._2022.Objects
{
    public class ElfAssignment
    {
        string _assignmentPattern = @"(\d)+";

        List<int> _elfOneAssignments;
        List<int> _elfTwoAssignments;

        public ElfAssignment(string assignmentInput)
        {
            Regex assignmentRegex = new Regex(_assignmentPattern);
            MatchCollection assignments = assignmentRegex.Matches(assignmentInput);
            ValidateAssignments(assignments);

            Tuple<IEnumerable<int>, IEnumerable<int>> elfAssignments = GetElfAssignments(assignments);
            _elfOneAssignments = elfAssignments.Item1.ToList();
            _elfTwoAssignments = elfAssignments.Item2.ToList();
        }

        public bool ElvesEclipse()
        {
            if (_elfOneAssignments.Count() >= _elfTwoAssignments.Count())
            {
                return _elfOneAssignments.Intersect(_elfTwoAssignments).Count() == _elfTwoAssignments.Count();
            }
            else
            {
                return _elfTwoAssignments.Intersect(_elfOneAssignments).Count() == _elfOneAssignments.Count();
            }
        }

        public bool ElvesOverlap()
        {
            return _elfOneAssignments.Intersect(_elfTwoAssignments).Count() > 0;
        }

        private void ValidateAssignments(MatchCollection assignments)
        {
            if (assignments.Count() != 4)
            {
                throw new Exception("Expected 4 assignment numbers; found " + assignments.Count());
            }
        }

        private Tuple<IEnumerable<int>, IEnumerable<int>> GetElfAssignments(MatchCollection assignments)
        {
            int oneStart = MatchService.ParseInt(assignments[0]);
            int oneEnd = MatchService.ParseInt(assignments[1]);
            int twoStart = MatchService.ParseInt(assignments[2]);
            int twoEnd = MatchService.ParseInt(assignments[3]);

            return Tuple.Create(
                Enumerable.Range(oneStart, oneEnd - oneStart + 1),
                Enumerable.Range(twoStart, twoEnd - twoStart + 1)
            );
        }
    }
}
