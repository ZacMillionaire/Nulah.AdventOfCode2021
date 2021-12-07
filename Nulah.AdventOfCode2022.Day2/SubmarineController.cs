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
                        _position.X += int.Parse(instructionLine[1]);
                        break;
                    case 'D':
                        _position.Y += int.Parse(instructionLine[1]);
                        break;
                    case 'U':
                        _position.Y -= int.Parse(instructionLine[1]);
                        break;
                    default:
                        break;
                }
            }

            return _position.X * _position.Y;
        }
    }

    public struct Position
    {
        public int X;
        public int Y;

        public Position()
        {
            X = 0;
            Y = 0;
        }
    }
}