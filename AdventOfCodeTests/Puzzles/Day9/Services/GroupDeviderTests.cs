using AdventOfCode2020.Puzzles.Day9.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCodeTests.Puzzles.Day9.Services
{
    [TestFixture]
    public class PreambleServiceTests
    {
        [Test]
        public void DevideByReturnSymbol_InputIsSomeList_Returns3ElementList()
        {
            var list = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var service = new PreambleService(2);

            var result = service.MakePackets(list);

            Assert.AreEqual(10, result.Count);
        }

        [Test]
        public void DevideByReturnSymbol_InputIsSomeList_Returns3ElementList2()
        {
            var list = new List<double>() { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 };
            var service = new PreambleService(5);

            var result = service.FindInvalidElement(list);

            Assert.AreEqual(127, result);
        }

        [Test]
        public void DevideByReturnSymbol_InputIsSomeList_Returns3ElementList3()
        {
            var list = new List<double>() { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 };
            var service = new PreambleService(5);

            var result = service.FindContiguousSetResult(list, 127);

            Assert.AreEqual(62, result);
        }
    }
}