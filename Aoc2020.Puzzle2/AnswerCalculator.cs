using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle2
{
    public class AnswerCalculator
    {
        private readonly PasswordValidator _passwordValidator = new();

        public int Calculate1(IEnumerable<string> lines)
        {
            return lines.Count(line => _passwordValidator.Validate1(line));
        }
        
        public int Calculate2(IEnumerable<string> lines)
        {
            return lines.Count(line => _passwordValidator.Validate2(line));
        }
    }
}