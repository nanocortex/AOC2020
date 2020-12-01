using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle1.Tests
{
    public class Tests
    {
        private static readonly int[] ExampleData = {1721, 979, 366, 299, 675, 1456};

        [Fact]
        public void ShouldFindCorrectAnswerForExample1()
        {
            var result = new AnswerCalculator().Calculate1(ExampleData);
            result.ShouldBe(514579);
        }
        
        [Fact]
        public void ShouldFindCorrectAnswerForExample2()
        {
            var result = new AnswerCalculator().Calculate2(ExampleData);
            result.ShouldBe(241861950);
        }
    }
}