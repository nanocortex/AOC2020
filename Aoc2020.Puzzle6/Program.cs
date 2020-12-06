using System;
using Aoc2020.Puzzle6;
using Aoc2020.Shared;

var input = Utils.GetInputString();
var answerCalculator = new AnswerCalculator();
Console.WriteLine($"Solution 1: {answerCalculator.Calculate1(input)}");
Console.WriteLine($"Solution 2: {answerCalculator.Calculate2(input)}");
