using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle10
{
    public class AnswerCalculator
    {
        public long Calculate1(List<int> input)
        {
            input = input.OrderBy(x => x).ToList();
            int d1 = 0, d3 = 0, cur = 0;

            foreach (var x in input)
            {
                switch (x - cur)
                {
                    case 1:
                        d1++;
                        cur = x;
                        break;
                    case 2:
                        cur = x;
                        break;
                    case 3:
                        d3++;
                        cur = x;
                        break;
                }
            }

            d3++;
            return d1 * d3;
        }

        public long Calculate2(List<int> input)
        {
            input = input.OrderBy(x => x).ToList();
            input.Insert(0, 0);
            input.Add(input.Max() + 3);
            _cache = new Dictionary<int, long>();
            return CountLeaves(input, 0);
        }


        private static Dictionary<int, long> _cache = new();

        private long CountLeaves(List<int> input, int index)
        {
            var children = new List<int>();

            if (index + 1 < input.Count && input[index + 1] - input[index] <= 3)
                children.Add(index + 1);
            if (index + 2 < input.Count && input[index + 2] - input[index] <= 3)
                children.Add(index + 2);
            if (index + 3 < input.Count && input[index + 3] - input[index] <= 3)
                children.Add(index + 3);

            if (!children.Any())
                return 1;

            long sum = 0;
            foreach (var child in children)
            {
                if (_cache.ContainsKey(child))
                    sum += _cache[child];
                else
                {
                    var s = CountLeaves(input, child);
                    _cache[child] = s;
                    sum += s;
                }
            }

            return sum;
        }
    }
}