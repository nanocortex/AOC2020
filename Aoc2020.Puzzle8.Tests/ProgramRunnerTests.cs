using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle8.Tests
{
    public class ProgramRunnerTests
    {
        private const string ExampleInput = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

        private readonly ProgramRunner _programRunner = new();

        [Fact]
        public void ShouldFindInfiniteLoop()
        {
            var lines = ExampleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            _programRunner.FindInfiniteLoop(lines.Select(Instruction.Parse).ToList()).ShouldBe(5);
        }

        [Fact]
        public void ShouldFixInfiniteLoop()
        {
            var lines = ExampleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            _programRunner.FixInfiniteLoop(lines.Select(Instruction.Parse).ToList()).ShouldBe(8);
        }
    }
}