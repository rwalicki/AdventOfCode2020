using AdventOfCode2020.Puzzles.Day2.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCodeTests.Puzzles.Day2.Services
{
    [TestFixture]
    internal class PasswordValidatorTests
    {
        [Test]
        public void DevideByReturnSymbol_InputIsSomeList_Returns3ElementList()
        {
            var list = new List<string>() { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
            var service = new PasswordValidator();

            var result = service.GetValidPasswordsOldJobPolicy(list);

            Assert.AreEqual(2, result);
        }
    }
}