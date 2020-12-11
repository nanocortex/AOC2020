using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle11.Tests
{
    public class AnswerCalculatorTests
    {
        private const string ExampleInput = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

        private readonly AnswerCalculator _answerCalculator = new();
        
        [Fact]
        public void ShouldCalculate1()
        {
            _answerCalculator.Calculate1(ExampleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList()).ShouldBe(37);
        }
        
        [Fact]
        public void ShouldCalculate2()
        {
            _answerCalculator.Calculate2(ExampleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList()).ShouldBe(26);
        }
    }
}