using System;
using Aoc2020.Puzzle9;
using Aoc2020.Shared;

var input = Utils.GetInputLongs();
var answerCalculator = new AnswerCalculator();
Console.WriteLine($"Solution 1: {answerCalculator.Calculate1(input, 25)}");
Console.WriteLine($"Solution 2: {answerCalculator.Calculate2(input, 25)}");
