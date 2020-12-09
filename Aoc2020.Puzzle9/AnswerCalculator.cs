using System.Linq;

namespace Aoc2020.Puzzle9
{
    public class AnswerCalculator
    {
        public long Calculate1(long[] input, int preamble)
        {
            return FindWrongNumber(input, preamble);
        }

        public long Calculate2(long[] input, int preamble)
        {
            var wrongNumber = FindWrongNumber(input, preamble);
            var set = FindContiguousSet(input, wrongNumber);
            return set.Min() + set.Max();
        }

        private long FindWrongNumber(long[] input, int preamble)
        {
            for (var i = preamble; i < input.Length; i++)
            {
                if (!IsSumOfPreviousNumbers(input.Skip(i - preamble).Take(preamble).ToArray(), input[i]))
                    return input[i];
            }

            return -1;
        }

        private bool IsSumOfPreviousNumbers(long[] previous, long n)
        {
            return previous.Where((t1, i) => previous.Where((t, j) => i != j && t1 + t == n).Any()).Any();
        }

        private long[] FindContiguousSet(long[] input, long n)
        {
            for (var i = 0; i < input.Length; i++)
            {
                long sum = 0;
                for (var j = i; j < input.Length; j++)
                {
                    sum += input[j];

                    if (sum == n)
                        return input.Skip(i).Take(j - i + 1).ToArray();
                    if (sum > n)
                        break;
                }
            }

            return System.Array.Empty<long>();
        }
    }
}