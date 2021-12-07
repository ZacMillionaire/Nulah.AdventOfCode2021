using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nulah.AdventOfCode2021.Day3
{
    public class DiagnosticReporter
    {
        /// <summary>
        /// The length of the binary input to mask to
        /// </summary>
        public int BinaryWidth { get; private set; }

        /// <summary>
        /// Converts a diagnostic input containing a line separated list of binary numbers.
        /// <para>
        /// Sets <see cref="BinaryWidth"/> to the length of the first line
        /// </para>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<int> StringInputToList(string[] input)
        {
            if (input == null || input.Count() == 0)
            {
                return default;
            }

            var outputList = new List<int>(input.Count());

            // Set the expected size of the binary input naively
            BinaryWidth = input[0].Length;

            foreach (string binaryLine in input)
            {
                outputList.Add(Convert.ToInt32(binaryLine, 2));
            }

            return outputList;
        }

        /// <summary>
        /// Returns the power consumption for the given diagnostic input
        /// </summary>
        /// <param name="diagnosticInput"></param>
        /// <returns></returns>
        public int GetPowerConsumption(List<int> diagnosticInput)
        {
            if (diagnosticInput == null || diagnosticInput.Count == 0)
            {
                return -1;
            }

            var gamma = CalculateDiagnosticGamma(diagnosticInput);
            var epsilon = CalculateEpsilon(gamma);

            return gamma * epsilon;
        }

        /// <summary>
        /// Returns the "gamma" value of all the diagnostic inputs.
        /// <para>
        /// This value is simply a value that represents (in binary) the majority of all 1's in each column of the input.
        /// </para>
        /// <para>
        /// "Each bit in the gamma rate can be determined by finding the most common bit in the corresponding position of all numbers in 
        /// the diagnostic report" - https://adventofcode.com/2021/day/3
        /// </para>
        /// </summary>
        /// <param name="diagnosticInput"></param>
        /// <returns></returns>
        public int CalculateDiagnosticGamma(List<int> diagnosticInput)
        {
            var gamma = 0;

            // Loop for the length of the previously parsed binary input, starting with the least significant bit
            // to get if that "column" of bits has more 1's that 0's
            for (var binaryPosition = 0; binaryPosition <= BinaryWidth; binaryPosition++)
            {
                // Set our mask to be the position of the bit we're currently interested in
                var mask = 0b1 << binaryPosition;
                // To know if we have more 1's than 0's, calculate the max value possible if all columns contained a 1 
                var max = mask * diagnosticInput.Count;

                // Get the int value resulting in summing all bits in the mask position with a 1 for their bit
                int cumulativeTotal = GetMostSignificantBit(diagnosticInput, mask);

                // Compare the total, and if it's greater than half the max, we have more 1's than 0's for that "column"
                if (cumulativeTotal > max / 2)
                {
                    // XOR the gamma value by the mask to flip the bit in the position to 1
                    gamma = gamma ^ mask;
                }
            }

            return gamma;
        }

        /// <summary>
        /// Returns an int representing the total number of 1's for the given mask over all inputs.
        /// </summary>
        /// <param name="diagnosticInput"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        private static int GetMostSignificantBit(List<int> diagnosticInput, int mask)
        {
            var cumulativeTotal = 0;

            foreach (int input in diagnosticInput)
            {
                // Accumulate all bits that are 1 by masking the int against the mask.
                // If the bits in that masked position are 1 then we add the max value possible for that position
                // (the result will be 0xN where N is a 1 shifted, 0x1 being +1, 0x10 being +2, 0x100 being +4 etc)
                // If the bits differ, the cumulative total will have 0 added to it because 0x0 is...0
                cumulativeTotal += input & mask;
            }

            return cumulativeTotal;
        }

        /// <summary>
        /// Calculates the epsilon value.
        /// <para>
        /// "The epsilon rate is calculated in a similar way; rather than use the most common bit,
        /// the least common bit from each position is used." - https://adventofcode.com/2021/day/3
        /// </para>
        /// </summary>
        /// <param name="gamma"></param>
        /// <returns></returns>
        public int CalculateEpsilon(int gamma)
        {
            // The epsilon is essentially the inverse of the gamma
            // "The epsilon rate is calculated in a similar way; rather than use the most common bit, the least common bit from each position is used."
            // This basically means the columns of bits from the input that are 0 dominant, which is simply the inverse of gamma.
            // To do this, we get the inverse (signed) shifted by the length of the binary input, then xor that against
            // the inverse (unary compliment) of gamma to get the final output
            var s = -0b1 << BinaryWidth;
            return ~gamma ^ s;
        }
    }
}
