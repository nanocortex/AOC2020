using System;
using System.Linq;

namespace Aoc2020.Puzzle2
{
    public class PasswordValidator
    {
        public bool Validate1(string line)
        {
            return Validate1(Parse(line));
        }

        public bool Validate2(string line)
        {
            return Validate2(Parse(line));
        }

        private bool Validate1(PasswordData data)
        {
            var (minLength, maxLength, character, password) = data;
            var characterCountInPassword = password.Count(x => x == character);
            return characterCountInPassword >= minLength && characterCountInPassword <= maxLength;
        }

        private bool Validate2(PasswordData data)
        {
            var (pos1, pos2, character, password) = data;
            pos1--;
            pos2--;
            return password[pos1] == character ^ password[pos2] == character;
        }


        private PasswordData Parse(string rawData)
        {
            var tokens = rawData.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var minMax = tokens[0];

            var min = int.Parse(minMax.Split("-")[0]);
            var max = int.Parse(minMax.Split("-")[1]);

            var character = tokens[1][0];

            var password = tokens[2];
            return new PasswordData(min, max, character, password);
        }
    }
}