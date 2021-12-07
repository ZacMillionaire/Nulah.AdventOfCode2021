using Nulah.AdventOfCode2021.Day1;
using Nulah.AdventOfCode2021.Day2;
using Nulah.AdventOfCode2021.Day3;
using System;
using System.IO;

namespace Nulah.AdventOfCode2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Day1()
            //Day2();
            Day3();
        }

        static void Day1()
        {
            var depthMeasurement = new DepthMeasurement();
            var part1 = depthMeasurement.CountDepthIncreases();
            var part2 = depthMeasurement.CountDepthIncreasesSlidingWindow();
        }

        static void Day2()
        {
            var submarineController = new SubmarineController();
            var finalLocation = submarineController.FollowInstructions();
            var finalLocationWithAim = submarineController.FollowInstructionsWithAim();
        }

        static void Day3()
        {
            var diagnosticReporter = new DiagnosticReporter();
            var input = diagnosticReporter.StringInputToList(File.ReadAllLines("Day03/Day3Input.txt"));

            var result = diagnosticReporter.GetPowerConsumption(input);

        }
    }
}
