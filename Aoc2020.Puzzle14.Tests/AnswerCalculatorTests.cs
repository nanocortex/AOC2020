using System;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle14.Tests
{
    public class AnswerCalculatorTests
    {
        private readonly AnswerCalculator _answerCalculator = new();

        [Fact]
        public void ShouldCalculate1()
        {
            const string example = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";
            _answerCalculator.Calculate1(example.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe((ulong) 165);
        }

        [Fact]
        public void ShouldCalculate2()
        {
            const string example = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";
            _answerCalculator.Calculate2(example.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe((ulong) 208);
        }
    }
}