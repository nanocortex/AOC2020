using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Puzzle12
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public class AnswerCalculator
    {
        private readonly Dictionary<Direction, (int, int)> _dirMap = new()
        {
            {Direction.North, new(0, 1)},
            {Direction.East, new(1, 0)},
            {Direction.South, new(0, -1)},
            {Direction.West, new(-1, 0)}
        };

        public int Calculate1(IEnumerable<string> lines)
        {
            var instructions = lines.Select(Instruction.Parse).ToList();

            var direction = Direction.East;
            int x = 0, y = 0;

            foreach (var instruction in instructions)
            {
                var dirX = _dirMap[direction].Item1;
                var dirY = _dirMap[direction].Item2;

                switch (instruction.Type)
                {
                    case InstructionType.GoNorth:
                        y += instruction.Value;
                        break;
                    case InstructionType.GoEast:
                        x += instruction.Value;
                        break;
                    case InstructionType.GoWest:
                        x -= instruction.Value;
                        break;
                    case InstructionType.GoSouth:
                        y -= instruction.Value;
                        break;
                    case InstructionType.TurnLeft:
                        direction = TurnLeft(direction, instruction.Value / 90);
                        break;
                    case InstructionType.TurnRight:
                        direction = TurnRight(direction, instruction.Value / 90);
                        break;
                    case InstructionType.GoForward:
                        x += dirX * instruction.Value;
                        y += dirY * instruction.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(instruction.Type), "");
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        public int Calculate2(IEnumerable<string> lines)
        {
            var instructions = lines.Select(Instruction.Parse).ToList();
            int wX = 10, wY = 1;
            int x = 0, y = 0;

            foreach (var instruction in instructions)
            {
                switch (instruction.Type)
                {
                    case InstructionType.GoNorth:
                        wY += instruction.Value;
                        break;
                    case InstructionType.GoEast:
                        wX += instruction.Value;
                        break;
                    case InstructionType.GoWest:
                        wX -= instruction.Value;
                        break;
                    case InstructionType.GoSouth:
                        wY -= instruction.Value;
                        break;
                    case InstructionType.TurnLeft:
                        for (var i = 0; i < instruction.Value / 90; i++)
                        {
                            var tempX = wX;
                            wX = -wY;
                            wY = tempX;
                        }

                        break;
                    case InstructionType.TurnRight:
                        for (var i = 0; i < instruction.Value / 90; i++)
                        {
                            var tempX = wX;
                            wX = wY;
                            wY = -tempX;
                        }

                        break;
                    case InstructionType.GoForward:
                        x += instruction.Value * wX;
                        y += instruction.Value * wY;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(instruction.Type), "");
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }


        private Direction TurnLeft(Direction current, int times)
        {
            for (var i = 0; i < times; i++)
            {
                current = current switch
                {
                    Direction.North => Direction.West,
                    Direction.West => Direction.South,
                    Direction.South => Direction.East,
                    Direction.East => Direction.North,
                    _ => current
                };
            }

            return current;
        }

        private Direction TurnRight(Direction current, int times)
        {
            for (var i = 0; i < times; i++)
            {
                current = current switch
                {
                    Direction.North => Direction.East,
                    Direction.East => Direction.South,
                    Direction.South => Direction.West,
                    Direction.West => Direction.North,
                    _ => current
                };
            }

            return current;
        }
    }
}