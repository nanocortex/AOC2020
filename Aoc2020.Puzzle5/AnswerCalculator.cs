using System;
using System.Linq;

namespace Aoc2020.Puzzle5
{
    public class AnswerCalculator
    {
        private readonly SeatFinder _seatFinder = new();

        public long Calculate1(string input)
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            return lines.Select(x => _seatFinder.FindSeatId(x)).Max();
        }

        public long Calculate2(string input)
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var ids = lines.Select(x => _seatFinder.FindSeatId(x)).OrderBy(x => x).ToList();
            return (from id in ids where !ids.Contains(id + 1) && id > 10 && id < 800 select id + 1).FirstOrDefault();
        }
    }
}