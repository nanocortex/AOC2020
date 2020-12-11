using System;
using System.Linq;
using Aoc2020.Puzzle11;
using Aoc2020.Shared;

var input = Utils.GetInputStrings();
var answerCalculator = new AnswerCalculator();
Console.WriteLine($"Solution 1: {answerCalculator.Calculate1(input.ToList())}");
Console.WriteLine($"Solution 2: {answerCalculator.Calculate2(input.ToList())}");
