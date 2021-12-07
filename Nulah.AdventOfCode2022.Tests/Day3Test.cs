using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nulah.AdventOfCode2022.Day3;
using System.Collections.Generic;
using System.Linq;

namespace Nulah.AdventOfCode2022.Tests
{
    [TestClass]
    public class Day3Test
    {

        [TestMethod]
        public void BinaryInput_ShouldProduce_ListInt()
        {
            var diagnosticReporter = new DiagnosticReporter();

            var expected = new List<int>(12)
            {
                4,30,22,23,21,15,7,28,16,25,2,10
            };

            var result = diagnosticReporter.StringInputToList(new string[]
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
            });

            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
            Assert.AreEqual(5, diagnosticReporter.BinaryWidth);
        }

        [TestMethod]
        public void GetPowerConsumption_ForBinaryInput_ShouldProduce_198()
        {
            var diagnosticReporter = new DiagnosticReporter();
            var input = diagnosticReporter.StringInputToList(new string[]
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
            });

            var result = diagnosticReporter.GetPowerConsumption(input);

            Assert.AreEqual(198, result);
        }
    }
}