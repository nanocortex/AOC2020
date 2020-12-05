using System;

namespace Aoc2020.Puzzle5
{
    public class SeatFinder
    {
        public long FindSeatId(string seat)
        {
            var row = FindRow(seat.Substring(0, 7));
            var col = FindCol(seat.Substring(7, 3));
            return row * 8 + col;
        }

        private int FindRow(string rowSpec) => Bsp(rowSpec, 'F', 'B', 0, 127);

        private int FindCol(string colSpec) => Bsp(colSpec, 'L', 'R', 0, 7);

        private int Bsp(string spec, char lowerChar, char upperChar, int startMin, int startMax)
        {
            int min = startMin, max = startMax;

            foreach (var c in spec)
            {
                var diff = max - min;
                if (c == lowerChar)
                    max -= (int) Math.Round((diff + 1) / 2.0);
                else if (c == upperChar) min += (int) Math.Round((diff + 1) / 2.0);
            }

            return min;
        }
    }
}