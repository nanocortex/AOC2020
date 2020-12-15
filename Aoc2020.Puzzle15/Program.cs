using System;
using Aoc2020.Puzzle15;
using Aoc2020.Shared;

var lines = Utils.GetInputStrings();
var answerCalculator = new AnswerCalculator();

Console.WriteLine($"Solution 1: {answerCalculator.Calculate1(lines[0])}");
Console.WriteLine($"Solution 2: {answerCalculator.Calculate2(lines[0])}");

