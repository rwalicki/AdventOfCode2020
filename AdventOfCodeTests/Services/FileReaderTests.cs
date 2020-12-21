using AdventOfCode2020.Services;
using NUnit.Framework;

namespace AdventOfCodeTests.Services
{
    [TestFixture]
    public class FileReaderTests
    {
        [Test]
        public void ReadTextToList_InputIsPlainText4Lines_Returns4ElementsList()
        {
            var text = "abc\n" +
                "abc\n" +
                "abc\n" +
                "abc\n" +
                "";
            var service = new FileReader();

            var list = service.ReadTextToList(text);

            Assert.AreEqual(5, list.Count);
        }

        [Test]
        public void ReadTextToList_InputIsPlainText4LinesWithWhiteSpaces_Returns4ElementsList()
        {
            var text = "abc\n" +
                "abc\n" +
                "\n" +
                "abc\n" +
                "";
            var service = new FileReader();

            var list = service.ReadTextToList(text);

            Assert.AreEqual(5, list.Count);
        }

        [Test]
        public void ReadTextToList_InputIsPlainText9LinesWithWhiteSpaces_Returns9ElementsList()
        {
            var text = "f\n" +
                "v\n" +
                "ki\n" +
                "\n" +
                "krlugwajesizdptcvqh\n" +
                "vwuzeicrdhpastknmo\n" +
                "zchstrwvaxkipeoud\n" +
                "hvwzoetbdisrakxcpu\n" +
                "";
            var service = new FileReader();

            var list = service.ReadTextToList(text);

            Assert.AreEqual(9, list.Count);
        }
    }
}