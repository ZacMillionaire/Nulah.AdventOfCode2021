using Nulah.AdventOfCode2022.Day1;
using Nulah.AdventOfCode2022.Day2;
using System;

namespace Nulah.AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Day1()
            Day2();
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
        }
    }
}
