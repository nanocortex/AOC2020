using System;
using Aoc2020.Puzzle16;
using Aoc2020.Shared;

var lines = Utils.GetInputString();
var answerCalculator = new AnswerCalculator();
Console.WriteLine($"Solution 1: {answerCalculator.Calculate1(lines)}");
Console.WriteLine($"Solution 2: {answerCalculator.Calculate2(lines)}");

