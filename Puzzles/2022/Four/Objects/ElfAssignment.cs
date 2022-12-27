﻿using System.Text.RegularExpressions;

namespace APIAdventOfCode.Puzzles._2022.Four.Objects
{
    public class ElfAssignment
    {
        String _assignmentPattern = @"(\d)+";

        List<int> _elfOneAssignments;
        List<int> _elfTwoAssignments;

        public ElfAssignment(String assignmentInput)
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
            } else
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
            return Tuple.Create(
                Enumerable.Range(ParseInt(assignments[0]), ParseInt(assignments[1])-ParseInt(assignments[0])+1),
                Enumerable.Range(ParseInt(assignments[2]), ParseInt(assignments[3])-ParseInt(assignments[2])+1)
            );
        }

        private int ParseInt(Match match)
        {
            int parsed;
            Int32.TryParse(match.ToString(), out parsed);
            return parsed;
        }
    }
}
