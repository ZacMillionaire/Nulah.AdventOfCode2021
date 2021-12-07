using System.IO;

namespace Nulah.AdventOfCode2022.Day1
{
    public class DepthMeasurement
    {
        public int CountDepthIncreases()
        {
            var inputFile = File.ReadAllLines("Day1Input.txt");

            if (inputFile != null && inputFile.Length > 0)
            {
                // Store the first input
                var previousDepth = int.Parse(inputFile[0]);
                var increaseCount = 0;

                // Start at the next line and compare all values
                for (var i = 1; i < inputFile.Length; i++)
                {
                    var depth = int.Parse(inputFile[i]);
                    if (depth > previousDepth)
                    {
                        increaseCount++;
                    }
                    previousDepth = depth;
                }

                return increaseCount;
            }


            return 0;
        }

        public int CountDepthIncreasesSlidingWindow()
        {
            var inputFile = File.ReadAllLines("Day1Input.txt");

            if (inputFile != null && inputFile.Length > 0)
            {
                // Calculate the first window of input
                var previousWindow = int.Parse(inputFile[0]) + int.Parse(inputFile[1]) + int.Parse(inputFile[2]);
                var increaseCount = 0;

                // Start the loop at 3, then count the sliding window for the current line plus previous 2 inputs
                for (var i = 3; i < inputFile.Length; i++)
                {
                    var depth = int.Parse(inputFile[i - 2]) + int.Parse(inputFile[i - 1]) + int.Parse(inputFile[i]);

                    if (depth > previousWindow)
                    {
                        increaseCount++;
                    }
                    previousWindow = depth;
                }

                return increaseCount;
            }


            return 0;
        }
    }
}