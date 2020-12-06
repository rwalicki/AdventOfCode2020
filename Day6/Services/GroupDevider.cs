using System.Collections.Generic;
using Day6.Model;
using System.Linq;

namespace Day6.Services
{
    public class GroupDevider
    {
        public List<List<string>> DevideByReturnSymbol(List<string> unsortedData)
        {
            var sortedList = new List<List<string>>();
            var list = new List<string>();

            for (int i = 0; i < unsortedData.Count; i++)
            {
                var element = unsortedData[i];
                if (string.IsNullOrEmpty(element) || unsortedData.Count - 1 == i)
                {
                    sortedList.Add(list);
                    list = new List<string>();
                }
                else
                {
                    list.Add(element);
                }
            }

            return sortedList;
        }

        public List<Group> CreateGroups(List<List<string>> sortedLists)
        {
            var groupList = new List<Group>();
            foreach (var passengersGroup in sortedLists)
            {
                var passengers = passengersGroup.Count;

                var uniqueElements = new List<char>();
                foreach (var element in passengersGroup)
                {
                    uniqueElements = uniqueElements.Union(element.ToList()).ToList();
                }

                var uniqueYesAnswers = uniqueElements.Count;

                var group = new Group(passengers, uniqueYesAnswers);
                groupList.Add(group);
            }
            return groupList;
        }

        public List<Group> CreateGroupsWithIntersection(List<List<string>> sortedLists)
        {
            var groupList = new List<Group>();
            foreach (var passengersGroup in sortedLists)
            {
                var passengers = passengersGroup.Count;

                var uniqueElements = passengersGroup.FirstOrDefault().ToList();
                foreach (var element in passengersGroup)
                {
                    uniqueElements = uniqueElements.Intersect(element.ToList()).ToList();
                }

                var uniqueYesAnswers = uniqueElements.Count;

                var group = new Group(passengers, uniqueYesAnswers);
                groupList.Add(group);
            }
            return groupList;
        }

        public int SumOfCounts(List<Group> sortedByGroups)
        {
            var i = 0;
            sortedByGroups.ForEach(x => i += x.UniqueYesAnswers);
            return i;
        }
    }
}