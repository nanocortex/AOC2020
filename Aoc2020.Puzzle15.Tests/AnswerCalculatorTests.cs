using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle15.Tests
{
    public class AnswerCalculatorTests
    {
        private readonly AnswerCalculator _answerCalculator = new();

        [Fact]
        public void ShouldCalculate1()
        {
            _answerCalculator.Calculate1("0,3,6").ShouldBe(436);
            _answerCalculator.Calculate1("1,3,2").ShouldBe(1);
            _answerCalculator.Calculate1("2,1,3").ShouldBe(10);
            _answerCalculator.Calculate1("1,2,3").ShouldBe(27);
            _answerCalculator.Calculate1("2,3,1").ShouldBe(78);
            _answerCalculator.Calculate1("3,2,1").ShouldBe(438);
            _answerCalculator.Calculate1("3,1,2").ShouldBe(1836);
        }

        [Fact]
        public void ShouldCalculate2()
        {
            _answerCalculator.Calculate2("0,3,6").ShouldBe(175594);
            _answerCalculator.Calculate2("1,3,2").ShouldBe(2578);
            _answerCalculator.Calculate2("2,1,3").ShouldBe(3544142);
            _answerCalculator.Calculate2("1,2,3").ShouldBe(261214);
            _answerCalculator.Calculate2("2,3,1").ShouldBe(6895259);
            _answerCalculator.Calculate2("3,2,1").ShouldBe(18);
            _answerCalculator.Calculate2("3,1,2").ShouldBe(362);
        }
    }
}