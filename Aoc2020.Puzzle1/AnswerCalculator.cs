using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle1
{
    public class AnswerCalculator
    {
        public long Calculate1(IEnumerable<int> values)
        {
            var (item1, item2) = FindPair(values.ToList());
            return item1 * item2;
        }


        public long Calculate2(IEnumerable<int> values)
        {
            var (item1, item2, item3) = FindTriplet(values.ToList());
            return item1 * item2 * item3;
        }

        private (int, int) FindPair(List<int> list)
        {
            // TODO: optimize
            while (true)
            {
                foreach (var value in list)
                {
                    foreach (var value2 in list)
                    {
                        if (value + value2 == 2020)
                            return (value, value2);
                    }

                    list.Remove(value);
                    break;
                }
            }
        }

        private (int, int, int) FindTriplet(List<int> list)
        {
            // TODO: optimize
            foreach (var value in list)
            {
                foreach (var value2 in list)
                {
                    foreach (var value3 in list)
                    {
                        if (value + value2 + value3 == 2020)
                            return (value, value2, value3);
                    }
                }
            }

            return (0, 0, 0);
        }
    }
}