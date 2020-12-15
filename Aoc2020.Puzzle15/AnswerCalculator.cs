using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle15
{
    public class AnswerCalculator
    {
        public int Calculate1(string line, int nth = 2020)
        {
            var numbers = line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var mem = new Dictionary<int, List<int>>();

            var round = 1;
            var last = -1;
            foreach (var number in numbers)
            {
                MemSet(mem, number, round);
                last = number;
                round++;
            }

            while (true)
            {
                if (!mem.ContainsKey(last) || mem[last].Count <= 1)
                    last = 0;
                else
                    last = mem[last].Last() - mem[last][mem[last].Count - 2];

                MemSet(mem, last, round);

                if (round == nth)
                    return last;
                round++;
            }
        }

        public int Calculate2(string line)
        {
            return Calculate1(line, 30000000);
        }

        private void MemSet(Dictionary<int, List<int>> mem, int number, int round)
        {
            if (mem.ContainsKey(number))
                mem[number].Add(round);
            else
                mem.Add(number, new List<int>(new[] {round}));
        }
    }
}