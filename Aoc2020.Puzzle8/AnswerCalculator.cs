using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle8
{
    public class AnswerCalculator
    {
        private readonly ProgramRunner _programRunner = new();

        public int Calculate1(IEnumerable<string> input)
        {
            var instructions = input.Select(Instruction.Parse).ToList();
            return _programRunner.FindInfiniteLoop(instructions);
        }

        public int Calculate2(IEnumerable<string> input)
        {
            var instructions = input.Select(Instruction.Parse).ToList();
            return _programRunner.FixInfiniteLoop(instructions);
        }
    }
}