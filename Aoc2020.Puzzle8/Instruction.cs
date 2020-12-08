using System;

namespace Aoc2020.Puzzle8
{
    public class Instruction
    {
        private Instruction(InstructionType type, int arg)
        {
            Type = type;
            Arg = arg;
        }

        public InstructionType Type { get; set; }

        public int Arg { get; set; }

        public static Instruction Parse(string line)
        {
            var typeStr = line.Split(" ")[0];
            var arg = int.Parse(line.Split(" ")[1]);
            var type = typeStr switch
            {
                "nop" => InstructionType.Nop,
                "acc" => InstructionType.Acc,
                "jmp" => InstructionType.Jmp,
                _ => throw new ArgumentException("")
            };
            return new Instruction(type, arg);
        }
    }
}