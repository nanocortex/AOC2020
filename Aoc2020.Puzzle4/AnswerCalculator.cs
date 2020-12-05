using System;
using System.Linq;

namespace Aoc2020.Puzzle4
{
    public class AnswerCalculator
    {
        private readonly SimplePassportValidator _simplePassportValidator = new();
        private readonly PassportValidator _passportValidator = new();
        public int Calculate1(string input)
        {
            var passports = input.Split($"{Environment.NewLine}{Environment.NewLine}");
            return passports.Sum(passport => _simplePassportValidator.Validate(passport) ? 1 : 0);
        }

        public int Calculate2(string input)
        {
            var passports = input.Split($"{Environment.NewLine}{Environment.NewLine}");
            return passports.Sum(passport => _passportValidator.Validate(passport) ? 1 : 0);
        }
    }
}