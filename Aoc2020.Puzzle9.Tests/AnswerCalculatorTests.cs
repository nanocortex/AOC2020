using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle9.Tests
{
    public class AnswerCalculatorTests
    {
        private const string Example1 = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

        private readonly AnswerCalculator _answerCalculator = new();

        [Fact]
        public void ShouldCalculate1()
        {
            var input = Example1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            _answerCalculator.Calculate1(input, 5).ShouldBe(127);
        }
        
        [Fact]
        public void ShouldCalculate2()
        {
            var input = Example1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            _answerCalculator.Calculate2(input, 5).ShouldBe(62);
        }
    }
}