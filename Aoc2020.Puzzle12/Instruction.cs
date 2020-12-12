using System;

namespace Aoc2020.Puzzle12
{
    public record Instruction(InstructionType Type, int Value)
    {
        public static Instruction Parse(string s)
        {
            var type = s[0] switch
            {
                'N' => InstructionType.GoNorth,
                'E' => InstructionType.GoEast,
                'W' => InstructionType.GoWest,
                'S' => InstructionType.GoSouth,
                'L' => InstructionType.TurnLeft,
                'R' => InstructionType.TurnRight,
                'F' => InstructionType.GoForward,
                _ => throw new ArgumentException("")
            };

            var value = int.Parse(s.Substring(1));
            return new Instruction(type, value);
        }
    }
}