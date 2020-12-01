﻿using System;
using System.IO;
using System.Text;

namespace Aoc2020.Shared
{
    public static class Utils
    {
        public const string DefaultInputPath = "input.txt";
        
        public static string[] GetInputStrings(string input = DefaultInputPath)
        {
            return File.ReadAllLines(input, Encoding.UTF8);
        }
        
        public static int[] GetInputIntegers(string input = DefaultInputPath)
        {
            var strings = GetInputStrings(input);
            return Array.ConvertAll(strings, int.Parse);
        }
        
        public static double[] GetInputDoubles(string input = DefaultInputPath)
        {
            var strings = GetInputStrings(input);
            return Array.ConvertAll(strings, double.Parse);
        }
    }
}