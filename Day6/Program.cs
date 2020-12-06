using Day6.Services;
using System;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var text = fileReader.ReadFileToPlainText(@"C:\downloads\input.txt");
            var list = fileReader.ReadTextToList(text);

            var groupDevider = new GroupDevider();
            var sortedList = groupDevider.DevideByReturnSymbol(list);
            var sortedByGroupsPart1 = groupDevider.CreateGroups(sortedList);
            var sortedByGroupsPart2 = groupDevider.CreateGroupsWithIntersection(sortedList);
            var sum1 = groupDevider.SumOfCounts(sortedByGroupsPart1);
            var sum2 = groupDevider.SumOfCounts(sortedByGroupsPart2);

            Console.WriteLine($"Part1:{sum1}");
            Console.WriteLine($"Part2:{sum2}");
            Console.ReadKey();
        }
    }
}
