using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle11
{
    public class AnswerCalculator
    {
        public long Calculate1(IEnumerable<string> input)
        {
            var inputList = input.Select(x => x.Select(y => y.ToString()).ToArray()).ToArray();
            var map = new Map(inputList);
            while (true)
            {
                var baseMap = new Map(map.Data);
                var resolved = map.Resolve();
                if (Equals(resolved, baseMap))
                    break;
                map = resolved;
            }
            return map.CountOccupiedSeats();
        }

        public long Calculate2(IEnumerable<string> input)
        {
            var inputList = input.Select(x => x.Select(y => y.ToString()).ToArray()).ToArray();
            var map = new Map(inputList);
            while (true)
            {
                var baseMap = new Map(map.Data);
                var resolved = map.Resolve2();
                if (Equals(resolved, baseMap))
                    break;
                map = resolved;
            }
            return map.CountOccupiedSeats();
        }
    }
}