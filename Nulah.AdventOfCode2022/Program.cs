using Nulah.AdventOfCode2022.Day1;
using System;

namespace Nulah.AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        static void Day1()
        {
            var depthMeasurement = new DepthMeasurement();
            var part1 = depthMeasurement.CountDepthIncreases();
            var part2 = depthMeasurement.CountDepthIncreasesSlidingWindow();
        }
    }
}
