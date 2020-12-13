using System;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle13.Tests
{
    public class AnswerCalculatorTests
    {
        private const string ExampleInput = @"939
7,13,x,x,59,x,31,19";

        private readonly AnswerCalculator _answerCalculator = new();
        
        [Fact]
        public void ShouldCalculate1()
        {
            _answerCalculator.Calculate1(ExampleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe(295);
        }

        [Fact]
        public void ShouldCalculate2()
        {
            _answerCalculator.Calculate2("7,13,x,x,59,x,31,19").ShouldBe(1068781);
            _answerCalculator.Calculate2("17,x,13,19").ShouldBe(3417);
            _answerCalculator.Calculate2("67,7,59,61").ShouldBe(754018);
            _answerCalculator.Calculate2("67,x,7,59,61").ShouldBe(779210);
            _answerCalculator.Calculate2("67,7,x,59,61").ShouldBe(1261476);
            _answerCalculator.Calculate2("1789,37,47,1889").ShouldBe(1202161486);
        }
    }
}