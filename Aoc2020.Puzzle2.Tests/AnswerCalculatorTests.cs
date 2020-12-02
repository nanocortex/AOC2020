using System.Linq;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle2.Tests
{
    public class AnswerCalculatorTests
    {
        private const string ExampleInput = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

        private readonly AnswerCalculator _answerCalculator = new();

        [Fact]
        public void ShouldCalculateCorrectAnswer1()
        {
            var result = _answerCalculator.Calculate1(ExampleInput.Split("\n").ToList());

            result.ShouldBe(2);
        }

        [Fact]
        public void ShouldCalculateCorrectAnswer2()
        {
            var result = _answerCalculator.Calculate2(ExampleInput.Split("\n").ToList());

            result.ShouldBe(1);
        }
    }
}