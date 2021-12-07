using System.Collections.Generic;
using System.IO;
using System;
using System.Numerics;

namespace Nulah.AdventOfCode2022.Day2
{
    public class SubmarineController
    {
        private Position _position = new Position();

        public int FollowInstructions()
        {
            _position = new();

            var inputFile = File.ReadAllLines("Day2Input.txt");

            if (inputFile == null || inputFile.Length == 0)
            {
                return 0;
            }

            foreach (string line in inputFile)
            {
                var instructionLine = line.Split(' ');

                if (instructionLine.Length != 2)
                {
                    throw new InvalidDataException();
                }

                switch (char.ToUpper(instructionLine[0][0]))
                {
                    case 'F':
                        _position.Horizontal += int.Parse(instructionLine[1]);
                        break;
                    case 'D':
                        _position.Depth += int.Parse(instructionLine[1]);
                        break;
                    case 'U':
                        _position.Depth -= int.Parse(instructionLine[1]);
                        break;
                    default:
                        break;
                }
            }

            return _position.Horizontal * _position.Depth;
        }

        public int FollowInstructionsWithAim()
        {
            _position = new();

            var inputFile = File.ReadAllLines("Day2Input.txt");

            if (inputFile == null || inputFile.Length == 0)
            {
                return 0;
            }

            foreach (string line in inputFile)
            {
                var instructionLine = line.Split(' ');

                if (instructionLine.Length != 2)
                {
                    throw new InvalidDataException();
                }

                switch (char.ToUpper(instructionLine[0][0]))
                {
                    case 'F':
                        _position.Horizontal += int.Parse(instructionLine[1]);
                        _position.Depth += int.Parse(instructionLine[1]) * _position.Aim;
                        break;
                    case 'D':
                        _position.Aim += int.Parse(instructionLine[1]);
                        break;
                    case 'U':
                        _position.Aim -= int.Parse(instructionLine[1]);
                        break;
                    default:
                        break;
                }
            }

            return _position.Horizontal * _position.Depth;
        }
    }

    public struct Position
    {
        public int Horizontal;
        public int Depth;
        public int Aim;

        public Position()
        {
            Horizontal = 0;
            Depth = 0;
            Aim = 0;
        }
    }
}