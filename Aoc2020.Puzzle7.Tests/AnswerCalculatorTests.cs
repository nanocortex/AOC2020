using System;
using Shouldly;
using Xunit;

namespace Aoc2020.Puzzle7.Tests
{
    public class AnswerCalculatorTests
    {
        private const string Example1 = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

        private const string Example2 = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";
            
        private readonly AnswerCalculator _answerCalculator = new();
        
        [Fact]
        public void ShouldCalculateExample1()
        {
            _answerCalculator.Calculate1(Example1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe(4);
        }
        
        [Fact]
        public void ShouldCalculateExample2()
        {
            _answerCalculator.Calculate2(Example1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe(32);
            _answerCalculator.Calculate2(Example2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)).ShouldBe(126);
        }
    }
}