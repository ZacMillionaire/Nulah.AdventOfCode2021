using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nulah.AdventOfCode2021.Day3;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nulah.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day3Test
    {

        private string[] _testInput = new string[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [TestMethod]
        public void BinarySampleInput_ShouldProduce_ListInt()
        {
            var diagnosticReporter = new DiagnosticReporter();

            var expected = new List<int>(12)
            {
                4,30,22,23,21,15,7,28,16,25,2,10
            };

            var result = diagnosticReporter.StringInputToList(_testInput);

            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
            Assert.AreEqual(5, diagnosticReporter.BinaryWidth);
        }

        [TestMethod]
        public void GetGammaForBinarySampleInput_ShouldProduce_22()
        {
            var diagnosticReporter = new DiagnosticReporter();
            var input = diagnosticReporter.StringInputToList(_testInput);

            var result = diagnosticReporter.CalculateDiagnosticGamma(input);

            Assert.AreEqual(22, result);
        }

        [TestMethod]
        public void GetEpsilonForBinarySampleInput_ShouldProduce_9()
        {
            var diagnosticReporter = new DiagnosticReporter();
            var input = diagnosticReporter.StringInputToList(_testInput);

            var gamma = diagnosticReporter.CalculateDiagnosticGamma(input);

            var result = diagnosticReporter.CalculateEpsilon(gamma);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void GetPowerConsumption_ForBinarySampleInput_ShouldProduce_198()
        {
            var diagnosticReporter = new DiagnosticReporter();
            var input = diagnosticReporter.StringInputToList(_testInput);

            var result = diagnosticReporter.GetPowerConsumption(input);

            Assert.AreEqual(198, result);
        }

        [TestMethod]
        public void GetPowerConsumption_ForDay3BinaryInput()
        {
            var diagnosticReporter = new DiagnosticReporter();
            var AoCAssembly = typeof(DiagnosticReporter).Assembly;
            var AoCAssemblyLocation = new FileInfo(AoCAssembly.Location).Directory;
            var day3InputFileLocation = Path.Combine(AoCAssemblyLocation.FullName, "Day03", "Day3Input.txt");
            var input = diagnosticReporter.StringInputToList(File.ReadAllLines(day3InputFileLocation));

            // Answer confirmed for my submission
            var expected = 3320834;

            var result = diagnosticReporter.GetPowerConsumption(input);

            Assert.AreEqual(3320834, result);
        }
    }
}