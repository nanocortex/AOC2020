using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle6
{
    public class AnswerCalculator
    {
        public long Calculate1(string input)
        {
            var groups = input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
            return groups.Select(@group => @group.Replace(" ", string.Empty).Replace(Environment.NewLine, string.Empty).Trim()).Select(raw => raw.Distinct().Count()).Sum();
        }

        public long Calculate2(string input)
        {
            var groups = input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
            long sum = 0;
            foreach (var @group in groups)
            {
                var counts = new Dictionary<char, int>();
                var people = @group.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                foreach (var p in people)
                {
                    var str = p.Replace(" ", string.Empty).Replace(Environment.NewLine, string.Empty).Trim();

                    foreach (var c in str)
                    {
                        if (counts.ContainsKey(c))
                            counts[c]++;
                        else
                            counts.Add(c, 1);
                    }
                }

                sum += counts.Values.Count(x => x == people.Length);
            }

            return sum;
        }
    }
}