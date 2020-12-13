using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle13
{
    public class AnswerCalculator
    {
        public int Calculate1(string[] lines)
        {
            var earliestTimestamp = int.Parse(lines[0]);
            var buses = lines[1].Split(",", StringSplitOptions.RemoveEmptyEntries).Where(x => x != "x").Select(int.Parse).ToArray();
            int minDiff = buses.Max(), minBus = 0;

            foreach (var bus in buses)
            {
                var diff = (int) Math.Floor((double) earliestTimestamp / (double) bus) * bus + bus - earliestTimestamp;
                if (diff >= minDiff) continue;
                minDiff = diff;
                minBus = bus;
            }

            return minBus * minDiff;
        }


        private IEnumerable<long> Generate(long start, long step)
        {
            var n = start;
            while (true)
            {
                yield return n;
                n += step;
            }
            // ReSharper disable once IteratorNeverReturns
        }
        public long Calculate2(string busesStr)
        {
            var buses = busesStr.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var dict = new Dictionary<int, int>();

            for (var i = 0; i < buses.Length; i++)
            {
                if (buses[i] == "x")
                    continue;
            
                dict.Add(int.Parse(buses[i]), i);
            }

            long start = 0, steps = 1;
            long ts = 0;

            foreach (var (bus, offset) in dict.OrderByDescending(x => x.Value))
            {
                foreach (var timestamp in Generate(start, steps))
                {
                    ts = timestamp;
                    if ((timestamp + offset) % bus != 0) continue;
                    
                    start = timestamp;
                    steps *= bus;
                    break;
                }
            }

            return ts;
            
            // TODO: someday find solution via CRT (Chinese Reminders Theorem)
            // var sum = 0L;
            // foreach (var (offset, value) in dict)
            // {
            //     long r = value - offset;
            //     if (r == value)
            //         r = 0;
            //     long n = value;
            //     long N = dict.Where(x => x.Value != n).Select(x => x.Value).Aggregate(1, (x, y) => x * y);
            //     var m = Gcd(N, n).Item1;
            //
            //     Console.WriteLine($"r: {r}, n: {n}, N: {N}, m: {m}");
            //
            //     sum += r * N * m;
            // }
            //
            // Console.WriteLine($"Sum: {sum}");
            //
            // return sum % dict.Select(x => x.Value).Aggregate(1, (x, y) => x * y);
        }

        // private (long, long) Gcd(long a, long b)
        // {
        //     long x = 0, y = 1, u = 1, v = 0;
        //     while (a != 0)
        //     {
        //         var q = b / a;
        //         var r = b % a;
        //         var m = x - u * q;
        //         var n = y - v * q;
        //         b = a;
        //         a = r;
        //         x = u;
        //         y = v;
        //         u = m;
        //         v = n;
        //     }
        //
        //     return (x, y);
        // }
    }
}