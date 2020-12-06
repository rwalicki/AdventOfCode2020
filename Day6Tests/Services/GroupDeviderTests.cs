using Day6.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Day6Tests.Services
{
    [TestFixture]
    public class GroupDeviderTests
    {
        [Test]
        public void DevideByReturnSymbol_InputIsSomeList_Returns3ElementList()
        {
            var list = new List<string>() { "a", "", "b", "c", "", "a", "" };
            var service = new GroupDevider();

            var sortedList = service.DevideByReturnSymbol(list);

            Assert.AreEqual(3, sortedList.Count);
        }

        [Test]
        public void CreateGroups_InputIsSomeList_ReturnsGroupListWith6PassengersAnd3UniqueAnswers()
        {
            var list = new List<List<string>>() { new List<string>() { "abc", "a", "a", "a", "b", "c" } };
            var service = new GroupDevider();

            var sortedByGroupList = service.CreateGroups(list);

            Assert.AreEqual(6, sortedByGroupList[0].Passengers);
            Assert.AreEqual(3, sortedByGroupList[0].UniqueYesAnswers);
        }

        [Test]
        public void CreateGroups_InputIsSomeRandomList_ReturnsGroupWith5UniqueAnswers()
        {
            var list = new List<string>() { "abcdf", "c", "ab", "cf", "fc", "b", "f", "", "abcdef", "c", "ab", "cf", "fc", "b", "f", "" };
            var service = new GroupDevider();
            var unsortedList = service.DevideByReturnSymbol(list);

            var sortedByGroupList = service.CreateGroups(unsortedList);

            Assert.AreEqual(5, sortedByGroupList[0].UniqueYesAnswers);
            Assert.AreEqual(6, sortedByGroupList[1].UniqueYesAnswers);
        }

        [Test]
        public void CreateGroupsWithIntersection_InputIsSomeRandomList_ReturnsGroupWith5UniqueAnswers()
        {
            var list = new List<string>() { "abcdf", "ac", "abc", "acf", "afc", "abc", "afc", "", "abcdef", "bfc", "abfb", "cfb", "fbc", "bf", "bf", "" };
            var service = new GroupDevider();
            var unsortedList = service.DevideByReturnSymbol(list);

            var sortedByGroupList = service.CreateGroupsWithIntersection(unsortedList);

            Assert.AreEqual(2, sortedByGroupList[0].UniqueYesAnswers);
            Assert.AreEqual(2, sortedByGroupList[1].UniqueYesAnswers);
        }

        [Test]
        public void SumOfCounts_InputIsSomeTextWith11CountofSum_ReturnsSumOf11()
        {
            var list = new List<string>() { "abcdf", "c", "ab", "cf", "fc", "b", "f", "", "abcdef", "c", "ab", "cf", "fc", "b", "f", ""};
            var service = new GroupDevider();
            var unsortedList = service.DevideByReturnSymbol(list);
            var sortedByGroupList = service.CreateGroups(unsortedList);

            var sum = service.SumOfCounts(sortedByGroupList);

            Assert.AreEqual(11, sum);
        }
    }
}