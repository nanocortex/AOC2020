using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2020.Puzzle14
{
    public class AnswerCalculator
    {
        public ulong Calculate1(IEnumerable<string> lines)
        {
            var mem = new Dictionary<int, ulong>();
            var mask = string.Empty;

            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    mask = line.Split("=")[1].Trim();
                    continue;
                }

                var key = int.Parse(line.Split('[', ']')[1]);
                var value = ulong.Parse(line.Split("=")[1].Trim());

                mem[key] = ApplyMask(value, mask);
            }

            var values = mem.Values.ToList();
            return values.Aggregate<ulong, ulong>(0, (current, v) => current + v);
        }

        public ulong Calculate2(IEnumerable<string> lines)
        {
            var mem = new Dictionary<ulong, ulong>();
            var mask = string.Empty;

            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    mask = line.Split("=")[1].Trim();
                    continue;
                }

                var addrStr = Convert.ToString(long.Parse(line.Split('[', ']')[1]), 2);
                var value = ulong.Parse(line.Split("=")[1].Trim());

                var addr = ApplyAddressMask(addrStr, mask);

                if (!addr.Contains('X'))
                    mem[Convert.ToUInt64(addr, 2)] = value;

                for (var i = 0; i < Math.Pow(2, mask.Count(x => x == 'X')); i++)
                {
                    var istr = Convert.ToString(i, 2).PadLeft(36, '0');

                    var a = new StringBuilder(addr);

                    var j = istr.Length - 1;
                    while (a.ToString().Contains('X'))
                    {
                        var li = a.ToString().LastIndexOf('X');
                        a[li] = istr[j];
                        j--;
                    }

                    mem[Convert.ToUInt64(a.ToString(), 2)] = value;
                }
            }

            var values = mem.Values.ToList();
            return values.Aggregate<ulong, ulong>(0, (current, v) => current + v);
        }

        private ulong ApplyMask(ulong value, string mask)
        {
            var max = 0xffffffffffffffff;
            for (var i = mask.Length - 1; i >= 0; i--)
            {
                if (mask[i] == 'X')
                    continue;

                var b = ulong.Parse(mask[i].ToString());

                if (b == 1)
                    value |= (ulong) 0x1 << (mask.Length - i - 1);
                else
                    value &= ~(ulong) Math.Pow(2, mask.Length - i - 1);
            }

            return value;
        }

        private string ApplyAddressMask(string address, string mask)
        {
            address = address.PadLeft(36, '0');
            mask = mask.PadLeft(36, '0');

            var sb = new StringBuilder(address);

            for (var i = mask.Length - 1; i >= 0; i--)
            {
                switch (mask[i])
                {
                    case '0':
                        continue;
                    case '1':
                        sb[i] = '1';
                        break;
                }

                if (mask[i] == 'X')
                    sb[i] = 'X';
            }

            return sb.ToString();
        }
    }
}