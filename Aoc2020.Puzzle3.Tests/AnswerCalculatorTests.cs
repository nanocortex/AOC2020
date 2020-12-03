using System;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle3.Tests
{
    public class AnswerCalculatorTests
    {
        private const string ExampleRaw = @"
..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#
";

        private readonly AnswerCalculator _answerCalculator = new();
        
        [Fact]
        public void ShouldCalculateExample1()
        {
            var result = _answerCalculator.Calculate1(ExampleRaw.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
            result.ShouldBe(7);
        }
        
        [Fact]
        public void ShouldCalculateExample2()
        {
            var result = _answerCalculator.Calculate2(ExampleRaw.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
            result.ShouldBe(336);
        }
        
    }
}