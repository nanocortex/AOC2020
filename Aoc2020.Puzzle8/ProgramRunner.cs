using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle8
{
    public class ProgramRunner
    {
        private int _acc;
        private int _ip;

        private Dictionary<int, int> _instructionUsages = new();

        public int FindInfiniteLoop(List<Instruction> instructions)
        {
            _acc = 0;
            _ip = 0;
            _instructionUsages = new Dictionary<int, int>();
            while (true)
            {
                var ins = instructions[_ip];
                if (_instructionUsages.ContainsKey(_ip))
                    _instructionUsages[_ip]++;
                else
                    _instructionUsages[_ip] = 1;
                if (_instructionUsages.ContainsKey(_ip) && _instructionUsages[_ip] > 1)
                    break;
                ExecuteInstruction(ins);
            }

            return _acc;
        }

        public int FixInfiniteLoop(List<Instruction> instructions)
        {
            foreach (var instruction in instructions.TakeWhile(_ => IsInfiniteLoop(instructions)))
            {
                if (instruction.Type == InstructionType.Jmp)
                    instruction.Type = InstructionType.Nop;
                else if (instruction.Type == InstructionType.Nop)
                    instruction.Type = InstructionType.Jmp;
                else
                    continue;

                if (!IsInfiniteLoop(instructions))
                    break;

                instruction.Type = instruction.Type switch
                {
                    InstructionType.Jmp => InstructionType.Nop,
                    InstructionType.Nop => InstructionType.Jmp,
                    _ => instruction.Type
                };
            }

            return _acc;
        }

        private void ExecuteInstruction(Instruction instruction)
        {
            switch (instruction.Type)
            {
                case InstructionType.Nop:
                    _ip++;
                    break;
                case InstructionType.Acc:
                    _acc += instruction.Arg;
                    _ip++;
                    break;
                case InstructionType.Jmp:
                    _ip += instruction.Arg;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(instruction), "");
            }
        }

        private bool IsInfiniteLoop(List<Instruction> instructions)
        {
            _acc = 0;
            _ip = 0;
            _instructionUsages = new Dictionary<int, int>();
            while (_ip < instructions.Count)
            {
                var ins = instructions[_ip];
                if (_instructionUsages.ContainsKey(_ip))
                    _instructionUsages[_ip]++;
                else
                    _instructionUsages[_ip] = 1;
                if (_instructionUsages.ContainsKey(_ip) && _instructionUsages[_ip] > 1)
                    return true;
                ExecuteInstruction(ins);
            }

            return false;
        }
    }
}