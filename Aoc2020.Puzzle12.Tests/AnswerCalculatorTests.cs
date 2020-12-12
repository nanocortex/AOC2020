using System;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle12.Tests
{
    public class AnswerCalculatorTests
    {
        private const string ExampleInput = @"F10
N3
F7
R90
F11
";

        private readonly AnswerCalculator _answerCalculator = new();

        [Fact]
        public void ShouldCalculate1()
        {
            _answerCalculator.Calculate1(ExampleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe(25);
        }
        
        [Fact]
        public void ShouldCalculate2()
        {
            _answerCalculator.Calculate2(ExampleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe(286);
        }
    }
}