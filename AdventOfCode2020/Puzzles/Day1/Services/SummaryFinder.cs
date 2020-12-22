using AdventOfCode2020.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day1.Services
{
    public class SummaryFinder
    {
        private ConverterService _converter;

        public SummaryFinder()
        {
            _converter = new ConverterService();
        }

        public (int, int) Find2020SumOfTwoNumbers(List<string> list)
        {
            var convertedList = _converter.ConvertToInt(list);
            for (int i = 0; i < convertedList.Count; i++)
            {
                for (int j = i + 1; j < convertedList.Count; j++)
                {
                    if (convertedList[i] + convertedList[j] == 2020)
                    {
                        return (convertedList[i], convertedList[j]);
                    }
                }
            }
            return (0, 0);
        }

        public (double, double) FindAnySumOfTwoNumbers(List<double> list, double findingSummary)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] + list[j] == findingSummary)
                    {
                        return (list[i], list[j]);
                    }
                }
            }
            return (-1, -1);
        }

        public (int, int, int) Find2020SumOfThreeNumbers(List<string> list)
        {
            var convertedList = _converter.ConvertToInt(list);
            for (int i = 0; i < convertedList.Count; i++)
            {
                for (int j = i + 1; j < convertedList.Count; j++)
                {
                    for (int k = j + 1; k < convertedList.Count; k++)
                    {
                        if (convertedList[i] + convertedList[j] + convertedList[k] == 2020)
                        {
                            return (convertedList[i], convertedList[j], convertedList[k]);
                        }
                    }
                }
            }
            return (0, 0, 0);
        }

        public List<double> FindContiguousSet(List<double> list, double result)
        {
            var sum = 0d;
            var returnList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                returnList.Clear();
                returnList.Add(i);
                sum = list[i];
                for (int j = i + 1; j < list.Count; j++)
                {
                    sum += list[j];
                    returnList.Add(j);
                    if (sum == result)
                    {
                        var findingData = new List<double>();
                        returnList.ForEach(x => findingData.Add(list[x]));
                        return findingData;
                    }
                }
            }
            return null;
        }
    }
}
