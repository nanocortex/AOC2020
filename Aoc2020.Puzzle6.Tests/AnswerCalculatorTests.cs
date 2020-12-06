using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle6.Tests
{
    public class AnswerCalculatorTests
    {
        private const string ExampleInput = @"abc

a
b
c

ab
ac

a
a
a
a

b";

        private readonly AnswerCalculator _answerCalculator = new();

        [Fact]
        public void ShouldCalculateCorrectAnswer()
        {
            _answerCalculator.Calculate1(ExampleInput).ShouldBe(11);
        }
        
        [Fact]
        public void ShouldCalculateCorrectAnswer2()
        {
            _answerCalculator.Calculate2(ExampleInput).ShouldBe(6);
        }
    }
}