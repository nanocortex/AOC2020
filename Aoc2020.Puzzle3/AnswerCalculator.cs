using System.Linq;

namespace Aoc2020.Puzzle3
{
    public class AnswerCalculator
    {
        private const char Tree = '#';

        public int Calculate1(string[] map)
        {
            return Calculate(0, 0, 3, 1, map);
        }

        public long Calculate2(string[] map)
        {
            long[] results =
            {
                Calculate(0, 0, 1, 1, map),
                Calculate(0, 0, 3, 1, map),
                Calculate(0, 0, 5, 1, map),
                Calculate(0, 0, 7, 1, map),
                Calculate(0, 0, 1, 2, map)
            };

            return results.Aggregate<long, long>(1, (current, result) => current * result);
        }

        private int Calculate(int startX, int startY, int slopeRight, int slopeDown, string[] map, bool calculateOnStart = false)
        {
            int x = startX, y = startY, w = map[0].Length, h = map.Length, trees = 0;

            if (calculateOnStart && map[startY][startX] == Tree)
                trees++;

            while (true)
            {
                x += slopeRight;
                y += slopeDown;

                if (y >= h)
                    return trees;

                if (x >= w)
                    return trees + Calculate(x - w, y, slopeRight, slopeDown, map, true);
                if (map[y][x] == Tree)
                    trees++;
            }
        }
    }
}