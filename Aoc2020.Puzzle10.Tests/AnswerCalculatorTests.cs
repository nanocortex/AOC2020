using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle10.Tests
{
    public class AnswerCalculatorTests
    {
        private const string Example1 = @"16
10
15
5
1
11
7
19
6
12
4";

        private const string Example2 = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

        private readonly AnswerCalculator _answerCalculator = new();

        [Fact]
        public void ShouldCalculate1()
        {
            _answerCalculator.Calculate1(Example1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()).ShouldBe(35);
            _answerCalculator.Calculate1(Example2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()).ShouldBe(220);
        }
        
        [Fact]
        public void ShouldCalculate2()
        {
            _answerCalculator.Calculate2(Example1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()).ShouldBe(8);
            _answerCalculator.Calculate2(Example2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()).ShouldBe(19208);
        }
    }
}